using DOANWEB.DataAddSet;
using DOANWEB.EF;
using DOANWEB.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOANWEB.Areas.Admin.Controllers
{
    public class UsersController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(string searchString, int page = 1, int pageSize = 200)
        {
            var das = new UserDAS();
            var model = das.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new UserDAS().Delete(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult AddUserAjax(string username, string name, string password, string address, string email, string phone)
        {
            try
            {
                var das = new UserDAS();
                User user = new User();

                var encryptedMd5Pas = Encryptor.MD5Hash(password);
                user.Password = encryptedMd5Pas;
                user.CreateDate = DateTime.Now;
                user.UserName = username;
                user.Name = name;
                user.Address = address;
                user.Email = email;
                user.Phone = phone;
                user.Status = true;

                long id = das.Insert(user);
                if (id > 0)
                {
                    return Json(new { status = true });
                }
                else
                {
                    return Json(new { status = false });
                }
            }
            catch
            {
                return Json(new { status = false });
            }
        }

        [HttpPost]
        public JsonResult UpdateUserAjax(string userid, string name, string address, string email, string phone)
        {
            try
            {
                var das = new UserDAS();
                User user = new User();

                user = das.ViewDetail(Convert.ToInt16(userid));

                user.Name = name;
                user.Address = address;
                user.Email = email;
                user.Phone = phone;


                bool editresult = das.Update(user);

                if (editresult == true)
                {
                    return Json(new { status = true });
                }
                else
                {
                    return Json(new { status = false });
                }
            }
            catch
            {
                return Json(new
                {
                    status = false
                });
            }
        }
    }
}