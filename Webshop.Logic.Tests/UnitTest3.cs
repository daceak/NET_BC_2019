using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebShop;

namespace Webshop.Logic.Tests
{
    /// <summary>
    /// Unit Tests for UserManager
    /// </summary>
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void TestGetByEmail()
        {
            UserManager manager = new UserManager();
            manager.Seed();
            Assert.AreEqual("e@l.lv", manager.GetByEmail("e@l.lv").Email); //salidzina ar vertibu no seed vertibas pret to, kas sanaca pielietojot metodi testa
        }

        [TestMethod]
        public void TestGetByEmailAndPassword()
        {
            UserManager manager = new UserManager();
            manager.Seed();
            manager.GetByEmailAndPassword("d@l.lv", "1234");
            Assert.AreEqual("1234", manager.GetByEmail("d@l.lv").Password); //salidzina ar vertibu no seed vertibas pret to, kas sanaca pielietojot metodi testa
        }

        [TestMethod]
        public void TestUpdate()
        {
            UserManager manager = new UserManager();
            manager.Seed();
            User updated = manager.GetByEmail("e@l.lv"); //also tests Get method
            updated.Password = "321";
            manager.Update(updated);

            Assert.AreNotEqual("4321", manager.Users.Find(u => u.Email == "e@l.lv"));
            Assert.AreEqual("321", manager.GetByEmail("e@l.lv").Password);
        }

        [TestMethod]
        public void TestDeleteCreate()
        {
            UserManager manager = new UserManager();
            manager.Seed();
            manager.Delete(2);
            manager.Create(new User()
            {
                Email = "new@n.lv",
                Password = "123"
            });

            Assert.IsNull(manager.GetByEmail("e@l.lv")); //object item should be empty with this id
            Assert.AreEqual("new@n.lv", manager.Users.Find(i => i.Password == "123").Email);
        }
    }
}
