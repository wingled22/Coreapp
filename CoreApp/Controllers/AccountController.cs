using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CoreApp.Entities;
using CoreApp.Models;
using CoreApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMapper _mapper;
        private readonly capstoneContext _context;
        private readonly IAccountRepository _accountRepository;

        public AccountController(IMapper mapper, capstoneContext context, IAccountRepository accountRepository)
        {
            _mapper = mapper;
            _context = context;
            _accountRepository = accountRepository;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(UserRegistrationModel userModel)
        {
            if (ModelState.IsValid)
            {
                _accountRepository.Register(userModel);
                _context.SaveChanges();
                return RedirectToAction(nameof(AccountController.Login), "Account");
            }
            else
            {
                return View();
            }
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(UserLoginModel userLogin)
        {
            var loginInfo = _accountRepository.Login(userLogin);
            if(loginInfo != null)
            {
                HttpContext.Session.SetString("isLogIn", "true");
                HttpContext.Session.SetString("Id", loginInfo.Id.ToString());
                HttpContext.Session.SetString("Firstname", loginInfo.Firstname);
                HttpContext.Session.SetString("Lastname", loginInfo.Lastname);
                HttpContext.Session.SetString("Email", loginInfo.Email);
                HttpContext.Session.SetString("Fullname", loginInfo.Firstname+" "+loginInfo.Lastname);
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password.");
                return View();
            }
        }
    }
}
