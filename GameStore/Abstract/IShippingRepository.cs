using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Models;
using GameStore.DBModel;

namespace GameStore.Abstract
{    /// <summary>
     ///  Interfejs zawierający zmienne i metody do zarządzania zamówieniami
     /// </summary>
    public interface IShippingRepository
    {   /// <summary>
        /// Enumerator zawierający zamówienia
        /// </summary>
        IEnumerable<ShippingInformation> ShippingInformations { get; }

        /// <summary>
        /// Metoda która dodaje zamówienia
        /// </summary>
        /// <param name="shippingInformation"></param>
        void SaveShippingInformation(ShippingInformation shippingInformation);

        /// <summary>
        ///  Metoda usuwająca zamówienia
        /// </summary>
        /// <param name="shippingInfoID"></param>
        /// <returns></returns>
        ShippingInformation DeleteShippingInfo(int shippingInfoID);
    }
}
