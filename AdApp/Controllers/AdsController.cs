using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdApp.Models;
using AdsAppLogic;
using Microsoft.AspNetCore.Mvc;

namespace AdApp.Controllers
{
    public class AdsController : Controller
    {
        private AdManager _adManager;
        private CategoryManager _categoryManager;

        public AdsController(CategoryManager categoryManager, AdManager adManager)
        {
            _categoryManager = categoryManager; //seit sanem parametru categoryManager, kas tiek noradits ka visu sanemt startup klase 
            //uzsakot programmu tiek izveidots category manager kas tiek padots saja klasee, jo tas ir nodefinets startup klase
            _adManager = adManager;
        }

        public IActionResult CategoryAds(int id)
        {
            var ads = _adManager.GetByCategoryId(id);

            return View(ads);
        }

        public IActionResult Ad(int id)  //get metode
        {
            return View(_adManager.Get(id)); //nenorada view uz kuru iet, jo metodei 
        }

        public IActionResult AddNew() //sanemsanas metode/ vienads nosaukums, lai saprastu ka viena html atrodas
        {
            var model = new AdModel();
            model.Email = HttpContext.Session.GetUserEmail();
            model.Categories = _categoryManager.GetAll();
            return View(model);
        }

        [HttpPost]
        public IActionResult AddNew(AdModel model)
        {
            model.Categories = _categoryManager.GetAll(); //velreiz bija jaizveido sarakstu, jo pievienojot jaunu ad neparadas visas kategorijas, ja ir kada kluda (return)

            if (ModelState.IsValid)
            {
                int newId = _adManager.Create(new Ad()
                {
                    CategoryId = model.CategoryId,
                    Title = model.Title,
                    Description = model.Description,
                    Price = model.Price,
                    Place = model.Place,
                    Phone= model.Phone,
                    Photo = model.Photo,
                    Email = model.Email,
                    Placed = DateTime.Now
                }).Id;
                TempData["message"] = "Ad successfully added!";
                return RedirectToAction("Ad", "Ads", new { id = newId });
            }
            else
            {
                TempData["message"] = "Error occured while adding your new ad";
                return View(model);
            }
        }

        public IActionResult UserAds()
        {
            string email = HttpContext.Session.GetUserEmail();
            return View(_adManager.GetUserAds(email));
        }

        public IActionResult Delete(int id)
        {
            _adManager.Delete(_adManager.Get(id).Id);
            TempData["message"] = "Add deleted";
            return RedirectToAction("UserAds", "Ads");
        }
    }
}