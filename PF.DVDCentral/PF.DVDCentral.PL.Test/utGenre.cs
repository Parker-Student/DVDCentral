using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PF.DVDCentral.PL;
using System.Linq;

namespace PF.DVDCentral.PL.Test
{
    [TestClass]
    public class utGenre
    {
        [TestMethod]
        public void LoadTest()
        {
            DVDCentralEntities dc = new DVDCentralEntities();

            //SELECT * FROM tblGenre - LINQ SQL
            var results = from genre in dc.tblGenres
                          select genre;

            int expected = 12;
            int actual = results.Count();

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void InsertTest()
        {
            using(DVDCentralEntities dc = new DVDCentralEntities())
            {
                //Make new Genre
                tblGenre newrow = new tblGenre();

                //Set the column values
                newrow.Id = -99;
                newrow.Description = "Test";

                //Add the Row
                dc.tblGenres.Add(newrow);

                //Save the Changes
                int results = dc.SaveChanges();

                Assert.IsTrue(results > 0);
            }
        }
    }
}
