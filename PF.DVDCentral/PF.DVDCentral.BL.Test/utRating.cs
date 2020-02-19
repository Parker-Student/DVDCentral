using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PF.DVDCentral.BL;
using PF.DVDCentral.BL.Models;

namespace PF.DVDCentral.BL.Test
{
    [TestClass]
    public class utGenre
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
            List<Genre> genres = GenreManager.Load();
            Assert.AreEqual(3, genres.Count);
        }

        public void InsertTest()
        {
           Genre genre = new Genre { Description = "Horror" };
           Assert.AreNotEqual(0, GenreManager.Insert(genre));
           
        }
        public void UpdateTest()
        {
            Genre genre = GenreManager.LoadById(4);
            genre.Description = "Updated";
            Assert.IsTrue(GenreManager.Update(genre) > 0);
        }

        public void DeleteTest()
        {
            Assert.IsTrue(GenreManager.Delete(4) > 0);
        }
    }

}
