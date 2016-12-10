using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GameStore.Models;
using GameStore.DBModel;

namespace GameStore.Abstract
{    /// <summary>
     ///  Interfejs zawierający zmienne i metody dla zarządzania grami 
     /// </summary>
    public interface IGameRepository
    {
        /// <summary>
        /// Enumerator zawierający gry
        /// </summary>
        IEnumerable<Game>Games{ get;}
        
        /// <summary>
        /// Metoda która dodaje gre
        /// </summary>
        /// <param name="game"></param>
        void SaveGame(Game game);
        
        /// <summary>
        /// Metoda usuwająca gre
        /// </summary>
        /// <param name="gameID"></param>
        /// <returns></returns>
        Game DeleteGame(int gameID);
    }
}