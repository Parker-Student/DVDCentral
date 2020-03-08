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
            List<Movie> movies = MovieManager.Load();
            Assert.AreEqual(3, movies.Count);
        }

        public void InsertTest()
        {
           Movie movie = new Movie { Description = "test", Title = "Test", Cost = 1, ImagePath = "Test", RatingsId = -1, DirectorId = -1, FormatId = -1, InStockQty = -1};
           Assert.AreNotEqual(0, MovieManager.Insert(movie));
           
        }
        public void UpdateTest()
        {
            Movie movie = MovieManager.LoadById(4);
            movie.Description = "Updated";
            Assert.IsTrue(MovieManager.Update(movie) > 0);
        }

        public void DeleteTest()
        {
            Assert.IsTrue(MovieManager.Delete(4) > 0);
        }
    }

}
