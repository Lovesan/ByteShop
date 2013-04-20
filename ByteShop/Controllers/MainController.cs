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
            var ctx = new ByteShopDbContext();
            var e = ctx.Entities.Add(new Entity { Description = description });
            ctx.SaveChanges();
            return Json(new EntityViewModel { Id = e.Id, Description = e.Description });
        }

    }
}
