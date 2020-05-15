using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PF.DVDCentral.BL.Models;

namespace PF.DVDCentral.BL
{
    public class ShoppingCartManager
    {
        public static void Checkout(ShoppingCart cart)
        {

            //OrderItem orderItem = new OrderItem();
            //orderItem.OrderId = 1;
            //OrderItemManager.Insert( cart.Items);
            //cart.Checkout();



            // For DVDCentral, do these things when you checkout
            // 1. Insert an tblOrder. Get the tblOrder.Id
            // 2. Loop through the Items, and insert a tblOrderItem record with the new Order.Id
            // 3. Remove the item from the cart.
        }
        public static void Add(ShoppingCart cart, Movie movie)
        {

            cart.Add(movie);
        }

        public static void Remove(ShoppingCart cart, Movie movie)
        {
            cart.Remove(movie);
        }



    }
}

