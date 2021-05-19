using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airlines.ApplicationCore.Constants;
using Airlines.Infrastructure.Identity;
using Airlines.Web.Models.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Airlines.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        
        // GET: Account/Registration
        public ActionResult Registration()
        {
            RegistrationViewModel registrationInput = new RegistrationViewModel
            {
                ReturnUrl = Request.Headers["Referer"].ToString() ?? "/"
            };
            
            return View(registrationInput);
        }

        // POST: Account/Registration
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration(RegistrationViewModel registrationInput)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = registrationInput.Email,
                    Email = registrationInput.Email, 
                    Name = registrationInput.Name,
                    Surname = registrationInput.Surname,
                    Patronymic = registrationInput.Patronymic
                };
                var result = await _userManager.CreateAsync(user, registrationInput.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Roles.USERS);
                    if (!string.IsNullOrEmpty(registrationInput.ReturnUrl))
                        return Redirect(registrationInput.ReturnUrl);
                    
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Помилка реєстрації.");
                    return View();
                }
            }
            
            return View();
        }
        
        // GET: Account/Login
        public ActionResult Login()
        {
            LoginViewModel loginInput = new LoginViewModel
            {
                ReturnUrl = Request.Headers["Referer"].ToString() ?? "/"
            };
            
            return View(loginInput);
        }
        
        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginInput)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginInput.Email, loginInput.Password, loginInput.Remember, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(loginInput.ReturnUrl))
                        return Redirect(loginInput.ReturnUrl);
                    
                    return RedirectToAction("Index", "Home");
                }
                if (result.IsLockedOut)
                {
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Ви ввели неправильний логін або пароль.");
                    return View();
                }
            }
            
            return View();
        }
        
        // POST: Account/Logout
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return Redirect(Request.Headers["Referer"].ToString() ?? "/");
        }
    }
}