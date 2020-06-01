using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.EF;
using Model.Dao;
using Shopie.Common;
using PagedList;
using System.Web.Mvc;

namespace Shopie.Areas.Admin.Controllers
{
    public class CustomersController:BaseController
    {
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new UserDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            var user = new UserDao().ViewDetails(id);
            return View(user);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new UserDao().Delete(id);
            return RedirectToAction("Customers");
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
                    return RedirectToAction("Customers", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm người dùng thành công");
                }

            }
            return RedirectToAction("Customers", "User");

        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (!string.IsNullOrEmpty(user.Password))
                {
                    var encryptedPW = Encrypt.MD5Hash(user.Password);
                    user.Password = encryptedPW;
                }

                var result = dao.Update(user);
                if (result)
                {
                    return RedirectToAction("Customers", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật thành công");
                }

            }
            return RedirectToAction("Customers", "User");

        }
    }
}