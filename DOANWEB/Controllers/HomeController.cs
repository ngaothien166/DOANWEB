using DOANWEB.DataAddSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOANWEB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var das = new ProductCategoryDAS();
            ViewBag.CategoryID = das.ListAll();
            var productdas = new ProductDAS();
            ViewBag.HomeProducts = productdas.ListAllProduct();

            return View();
        }
    }
}