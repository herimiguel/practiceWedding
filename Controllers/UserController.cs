using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using weddingPlanner.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace weddingPlanner.Controllers
{

    public class UserController : Controller
    {
        private Context _context;

        public UserController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult LogReg()
        {
            ViewBag.Login = new LoginViewModel();
            return View();
        }

        [HttpPost]
        [Route("processregister")]
        public IActionResult ProcessRegister(RegisterViewModel model){
            if(ModelState.IsValid){
                User currUser = _context.Users.SingleOrDefault(user => user.email == model.email);
                if(currUser != null){
                    ModelState.AddModelError("email", "There is already a registered user with that email.");
                    return View("LogReg", model);
                }
                User newUser = new User
                {
                    first_name = model.first_name,
                    last_name = model.last_name,
                    email = model.email,
                    password = model.password,    
                };
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.password = Hasher.HashPassword(newUser, newUser.password);
                _context.Users.Add(newUser);
                _context.SaveChanges();
                currUser = _context.Users.SingleOrDefault(user => user.email == newUser.email);
                HttpContext.Session.SetInt32("CurrUser", currUser.UserId);
                return RedirectToAction("Dashboard", "Wedding");
            }
            return View("LogReg", model);

        }

        [HttpPost]
        [Route("processlogin")]
        public IActionResult ProcessLogin(LoginViewModel model){
            User currUser = _context.Users.SingleOrDefault(user => user.email == model.email);
            if(currUser != null && model.password != null)
            {
                var Hasher = new PasswordHasher<User>();
                if(0 != Hasher.VerifyHashedPassword(currUser, currUser.password, model.password)){
                    HttpContext.Session.SetInt32("CurrUser", currUser.UserId);
                    return RedirectToAction("Dashboard", "Wedding");
                }
                else {
                    ModelState.AddModelError("password", "Incorrect Password");
                }
            } else if (currUser == null){
                ModelState.AddModelError("email", "User Not Found");
            }
            return View("LogReg", model);
        }

        [HttpGet]
        [Route("logout")]
        public IActionResult Logout(){
            HttpContext.Session.Clear();
            return RedirectToAction("LogReg");
        }
    }
}