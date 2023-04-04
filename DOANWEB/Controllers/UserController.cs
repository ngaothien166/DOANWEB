using DOANWEB.Common;
using DOANWEB.DataAddSet;
using DOANWEB.EF;
using DOANWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Xml.Linq;

namespace DOANWEB.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var das = new UserDAS();
                var result = das.Login(model.UserName, Encryptor.MD5Hash(model.Password), true);
                if (result == 1)
                {
                    var user = das.GetByUserName(model.UserName);
                    var usersession = new UserLogin();
                    usersession.UserName = user.UserName;
                    usersession.UserID = user.ID;
                    Session.Add(CommonConstants.USER_SESSION, usersession);
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
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
            }
            return View("Login");
        }
        public ActionResult Regedit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Regedit(RegeditModel regedit)
        {
            if (ModelState.IsValid)
            {
                var das = new UserDAS();
                var result = das.Regedit(regedit);
                if (result == 1)
                {
                    User user = new User();
                    var encryptedMd5Pas = Encryptor.MD5Hash(regedit.Password);
                    user.Password = encryptedMd5Pas;
                    user.CreateDate = DateTime.Now;
                    user.UserName = regedit.UserName;
                    user.Name = regedit.Name;
                    user.Status = true;

                    das.Insert(user);
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Xin vui lòng nhập đầy đủ thông tin");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Mật khẩu không trùng khớp");
                }
            }
            return View("Regedit");
        }
    }
}