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
        private CategoryManager _categories; //norada, ka izmantots dependency. butiba _categories ir category manager klase izveidota. pieejams visa saja klase (visam metodem)
        private ItemManager _itemManager; 

        public ItemController (CategoryManager categoryManager, ItemManager itemManager) //ar so konstruktoru katru reizi izsaucot so klasi tiks definets categoryManager
        {
            _categories = categoryManager; //seit sanem parametru categoryManager, kas tiek noradits ka visu sanemt startup klase 
            //uzsakot programmu tiek izveidots category manager kas tiek padots saja klasee, jo tas ir nodefinets startup klase
            _itemManager = itemManager;
        }

        public IActionResult Index(int id)
        {
            List<Item> items = _itemManager.GetByCategory(id);
            var allItems = _itemManager.GetAll(); //allItems prieks item skaita katra apkaskategorija

            List<Category> categories = _categories.GetAll();

          
            foreach (var cat in categories)
            {
                int count = allItems.Count(i => i.CategoryId == cat.Id);
                cat.ItemCount = count;  
            }

            var model = new CatalogModel()
            {
                Items = items,
                Categories = categories,   
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
            int categoryId = _itemManager.Get(id).CategoryId;
            return RedirectToAction("Index", "Item", new { id = categoryId }); //controller, action, parameter (CategoryManager)- var but vairaki
            //grozs dzesas pec sesijas, ja grib lai saglabajas, tad jaizmanto datubazes
            //Sesijas ilgums iebuvetais 1h, bet var mainit
        }

        public IActionResult Basket()
        {
            List<Item> items = new List<Item>();

            var basket = HttpContext.Session.GetUserBasket();

            if (basket != null)
            {

                foreach (var id in basket)
                {
                    items.Add(_itemManager.Get(id));
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