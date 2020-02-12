using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PF.DVDCentral.PL;
using System.Linq;

namespace PF.DVDCentral.PL.Test
{
    [TestClass]
    public class utDirector
    {
        [TestMethod]
        public void LoadTest()
        {
            DVDCentralEntities dc = new DVDCentralEntities();

            //SELECT * FROM tblDirector - LINQ SQL
            var results = from director in dc.tblDirectors
                          select director;

            int expected = 12;
            int actual = results.Count();

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void InsertTest()
        {
            using(DVDCentralEntities dc = new DVDCentralEntities())
            {
                //Make new Director
                tblDirector newrow = new tblDirector();

                //Set the column values
                newrow.Id = -99;
                newrow.FirstName = "Test";
                newrow.LastName = "Test";

                //Add the Row
                dc.tblDirectors.Add(newrow);

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
                tblDirector row = (from dt in dc.tblDirectors
                                where dt.Id == -99
                                select dt).FirstOrDefault();
                if(row != null)
                {
                    //change values
                    row.FirstName = "New FirstName";

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
                tblDirector row = (from dt in dc.tblDirectors
                                where dt.Id == -99
                                select dt).FirstOrDefault();
                if (row != null)
                {
                    dc.tblDirectors.Remove(row);
                    int actual = dc.SaveChanges();

                    Assert.AreNotEqual(0, actual);


                }

            }
        }
    }
}
