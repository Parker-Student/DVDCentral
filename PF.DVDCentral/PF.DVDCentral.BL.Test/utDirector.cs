using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PF.DVDCentral.BL;
using PF.DVDCentral.BL.Models;

namespace PF.DVDCentral.BL.Test
{
    [TestClass]
    public class utDirector
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
            List<Director> directors = DirectorManager.Load();
            Assert.AreEqual(3, directors.Count);
        }

        public void InsertTest()
        {
           Director director = new Director { FirstName = "test", LastName = "test" };
           Assert.AreNotEqual(0, DirectorManager.Insert(director));
           
        }
        public void UpdateTest()
        {
            Director director = DirectorManager.LoadById(4);
            director.FirstName = "Updated";
            director.LastName = "Updated";
            Assert.IsTrue(DirectorManager.Update(director) > 0);
        }

        public void DeleteTest()
        {
            Assert.IsTrue(DirectorManager.Delete(4) > 0);
        }
    }

}
