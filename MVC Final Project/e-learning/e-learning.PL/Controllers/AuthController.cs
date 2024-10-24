using e_learning.DAL.Models;
using e_learning.PL.Helpers;
using e_learning.PL.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NuGet.Common;
using System.Runtime.InteropServices;
using System.Web;

namespace e_learning.PL.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AuthController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }



        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    UserName = registerViewModel.Name,
                    Email = registerViewModel.Email,

                };
               
                var result= await userManager.CreateAsync(user,registerViewModel.Password);
                if (result.Succeeded)
                {
                    var Token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    var confirmedEmailLink = Url.Action(
                        "ConfirmEmail",
                        "Auth",
                        new { UserId = user.Id, Token= Token },
                        //"https", "localhost:7244"
                        protocol:HttpContext.Request.Scheme
                        );
                    var email = new Email()
                    {
                        Subject = "Confirm Email",
                        Receivers = registerViewModel.Email,
                        Body =$"Please confirm your email by clicking on below link :{confirmedEmailLink}"
                    };
                    EmailSettings.SendEmail(email);

                    return View(nameof(ConfirmEmail));
                }
                
            }

            return View(registerViewModel);
        }

     
        public async Task<IActionResult> ConfirmEmail(string UserId,string Token)
        {
            if(UserId==null || Token == null)
            {
                return RedirectToAction("Error", "Home");
            }
            var user =await userManager.FindByIdAsync(UserId);
            if (user is not null)
            {

               var result= await userManager.ConfirmEmailAsync(user, Token); // it will make the ConfirmEmail proprty=true
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Login));
                }
            }
            return RedirectToAction("Error", "Home");
        }





       [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var user =await userManager.FindByEmailAsync(loginViewModel.Email);
                if (user !=null)
                {
                    var checkPassword =await userManager.CheckPasswordAsync(user, loginViewModel.Password);
                
                if (checkPassword)
                {
                    var result=await signInManager.PasswordSignInAsync(user,loginViewModel.Password,loginViewModel.RememberMe,false);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                }
                }
            }
            return View(loginViewModel);
        }

        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }


        public async Task<IActionResult> SendResetPasswordUrl(ForgetPasswordViewModel forgetPasswordViewModel)
        {
            if (ModelState.IsValid)
            {
              
                var user = await userManager.FindByEmailAsync(forgetPasswordViewModel.Email);
                if (user is not null)
                {
                    var token =await userManager.GeneratePasswordResetTokenAsync(user);
                    var resetPasswordUrl = Url.Action(nameof(ResetPassword), "Auth",
                        new {Email=forgetPasswordViewModel.Email,Token=token},"https", "localhost:7244");

                    var email = new Email()
                    {
                        Subject = "Reset Password",
                        Body = resetPasswordUrl,
                        Receivers = forgetPasswordViewModel.Email
                    };
                    EmailSettings.SendEmail(email);
                }
            }
                return View(forgetPasswordViewModel);
        }

        public IActionResult ResetPassword(string email,string token)
        {
            var model = new ResetPasswordViewModel
            {
                Email = email,
                Token = token
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            var user = await userManager.FindByEmailAsync(resetPasswordViewModel.Email);
            if(user is not null)
            {
             var result=await userManager.ResetPasswordAsync(user, resetPasswordViewModel.Token,
                 resetPasswordViewModel.NewPassword);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Login));
                }
            }
            return View(resetPasswordViewModel);

           
        }




    }
}
