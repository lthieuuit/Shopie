using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopie.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detail(long id)
        {
            var product = new ProductDao().ViewDetail(id);
            ViewBag.Category = new ProductCategoryDao().ViewDetail(product.CategoryID.Value);
            return View(product);
        }
    }
}