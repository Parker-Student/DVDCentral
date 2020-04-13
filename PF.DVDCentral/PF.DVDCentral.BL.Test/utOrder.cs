using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PF.DVDCentral.BL;
using PF.DVDCentral.BL.Models;

namespace PF.DVDCentral.BL.Test
{
    [TestClass]
    public class utOrder
    {
        [TestMethod]
        public void RunAll()
        {
            LoadTest();
            InsertTest();
            UpdateTest();
            DeleteTest();
        }
        
        public void LoadTest()
        {
            List<Order> orders = OrderManager.Load();
            Assert.AreEqual(4, orders.Count);
        }

        public void InsertTest()
        {
           Order order = new Order {CustomerId = -99, OrderDate = Convert.ToDateTime("2012-10-09"), 
               ShipDate = Convert.ToDateTime("2012-10-09"), UserId = -99
        };
           Assert.AreNotEqual(0, OrderManager.Insert(order));
           
        }
        public void UpdateTest()
        {
            Order order = OrderManager.LoadById(12);
            order.CustomerId = -99;
            order.OrderDate = Convert.ToDateTime("2012-10-09");
            order.ShipDate = Convert.ToDateTime("2012-10-09");
            order.UserId = -99;
            Assert.IsTrue(OrderManager.Update(order) > 0);
        }

        public void DeleteTest()
        {
            Assert.IsTrue(OrderManager.Delete(12) > 0);
        }
    }

}
