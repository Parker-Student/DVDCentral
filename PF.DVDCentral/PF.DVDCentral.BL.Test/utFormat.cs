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
            List<Format> format = FormatManager.Load();
            Assert.AreEqual(3, format.Count);
        }

        public void InsertTest()
        {
           Format format = new Format { Description = "HD" };
           Assert.AreNotEqual(0, FormatManager.Insert(format));
           
        }
        public void UpdateTest()
        {
            Format format = FormatManager.LoadById(3);
            format.Description = "Updated";
            Assert.IsTrue(FormatManager.Update(format) > 0);
        }

        public void DeleteTest()
        {
            Assert.IsTrue(FormatManager.Delete(3) > 0);
        }
    }

}
