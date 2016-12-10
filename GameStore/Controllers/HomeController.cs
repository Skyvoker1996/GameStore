using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GameStore.Abstract;
using GameStore.Models;
using System.Web.Mvc;
using GameStore.DBModel;

namespace GameStore.Controllers
{
    public class HomeController : Controller
    {
        private IGameRepository repository;

        static string globalPlatform;

        public HomeController(IGameRepository repo)
        {
            this.repository = repo;
        }

        public ViewResult Home()
        {
            return View();
        }

        public ViewResult Index(string platform, string category)
        {
            if (platform != null)
            {
                if (globalPlatform == null || globalPlatform != platform)
                {
                    globalPlatform = platform;
                }
            }

            System.Diagnostics.Debug.WriteLine("Platform =" + platform + " " + "Category =" + category);
            GameFiltering model = new GameFiltering
            {
                Games = repository.Games,
                Category = category,
                Platform = globalPlatform
            };

            if (category != null)
            {
                model.Games = repository.Games
                 .Where(p => p.Platform == globalPlatform && p.Category == category)
                 .OrderBy(p => p.GameID);

                return View(model);
            }
            else
            {
                IEnumerable<Game> list = repository.Games;
                model.Games = list
                 .Where(p => p.Platform == globalPlatform)
                 .OrderBy(p => p.GameID);

                Console.WriteLine("Stop here");
                return View(model);
            }
        }
    }
}