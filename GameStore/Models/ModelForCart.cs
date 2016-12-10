using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace GameStore.Models
{   /// <summary>
    /// Klasa przedstawiająca model dla kontrolera CartController
    /// </summary>
    public class ModelForCart
    {
      public Cart Cart { set; get; }
      
    /// <summary>
    /// Link powrotu do poprzedniego widoku 
    /// </summary>
      public string ReturnUrl { set; get; }
    }
}