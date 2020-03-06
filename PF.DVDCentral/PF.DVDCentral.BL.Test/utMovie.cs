using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PF.DVDCentral.BL;
using PF.DVDCentral.BL.Models;

namespace PF.DVDCentral.BL.Test
{
    [TestClass]
    public class utMovie
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
            List<Movie> genres = MovieManager.Load();
            Assert.AreEqual(3, genres.Count);
        }

        public void InsertTest()
        {
           Movie genre = new Movie { Description = "Horror" };
           Assert.AreNotEqual(0, MovieManager.Insert(genre));
           
        }
        public void UpdateTest()
        {
            Movie genre = MovieManager.LoadById(4);
            genre.Description = "Updated";
            Assert.IsTrue(MovieManager.Update(genre) > 0);
        }

        public void DeleteTest()
        {
            Assert.IsTrue(MovieManager.Delete(4) > 0);
        }
    }

}
