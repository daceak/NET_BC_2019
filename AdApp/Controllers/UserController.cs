using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// delete- using AdApp.Extensions;
using AdApp.Models;
using AdsAppLogic;
using Microsoft.AspNetCore.Mvc;

namespace AdApp.Controllers
{
    public class UserController : Controller

        //jaunam projektamStartup klase japievieno AddSession un Usesession !!! 
        //Delete using.adApp Extensions in using
    {
        private UserManager _userManager;

        public UserController(UserManager userManager)
        {
            _userManager = userManager; //seit sanem parametru categoryManager, kas tiek noradits ka visu sanemt startup klase 

        }

        public IActionResult Index()
        {         
            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost] //ar so norada, ka atskiriga funkcija no ieprieksejas ar tadu pasu nosaukumu
        public IActionResult SignUp(SignUpModel model)
        {
            if (ModelState.IsValid)
            {
                if (_userManager.GetByEmail(model.Email) != null)
                {
                    ModelState.AddModelError("error", "Email already exists!"); //userModel parbauda nosacijumus
                }
                else
                {
                    _userManager.Create(new User()
                    {
                        Email = model.Email,
                        Password = model.Password,
                    });
                    TempData["message"] = "Account created"; //pat ja nosuta uz citu lapu tapat saglaba ievaditos datus- temporary
                    return RedirectToAction("SignIn"); //parsuta uz citu lapu (view) pec nosaukuma
                }
            }
            return View();
        }

        [HttpPost] //so liek tikai metodem, kur ienaks dati (form)
        public IActionResult SignIn(SignInModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.GetByEmailAndPassword(model.Email, model.Password);
                if (user == null)
                {
                    ModelState.AddModelError("error2", "Email not found, try again or go to Sign up to create a new user!"); //userModel parbauda nosacijumus
                }
                else
                {
                    HttpContext.Session.SetUserId(user.Id);
                    HttpContext.Session.SetUserEmail(user.Email);
                    TempData["message"] = "Sign in successful"; //pat ja nosuta uz citu lapu tapat saglaba ievaditos datus- temporary
                    return RedirectToAction("Categories", "Category"); //darbiba index no kontroliera item
                }
            }

            return View();
        }

        public IActionResult SignOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Categories", "Category");
        }
    }
}