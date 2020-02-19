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
            List<Rating> genres = RatingManager.Load();
            Assert.AreEqual(3, genres.Count);
        }

        public void InsertTest()
        {
           Rating genre = new Rating { Description = "Horror" };
           Assert.AreNotEqual(0, RatingManager.Insert(genre));
           
        }
        public void UpdateTest()
        {
            Rating genre = RatingManager.LoadById(4);
            genre.Description = "Updated";
            Assert.IsTrue(RatingManager.Update(genre) > 0);
        }

        public void DeleteTest()
        {
            Assert.IsTrue(RatingManager.Delete(4) > 0);
        }
    }

}
