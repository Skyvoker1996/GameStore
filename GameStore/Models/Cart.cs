using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GameStore.DBModel;

namespace GameStore.Models
{       /// <summary>
        /// Klasa przedstawiajaca listę zamówień 
        /// </summary>
          public class Cart
         {
        
        /// <summary>
        ///  Lista przedstawiajaca listę pozycji zmówienia
        /// </summary>
        private List<CartQueue> CartLine = new List<CartQueue>();

        /// <summary>
        /// Metoda która dodaje grę do listy zamówienia
        /// </summary>
        /// <param name="game"></param>
        /// <param name="amount"></param>
        public void AddItem(Game game, int amount)
        {
            CartQueue queue = CartLine
                .Where(g => g.Game.GameID == game.GameID)
                .FirstOrDefault();

            if (queue == null)
            {
                queue = new CartQueue { Game = game, Amount = amount };
                CartLine.Add(queue);
            }
            else
            {
                queue.Amount += amount;
            }
        }

        /// <summary>
        /// Metoda która usuwa grę z listy zamówienia
        /// </summary>
        /// <param name="game"></param>
        public void RemoveItem(Game game)
        {
            CartLine.RemoveAll(g => g.Game.GameID == game.GameID);
        }

        /// <summary>
        /// Metoda która usuwa podaną przez użytkownika ilość gier o tej samej nazwie z listy zamówienia
        /// </summary>
        /// <param name="game"></param>
        /// <param name="amount"></param>
        public void RemoveItem(Game game, int amount)
        {
            CartQueue queue = CartLine
              .Where(g => g.Game.GameID == game.GameID)
              .FirstOrDefault();

            queue.Amount -= amount;
        }

        /// <summary>
        /// Metoda która usuwa wszystko z listy zamówień
        /// </summary>
        public void RemoveAllItems()
        {
            CartLine.Clear();
        }

        /// <summary>
        /// Metoda zwracająca listę gier w zamówieniu
        /// </summary>
        public List<CartQueue> CartList
        {
            get
            {
                return CartLine;
            }
        }

        /// <summary>
        /// Metoda która oblicza cenę całego zamówienia  
        /// </summary>
        /// <returns></returns>
        public decimal TotalPrice()
        {
            return CartLine.Sum(g => g.Game.Price * g.Amount);
        }
    }

    /// <summary>
    /// Klasa reprezentuje jedną pozycję w liście zamówienia 
    /// </summary>
    public class CartQueue
   {   
        /// <summary>
        /// Dane gry 
        /// </summary>
        public Game Game { set; get; }

        /// <summary>
        /// Ilość gier o jednej nazwie
        /// </summary>
        public int Amount {set; get;}
   }
}