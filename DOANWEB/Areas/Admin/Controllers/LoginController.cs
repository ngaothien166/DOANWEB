using DOANWEB.Areas.Admin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DOANWEB.Common;
using DOANWEB.DataAddSet;

namespace DOANWEB.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var das = new UserDAS();
                var result = das.Login(model.UserName, Encryptor.MD5Hash(model.Password), true);
                if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tai");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khóa");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng");
                }
                else if (model.UserName != "admin" && model.UserName != "Admin")
                {
                    ModelState.AddModelError("", "Tài khoản không có quyền đăng nhập");
                }
                else if (result == 1)
                {
                    var user = das.GetByUserName(model.UserName);
                    var usersession = new UserLogin();
                    usersession.UserName = user.UserName;
                    usersession.UserID = user.ID;
                    Session.Add(CommonConstants.USER_SESSION, usersession);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View("Index");
        }
    }
}