using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ByteShop.Models;
using ByteShop.ViewModels;

namespace ByteShop.Controllers
{

    public class MainController : Controller
    {

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Index()
        {
            return View(new EntityListViewModel
                {
                    Entities = new ByteShopDbContext()
                            .Entities
                            .Select(e => new EntityViewModel { Id = e.Id, Description = e.Description })
                            .ToList()
                });
        }

        [HttpPost]
        public ActionResult Create(string description)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (description != "")
                {
                    var ctx = new ByteShopDbContext();
                    var e = ctx.Entities.Add(new Entity { Description = description });
                    ctx.SaveChanges();
                    return Json(new EntityViewModel { Id = e.Id, Description = e.Description });
                }
                else
                {
                    HttpContext.Response.StatusCode = 500;
                    return new ContentResult() { Content = "Заполните поле." };
                }
            }
            else
            {
                //Видимо не работает без get запроса
                //ModelState.AddModelError("", "Вам не доступно это действие. Необходима регистрация.");
                HttpContext.Response.StatusCode = 500;
                return new ContentResult() { Content = "Вам не доступно это действие. Необходима регистрация." };
            }
        }

        //Можно ли обрабатывать доступ к ajax с помощью [Authorize]?
        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var ctx = new ByteShopDbContext();
                var entity = ctx.Entities.FirstOrDefault(e => e.Id == id);
                if (entity != null)
                    ctx.Entities.Remove(entity);
                ctx.SaveChanges();
                return Json(new { Status = "OK" });
            }
            else
            {
                HttpContext.Response.StatusCode = 500;
                return new ContentResult() { Content = "Вам не доступно это действие. Необходима регистрация." };
            }
        }

    }
}
