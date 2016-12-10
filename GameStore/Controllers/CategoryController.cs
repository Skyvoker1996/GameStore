using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameStore.Abstract;
using GameStore.Models;

namespace GameStore.Controllers
{
    public class CategoryController : Controller
    {
        private IGameRepository repository;

        public CategoryController(IGameRepository repo){
            repository = repo;
        }
        // GET: Category
        public PartialViewResult List(string category = null)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = repository.Games
                 .Where(g => g.Platform == Convert.ToString(RouteData.Values["Platform"]))
                 .Select(g => g.Category)
                 .Distinct()
                 .OrderBy(g => g);
              
            return PartialView(categories);
        }
    }
}