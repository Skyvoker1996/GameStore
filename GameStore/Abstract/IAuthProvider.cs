using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Models;

namespace GameStore.Abstract
{/// <summary>
/// Interfejs który przechowuje metode autoryzacji
/// </summary>
    public interface IAuthProvider
    {/// <summary>
     /// Metoda autoryzuje użytkownika
     /// </summary>
     /// <param name="username"></param>
     /// <param name="password"></param>
     /// <returns></returns>
        bool Authenticate(string username, string password);
    }
}
