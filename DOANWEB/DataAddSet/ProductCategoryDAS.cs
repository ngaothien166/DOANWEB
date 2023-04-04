using DOANWEB.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DOANWEB.EF;
using PagedList;
using System.Web;

namespace DOANWEB.DataAddSet
{
    public class ProductCategoryDAS
    {
        MyData db = null;
        public ProductCategoryDAS()
        {
            db = new MyData();
        }

        public List<ProductCategory> ListAll()
        {
            return db.ProductCategory.Where(x => x.Status == true).OrderBy(x => x.DisplayOder).ToList();
        }
        public ProductCategory ViewDetail(long id)
        {
            return db.ProductCategory.Find(id);
        }
    }
}