using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebShop;
using WebShopApp.Models;

namespace WebShopApp.Controllers
{
    public class ItemController : Controller
    {
        
        public IActionResult Index(int id)
        {
            var manager = new ItemManager();
            manager.Seed();

            var items = manager.GetByCategory(id);
            var allItems = manager.Items;

            var categoryManager = new CategoryManager();
            categoryManager.Seed();
            var categories = categoryManager.GetAll();
            var model = new CatalogModel()
            {
                Items = items,
                Categories = categories,
                AllItems = allItems,
            };
            return View(model);
        }

        public ActionResult Buy(int id)
        {
            var basket = HttpContext.Session.GetUserBasket(); //httpscontext session- iebuvetas klases metodes lai iegutu aktivo sesiju. get basket papildinajums iebuvetajai klasei
            if (basket == null)
            {
                basket = new List<int>();
            }
            basket.Add(id);
            HttpContext.Session.SetUserBasket(basket);
            ItemManager manager = new ItemManager();
            manager.Seed();
            int categoryId = manager.Get(id).CategoryId;
            return RedirectToAction("Index", "Item", new { id = categoryId }); //controller, action, parameter (CategoryManager)
            //grozs dzesas pec sesijas, ja grib lai saglabajas, tad jaizmanto datubazes
            //Sesijas ilgums iebuvetais 1h, bet var mainit
        }

        public IActionResult Basket()
        {
            List<Item> items = new List<Item>();

            var basket = HttpContext.Session.GetUserBasket();

            if (basket != null)
            {
                var manager = new ItemManager();
                manager.Seed(); //so nonemt kad bus datubaze
                foreach (var id in basket)
                {
                    items.Add(manager.Get(id));
                }

            }
            return View(items);
        }

        public IActionResult Delete(int id)
        {
            List<int> items = new List<int>();

            var basket = HttpContext.Session.GetUserBasket();

            foreach (var itemId in basket)
            {

                //if (itemId != id)
                //{
                items.Add(itemId);
                //}
                /*else if (itemId == id && basket.Count(i => i == id) > 1)
                {
                    items.Add(itemId);
                    items.Remove(itemId);
                }*/

            }
            if (basket.Count(i => i == id) == items.Count(i => i == id))
            {
                items.Remove(items.FindLast(i => i == id));
            }

            basket = items;

            HttpContext.Session.SetUserBasket(basket);
            return RedirectToAction("Basket", "Item");
        }
    }
}