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
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        public ActionResult Index(string dropdownid, string searchString, int page = 1, int pageSize = 200)
        {
            var das = new ProductDAS();
            if (dropdownid == null)
            {
                dropdownid = "-1";
            }
            var model = das.ListAllPaging(Convert.ToInt16(dropdownid), searchString, page, pageSize);

            ViewBag.SearchString = searchString;
            ViewBag.DropDownID = dropdownid;
            SetViewBag();
            return View(model);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new ProductDAS().Delete(id);
            return RedirectToAction("Index");
        }
        public void SetViewBag(long? selectedId = null)
        {
            var das = new ProductCategoryDAS();
            ViewBag.CategoryID = das.ListAll();

        }

        [HttpPost]
        public JsonResult AddProductAjax(string name, string code, string metatitle, string description, string image, string categoryid, string detail,
            string listtype, string listfile)
        {
            try
            {
                var das = new ProductDAS();
                Product product = new Product();


                product.Name = name;
                product.CreateDate = DateTime.Now;
                product.Code = code;
                product.MetaTitle = metatitle;
                product.Description = description;
                product.Image = image;
                product.CategoryID = Convert.ToInt16(categoryid);
                product.Status = true;
                product.Detail = detail;
                product.ListType = listtype;
                product.ListFile = listfile;

                long id = das.Insert(product);
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
                return Json(new
                {
                    status = false
                });
            }
        }
        [HttpPost]
        public JsonResult UpdateProductAjax(long id, string name, string code, string metatitle, string description, string detail, string image, string listtype, string listfile, string categoryid)
        {
            try
            {
                var das = new ProductDAS();
                Product product = new Product();

                product = das.ViewDetail(Convert.ToInt16(id));
                product.Name = name;
                product.ModifieDate = DateTime.Now;
                product.Code = code;
                product.MetaTitle = metatitle;
                product.Description = description;
                product.Image = image;

                if (detail.Length > 5)
                {
                    product.Detail = detail;
                }

                product.ListType = listtype;
                product.ListFile = listfile;
                product.CategoryID = Convert.ToInt16(categoryid);

                bool editresult = das.Update(product);
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