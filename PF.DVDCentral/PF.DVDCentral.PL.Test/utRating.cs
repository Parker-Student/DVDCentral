using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PF.DVDCentral.PL;
using System.Linq;

namespace PF.DVDCentral.PL.Test
{
    [TestClass]
    public class utRating
    {
        [TestMethod]
        public void LoadTest()
        {
            DVDCentralEntities dc = new DVDCentralEntities();

            //SELECT * FROM tblRating - LINQ SQL
            var results = from rating in dc.tblRatings
                          select rating;

            int expected = 4;
            int actual = results.Count();

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void InsertTest()
        {
            using(DVDCentralEntities dc = new DVDCentralEntities())
            {
                //Make new Rating
                tblRating newrow = new tblRating();

                //Set the column values
                newrow.Id = -99;
                newrow.Description = "Test";

                //Add the Row
                dc.tblRatings.Add(newrow);

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
                tblRating row = (from dt in dc.tblRatings
                                where dt.Id == -99
                                select dt).FirstOrDefault();
                if(row != null)
                {
                    //change values
                    row.Description = "New Description";

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
                tblRating row = (from dt in dc.tblRatings
                                where dt.Id == -99
                                select dt).FirstOrDefault();
                if (row != null)
                {
                    dc.tblRatings.Remove(row);
                    int actual = dc.SaveChanges();

                    Assert.AreNotEqual(0, actual);


                }

            }
        }
    }
}
