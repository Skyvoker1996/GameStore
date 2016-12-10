using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GameStore.Models
{    /// <summary>
     /// Klasa przedstawia wszystko to samo co i ShippingInformation, jedynie że właściwość zawierająca Listę zamówionych gier jest nie klasą Cart, a tekstem
     /// </summary>
    public class ShippingInformationModefied
    {
        public int ShippingInformationID { set; get; }

        [Required(ErrorMessage = "Please enter your name and last name")]
        public string FullName { set; get; }

        [Required(ErrorMessage = "Please enter street and home/apartment information")]
        public string StreetAndHouse { set; get; }

        [Required(ErrorMessage = "Please enter your city/village")]
        public string City { set; get; }

        [Required(ErrorMessage = "Please enter your country")]
        public string Country { set; get; }

        [Required(ErrorMessage = "Please enter your zip")]
        public string Zip { set; get; }

        public Cart CartInfo { set; get; }
    }
}