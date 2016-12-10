using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameStore.Abstract;
using GameStore.Models;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using GameStore.DBModel;
using FluentValidation.Results;
using GameStore.Validation;

namespace GameStore.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IGameRepository gamerepository;
        private IShippingRepository shippingrepository;

        public AdminController(IGameRepository repo, IShippingRepository shippingrepo)
        {
            gamerepository = repo;
            shippingrepository = shippingrepo;
        }
         
        public ActionResult Index()
        {
            return View(gamerepository.Games);
        }

        public ActionResult ShippingIndex()
        {
            ShippingInformationModefied shippingMod;

            List<ShippingInformationModefied> shippingInfo = new List<ShippingInformationModefied>();

            foreach (var shippInfo in shippingrepository.ShippingInformations)
            {
                shippingMod = new ShippingInformationModefied();
                string json = shippInfo.CartInfo;
             
                // Deserialization
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Cart));
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
                Cart cartInfo = (Cart)ser.ReadObject(ms);


                shippingMod.ShippingInformationID = shippInfo.ShippingInformationID;
                shippingMod.FullName = shippInfo.FullName;
                shippingMod.StreetAndHouse = shippInfo.StreetAndHouse;
                shippingMod.City = shippInfo.City;
                shippingMod.Country = shippInfo.Country;
                shippingMod.Zip = shippInfo.Zip;
                shippingMod.CartInfo = cartInfo;

                shippingInfo.Add(shippingMod);

            }
            
            return View(shippingInfo);
        }

        public ViewResult Create()
        {
            return View("Edit", new Game());
        }

        public ViewResult Edit(int gameID)
        {
            IEnumerable<Game> list = gamerepository.Games;
            Game game = list
                .Where(g => g.GameID == gameID)
                .FirstOrDefault();

            return View(game);
        }

        [HttpPost]
        public ActionResult Edit(Game game)
        {
            var validator = new GameValidator();
            ValidationResult result = validator.Validate(game);

            if (result.IsValid)
            {
                gamerepository.SaveGame(game);

                TempData["message"] = string.Format("{0} has been saved", game.Name);
                return RedirectToAction("Index");
            }
            else {
                FluentValidationErrorToStateModelError.Update(ModelState, result, true);
                return View(game);
            }
        }

        [HttpPost]
        public ActionResult Delete(int gameID)
        {
            Game delGame = gamerepository.DeleteGame(gameID);

            if (delGame != null)
            {
                TempData["message"] = string.Format("{0} was deleted", delGame.Name);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteOrder(int orderID)
        {
            ShippingInformation delOrder = shippingrepository.DeleteShippingInfo(orderID);

            if (delOrder != null)
            {
                TempData["message"] = "One order was deleted";
            }
            return RedirectToAction("ShippingIndex");
        }
    }
}
