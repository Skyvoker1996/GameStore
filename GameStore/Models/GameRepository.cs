using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GameStore.Abstract;
using GameStore.Infrastructure;
using GameStore.DBModel;

namespace GameStore.Models
{   /// <summary>
    ///  Klasa implementująca interfejs IGameRepository
    /// </summary>
    public class GameRepository : IGameRepository
    {
        private GameStoreServiceClient serviceContext = new GameStoreServiceClient();

        /// <summary>
        /// Metoda zwracająca dane gier
        /// </summary>
        public IEnumerable<Game> Games {
            get
            {
                return serviceContext.Games();
            }
        }

        /// <summary>
        /// Metoda implementująca usuwanie gier z bazy danych
        /// </summary>
        /// <param name="gameID"></param>
        /// <returns></returns>
        public Game DeleteGame(int gameID)
        {
            return serviceContext.DeleteGame(gameID);
        }
        /// <summary>
        ///  Metoda implementująca dodawanie gier z bazy danych
        /// </summary>
        /// <param name="game"></param>
        public void SaveGame(Game game)
        {
            serviceContext.SaveGame(game);
        }
    }
}