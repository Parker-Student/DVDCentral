using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PF.DVDCentral.BL;
using PF.DVDCentral.BL.Models;

namespace PF.DVDCentral.BL.Test
{
    [TestClass]
    public class utOrderItem
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
            List<OrderItem> orderItems = OrderItemManager.Load();
            Assert.AreEqual(4, orderItems.Count);
        }

        public void InsertTest()
        {
            OrderItem orderItem = new OrderItem
            {
                Id = -99,
                MovieId = -99,
                OrderId = -99,
                Quantity = 99
            };

            Assert.AreNotEqual(0, OrderItemManager.Insert(orderItem));
        }  
        
        public void UpdateTest()
        {
            OrderItem orderItem = OrderItemManager.LoadById(12);
            orderItem.MovieId = -99;
            orderItem.OrderId = -99;
            orderItem.Quantity = -99;
            Assert.IsTrue(OrderItemManager.Update(orderItem) > 0);
        }

        public void DeleteTest()
        {
            Assert.IsTrue(OrderItemManager.Delete(12) > 0);
        }
    }

}
