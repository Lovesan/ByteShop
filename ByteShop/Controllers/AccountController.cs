using ByteShop.Models.Security;
using ByteShop.Models.Security.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ByteShop.Controllers
{
    [AllowAnonymous]
    public class AccountController :Controller
    {
        [HttpPost]
        public ActionResult Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.Email, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.Email, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "");
                    }
                } 
                else
                {
                    ModelState.AddModelError("", "Аутентификация не пройдена. Неправильный логин или пароль.");
                }
            }
            else
            {
                ModelState.AddModelError("", "Некоторые поля не заполнены.");
            }
            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                MembershipUser membershipUser = ((ByteShopMembershipProvider)Membership.Provider).CreateUser(model.Email, model.Password, model.FirstName, model.BirthDate);

                if (membershipUser != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, false);
                    return RedirectToAction("Index", "");
                }
            }
            else
            {
                ModelState.AddModelError("", "Registration error");
            }
            return View(model);
        }
    }
}