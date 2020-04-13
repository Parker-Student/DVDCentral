using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PF.DVDCentral.PL;
using System.Linq;

namespace PF.DVDCentral.PL.Test
{
    [TestClass]
    public class utOrderItem
    {
        [TestMethod]
        public void LoadTest()
        {
            DVDCentralEntities dc = new DVDCentralEntities();

            //SELECT * FROM tblOrderItem - LINQ SQL
            var results = from orderItem in dc.tblOrderItems
                          select orderItem;

            int expected = 3;
            int actual = results.Count();

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void InsertTest()
        {
            using(DVDCentralEntities dc = new DVDCentralEntities())
            {
                //Make new OrderItem
                tblOrderItem newrow = new tblOrderItem();

                //Set the column values
                newrow.Id = -99;
               
             
                //Add the Row
                dc.tblOrderItems.Add(newrow);

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
                tblOrderItem row = (from dt in dc.tblOrderItems
                                where dt.Id == -99
                                select dt).FirstOrDefault();
                if(row != null)
                {
                    //change values
                    row.OrderId = -99;
                    row.MovieId = -99;
                    row.Quantity = -99;




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
                tblOrderItem row = (from dt in dc.tblOrderItems
                                where dt.Id == -99
                                select dt).FirstOrDefault();
                if (row != null)
                {
                    dc.tblOrderItems.Remove(row);
                    int actual = dc.SaveChanges();

                    Assert.AreNotEqual(0, actual);


                }

            }
        }
    }
}
