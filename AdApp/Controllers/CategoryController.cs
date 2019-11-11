using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdsAppLogic;
using Microsoft.AspNetCore.Mvc;

namespace AdApp.Controllers
{
    public class CategoryController : Controller //startup klase beigas var nomainit default lapu, kas atveras atverot lapu
    {
        private AdManager _adManager;
        private CategoryManager _categoryManager;

        public CategoryController(CategoryManager categoryManager, AdManager adManager)
        {
            _categoryManager = categoryManager; //seit sanem parametru categoryManager, kas tiek noradits ka visu sanemt startup klase 
            //uzsakot programmu tiek izveidots category manager kas tiek padots saja klasee, jo tas ir nodefinets startup klase
            _adManager = adManager;
        }

        public IActionResult Categories()
        {

            var categories = _categoryManager.GetAll();

            var allAds = _adManager.GetAll();

            foreach(var cat in categories)
            {
                var count = allAds.Count(c => c.CategoryId == cat.Id);
                cat.AdCount = count;
            }

            return View(categories);
        }
    }
}