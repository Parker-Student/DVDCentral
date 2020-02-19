using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PF.DVDCentral.BL;
using PF.DVDCentral.BL.Models;

namespace PF.DVDCentral.BL.Test
{
    [TestClass]
    public class utFormat
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
            List<Format> genres = FormatManager.Load();
            Assert.AreEqual(3, genres.Count);
        }

        public void InsertTest()
        {
           Format genre = new Format { Description = "Horror" };
           Assert.AreNotEqual(0, FormatManager.Insert(genre));
           
        }
        public void UpdateTest()
        {
            Format genre = FormatManager.LoadById(4);
            genre.Description = "Updated";
            Assert.IsTrue(FormatManager.Update(genre) > 0);
        }

        public void DeleteTest()
        {
            Assert.IsTrue(FormatManager.Delete(4) > 0);
        }
    }

}
