using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;
using Shopie.Common;
using PagedList;
namespace Shopie.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            

            var dao = new UserDao();
            var model = dao.ListAllPaging(page, pageSize);

            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var encryptedPW = Encrypt.MD5Hash(user.Password);
                user.Password = encryptedPW;

                long id = dao.Insert(user);
                if (id > 0)
                {
                    return RedirectToAction("Create", "User");           
                }
                else
                {
                    ModelState.AddModelError("", "Thêm User không thành công");
                }

            }
            return View("Index");

        }
    }
}