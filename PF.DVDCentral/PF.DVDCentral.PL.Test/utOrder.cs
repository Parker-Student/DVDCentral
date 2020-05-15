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

            int expected = 4;
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
                newrow.OrderDate = Convert.ToDateTime("2012-10-09");
                newrow.ShipDate = Convert.ToDateTime("2012-10-09");
                newrow.UserName = -99;
               
             
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
                    row.CustomerId = -99;
                    row.OrderDate = Convert.ToDateTime("2012-10-09");
                    row.ShipDate = Convert.ToDateTime("2012-10-09");
                    row.UserName = -99;


                                 
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
