using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PF.DVDCentral.BL;
using PF.DVDCentral.BL.Models;

namespace PF.DVDCentral.BL.Test
{
    [TestClass]
    public class utRating
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
            List<Rating> ratings = RatingManager.Load();
            Assert.AreEqual(4, ratings.Count);
        }

        public void InsertTest()
        {
           Rating rating = new Rating { Description = "PG" };
           Assert.AreNotEqual(0, RatingManager.Insert(rating));
           
        }
        public void UpdateTest()
        {
            Rating rating = RatingManager.LoadById(4);
            rating.Description = "Updated";
            Assert.IsTrue(RatingManager.Update(rating) > 0);
        }

        public void DeleteTest()
        {
            Assert.IsTrue(RatingManager.Delete(4) > 0);
        }
    }

}
