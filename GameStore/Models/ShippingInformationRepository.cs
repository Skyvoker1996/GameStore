using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GameStore.Abstract;
using GameStore.Infrastructure;
using GameStore.DBModel;

namespace GameStore.Models
{   /// <summary>
    /// Klasa implementująca interfejs IShippingRepository 
    /// </summary>
    public class ShippingInformationRepository : IShippingRepository
    {
        private GameStoreServiceClient serviceContext = new GameStoreServiceClient();
        /// <summary>
        /// Metoda zwracająca dane zamówień
        /// </summary>
        public IEnumerable<ShippingInformation>ShippingInformations
        {
            get { return serviceContext.ShippingInformations(); }
        }

        /// <summary>
        /// Metoda implementująca dodanie zamówień do bazy danych
        /// </summary>
        /// <param name="shippingInformation"></param>
        public void SaveShippingInformation(ShippingInformation shippingInformation)
        {
            serviceContext.SaveShippingInformation(shippingInformation);
        }
        /// <summary>
        /// Metoda implementująca usuwanie zamówień z bazy danych
        /// </summary>
        /// <param name="shippingInfoID"></param>
        /// <returns></returns>
        public ShippingInformation DeleteShippingInfo(int shippingInfoID)
        {
            return serviceContext.DeleteShippingInfo(shippingInfoID);
        }
    }
}