using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PF.DVDCentral.PL;
using System.Linq;

namespace PF.DVDCentral.PL.Test
{
    [TestClass]
    public class utCustomer
    {
        [TestMethod]
        public void LoadTest()
        {
            DVDCentralEntities dc = new DVDCentralEntities();

            //SELECT * FROM tblCustomer - LINQ SQL
            var results = from customer in dc.tblCustomers
                          select customer;

            int expected = 4;
            int actual = results.Count();

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void InsertTest()
        {
            using(DVDCentralEntities dc = new DVDCentralEntities())
            {
                //Make new Customer
                tblCustomer newrow = new tblCustomer();

                //Set the column values
                newrow.Id = -99;
                newrow.LastName = "test";
                newrow.FirstName = "test";
                newrow.Address = "test";
                newrow.City = "test";
                newrow.State = "WI";
                newrow.Zip = "test";
                newrow.Phone = "test";
                newrow.UserName = -99;
              
                

                //Add the Row
                dc.tblCustomers.Add(newrow);

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
                tblCustomer row = (from dt in dc.tblCustomers
                                where dt.Id == -99
                                select dt).FirstOrDefault();
                if(row != null)
                {
                    //change values
                    row.LastName = "test";
                    row.FirstName = "test";
                    row.Address = "test";
                    row.City = "test";
                    row.State = "WI";
                    row.UserName = -99;
                    row.Zip = "test";
                    row.Phone = "test";

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
                tblCustomer row = (from dt in dc.tblCustomers
                                where dt.Id == -99
                                select dt).FirstOrDefault();
                if (row != null)
                {
                    dc.tblCustomers.Remove(row);
                    int actual = dc.SaveChanges();

                    Assert.AreNotEqual(0, actual);


                }

            }
        }
    }
}
