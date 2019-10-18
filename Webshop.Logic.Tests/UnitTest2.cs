using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebShop;

namespace Webshop.Logic.Tests
{
    /// <summary>
    /// Unit Tests for CategoryManager
    /// </summary>
    [TestClass]
    public class UnitTest2
    {

        [TestMethod]
        public void TestGet()
        {
            CategoryManager manager = new CategoryManager();
            manager.Seed();
            Assert.AreEqual("Test category 1", manager.Get(3).Title); //salidzina ar vertibu no seed vertibas pret to, kas sanaca pielietojot metodi testa
        }

        [TestMethod]
        public void TestCreate()
        {
            CategoryManager manager = new CategoryManager();
            manager.Create(new Category()
            {
                Title = "new category",
                CategoryId = 22
            });

            Assert.IsNotNull(manager.Categories.Find(c => c.CategoryId == 22).Id);
            Assert.AreEqual("new category", manager.Categories.Find(i => i.CategoryId == 22).Title);
            Assert.IsTrue(manager.Categories.Count > 0);
            Assert.IsNotNull(manager.GetAll());

        }
    }
}

