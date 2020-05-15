using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF.DVDCentral.BL.Models
{
   public class ShoppingCart
    { //This does not apply to your dvd central app
        //the cost of a movie is retrieved from the tblMovie.cost

        public List<Movie> Items { get; set; }
        public int TotalCount { get { return Items.Count; } }
        public decimal TotalCost { get; set; }
        public ShoppingCart()
        {
            Items = new List<Movie>();
        }

        public void Add(Movie movie)
        {
            Items.Add(movie);
            TotalCost += movie.Cost; //Cost of each movie for DVDCentral
        }
        public void Remove(Movie movie)
        {
            Items.Remove(movie);
            TotalCost += movie.Cost;
        }

        public void Checkout()
        {
            Items = new List<Movie>();
            TotalCost = 0;
        }
    }
}
