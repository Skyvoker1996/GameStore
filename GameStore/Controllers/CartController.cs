using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameStore.Models;
using GameStore.Abstract;
using System.Web.Script.Serialization;
using GameStore.DBModel;
using GameStore.Validation;
using FluentValidation.Results;

namespace GameStore.Controllers
{
    public class CartController : Controller
    {
        private IGameRepository repository;
        private IShippingRepository shippingrepository;

        public CartController(IGameRepository repo, IShippingRepository shippingrepo)
        {
            repository = repo;
            shippingrepository = shippingrepo;
        }
   
        public RedirectToRouteResult AddToCart(Cart cart,int gameID, string returnUrl)
        {
            IEnumerable<Game> list = repository.Games;
            Game Game = list
                .Where(g => g.GameID == gameID)
                .FirstOrDefault();
            if (Game != null)
            {
                cart.AddItem(Game, 1);
            }
            return RedirectToAction("Cart", new { returnUrl });
        }
        public RedirectToRouteResult AddToCartFromDescription(Cart cart, int gameID, string returnUrl)
        {
            Game Game = repository.Games
                .Where(g => g.GameID == gameID)
                .FirstOrDefault();
            if (Game != null)
            {
                cart.AddItem(Game, 1);
            }
            return RedirectToAction("Checkout", new { returnUrl });
        }
        public RedirectToRouteResult RemoveFromCart(Cart cart, int gameID, string returnUrl)
        {
            Game Game = repository.Games
                .Where(g => g.GameID == gameID)
                .FirstOrDefault();
            if (Game != null)
            {
                cart .RemoveItem(Game);
            }
            return RedirectToAction("Cart", new { returnUrl });
        }
        public ViewResult Cart(Cart cart, string returnUrl)
        {
            Console.WriteLine("");
            return View(new ModelForCart { Cart = cart,
            ReturnUrl = returnUrl } );
        }
        public PartialViewResult Widget(Cart cart)
        {
            return PartialView(cart);
        }
        public ViewResult Checkout()
        {
            return View(new ShippingInformation());
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingInformation shippingInformation)
        {
            if (cart.CartList.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry your cart is empty!");
            }

            var validator = new ShippingInformationValidator();
            ValidationResult result = validator.Validate(shippingInformation);

            if (result.IsValid)
            {
                // Deleting images from order
                foreach (var c in cart.CartList)
                {
                    c.Game.ImageData = null;
                }

                string CartInfo = new JavaScriptSerializer().Serialize(cart);
                shippingInformation.CartInfo = CartInfo;

                System.Diagnostics.Debug.Write(CartInfo);

                shippingrepository.SaveShippingInformation(shippingInformation);
                cart.RemoveAllItems();
                return View("Completed");
            }
            else
            {
                FluentValidationErrorToStateModelError.Update(ModelState, result, true);
                return View(shippingInformation);
            }
        }
    }
}