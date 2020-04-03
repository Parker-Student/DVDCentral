using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PF.DVDCentral.PL;
using System.Linq;

namespace PF.DVDCentral.PL.Test
{
    [TestClass]
    public class utOrder
    {
        [TestMethod]
        public void LoadTest()
        {
            DVDCentralEntities dc = new DVDCentralEntities();

            //SELECT * FROM tblOrder - LINQ SQL
            var results = from order in dc.tblOrders
                          select order;

            int expected = 3;
            int actual = results.Count();

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void InsertTest()
        {
            using(DVDCentralEntities dc = new DVDCentralEntities())
            {
                //Make new Order
                tblOrder newrow = new tblOrder();

                //Set the column values
                newrow.Id = -99;
                newrow.CustomerId = -99;
                newrow.OrderDate = new DateTime(2012-10-09);
                newrow.ShipDate = new DateTime(2012 - 10 - 09);
                newrow.UserId = -99;
             
                //Add the Row
                dc.tblOrders.Add(newrow);

                //Save the Changes
                int results = dc.SaveChanges();

                Assert.IsTrue(results > 0);
            }
        }
        [TestMethod]
        public void UpdateTest()
        {
            using (DVDCentralEntities dc = new DVDCentralEntities())
            {
                //Get the Record that I want to update
                //Select * FROM tblrow WHERE Id = -99;
                tblOrder row = (from dt in dc.tblOrders
                                where dt.Id == -99
                                select dt).FirstOrDefault();
                if(row != null)
                {
                    //change values
                    row.Id = -99;
                    row.CustomerId = -99;
                    row.OrderDate = new DateTime(2012 - 10 - 09);
                    row.ShipDate = new DateTime(2012 - 10 - 09);
                    row.UserId = -99;

                    int actual = dc.SaveChanges();

                    Assert.AreNotEqual(0, actual);


                }
            }
        }
        [TestMethod]
        public void DeleteTest()
        {
            using (DVDCentralEntities dc = new DVDCentralEntities())
            {
                tblOrder row = (from dt in dc.tblOrders
                                where dt.Id == -99
                                select dt).FirstOrDefault();
                if (row != null)
                {
                    dc.tblOrders.Remove(row);
                    int actual = dc.SaveChanges();

                    Assert.AreNotEqual(0, actual);


                }

            }
        }
    }
}
