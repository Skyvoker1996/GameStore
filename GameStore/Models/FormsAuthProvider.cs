using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GameStore.Abstract;
using System.Web.Security;
using GameStore.Infrastructure;
using GameStore.DBModel;

namespace GameStore.Models
{    /// <summary>
     /// Klasa implementująca interfejs IAuthProvider 
     /// </summary>
    public class FormsAuthProvider : IAuthProvider
    {
        private GameStoreServiceClient serviceContext = new GameStoreServiceClient();
        /// <summary>
        /// Implementacja metody Authenticate która pozwala użytkownikowi mieć dostęp do administrowania strony internetowej 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Authenticate(string username, string password)
        {
            IEnumerable<Login> logins = serviceContext.Logins();

            Login lg = logins
                      .Where(l => l.UserName == username && l.Password == password)
                      .FirstOrDefault();

            bool result = lg != null ? true : false;

            if (result) {
                FormsAuthentication.SetAuthCookie(username, false);
            }
            return result;
        }
    }
}