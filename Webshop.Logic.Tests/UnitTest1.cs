using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebShop;

namespace Webshop.Logic.Tests
{
    /// <summary>
    /// Unit Tests for ItemManager
    /// </summary>
    [TestClass]
    public class UnitTest1 //Add reference to the other project to be able to test. When underlined error-quick actions- using referenced project
    {
        [TestMethod]
        public void TestGetByCategory()
        {
            ItemManager manager = new ItemManager();
            manager.Seed();
            var result = manager.GetByCategory(4);

            Assert.AreEqual("Test Title 2", result[0].Title); //salidzina ar vertibu no seed vertibas pret to, kas sanaca pielietojot metodi testa
        }

       [TestMethod]
       public void TestUpdate()
        {
            ItemManager manager = new ItemManager();
            manager.Seed();
            Item updated = manager.Get(1); //also tests Get method
            updated.Title = "New Title";
            manager.Update(updated);

            Assert.AreNotEqual("Test Title 1", manager.Get(1).Title);
            Assert.AreEqual("New Title", manager.Get(1).Title);
        }

        [TestMethod]
        public void TestDeleteCreate()
        {
            ItemManager manager = new ItemManager();
            manager.Seed();
            manager.Delete(manager.Get(1));
            manager.Create(new Item()
            {
                Title = "created",
                Price = 11.22
            });

            Assert.IsNull(manager.Get(1)); //object item should be empty with this id
            Assert.AreEqual("created", manager.Items.Find(i => i.Price == 11.22).Title); 
        }
    }
}
