using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PF.DVDCentral.BL.Models;

namespace PF.DVDCentral.BL
{
    public class OrderManager
    {
        public static int Insert(int customerId, DateTime orderdate, int userid, DateTime shipdate)
        {
            return 0;
        }

        public static int Insert(Order order)
        {
            return Insert(order.CustomerID,order.OrderDate,order.ShipDate,order.UserID);

        }

        public static int Update(int id, string description)
        {
            return 0;
        }

        public static int Update(Order order)
        {
            return Update(Order.ID, Order.Description);
        }

        public static int Delete(int id)
        {
            return 0;
        }


        public static List<Order> Load()
        {
            return new List<Order>();
        }

        public static Order LoadByID()
        {
            return new Order();
        }
    }
}
