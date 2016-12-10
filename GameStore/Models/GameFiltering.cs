using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GameStore.DBModel;

namespace GameStore.Models
{    /// <summary>
     /// Klasa zawierająca dane dla filtrowania gier 
     /// </summary>
    public class GameFiltering
    {  
        public IEnumerable<Game> Games { set; get; }
        public string Category { set; get; }
        public string Platform { set; get; }
    }
}