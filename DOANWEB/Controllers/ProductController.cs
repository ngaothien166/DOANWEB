using DOANWEB.DataAddSet;
using DOANWEB.EF;
using DOANWEB.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOANWEB.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Category(string searchString, long cateId)
        {
            var category = new ProductCategoryDAS().ViewDetail(cateId);
            ViewBag.Category = category;
            ViewBag.CategoryID = new ProductCategoryDAS().ListAll();
            var model = new ProductDAS().ListByCategoryID(searchString, cateId);

            return View(model);
        }

        public ActionResult Detail(long id, long detailid)
        {
            var product = new ProductDAS().ViewDetail(id);
            ViewBag.CategoryID = new ProductCategoryDAS().ListAll();

            var sessionUser = (UserLogin)Session[CommonConstants.USER_SESSION];
            ViewBag.UserID = sessionUser.UserID;

            ViewBag.DetailID = detailid.ToString();
            return View(product);
        }
    }
}