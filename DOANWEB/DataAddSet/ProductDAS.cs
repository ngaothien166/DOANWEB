using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DOANWEB.EF;
using PagedList;
using System.Web;

namespace DOANWEB.DataAddSet
{
    public class ProductDAS
    {
        MyData db = null;
        public ProductDAS()
        {
            db = new MyData();
        }
        public IEnumerable<Product> ListAllPaging(long cateID, string searchString, int page, int pagesize)
        {
            IQueryable<Product> model = db.Product;
            if (cateID != -1)
            {
                model = model.Where(x => x.CategoryID == cateID);
            }
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.MetaTitle.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pagesize);
        }
        public bool Delete(int id)
        {
            try
            {
                var product = db.Product.Find(id);
                db.Product.Remove(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public long Insert(Product entity)
        {
            db.Product.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public Product ViewDetail(long id)
        {

            return db.Product.Find(id);
        }
        public bool Update(Product entity)
        {
            try
            {
                var product = db.Product.Find(entity.ID);
                product.Name = entity.Name;
                product.Code = entity.Code;
                product.MetaTitle = entity.MetaTitle;
                product.Description = entity.Description;
                product.Detail = entity.Detail;
                product.Image = entity.Image;
                product.ListType = entity.ListType;
                product.ListFile = entity.ListFile;
                product.CategoryID = entity.CategoryID;

                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;

            }
        }
        public List<Product> ListAllProduct()
        {
            return db.Product.Where(x => x.Status == true).OrderByDescending(x => x.ID).ToList();
        }
        public List<Product> ListByCategoryID(string searchString, long CategoryID)
        {
            IOrderedQueryable<Product> model = db.Product;
            if (CategoryID == 0)
            {
                if (!string.IsNullOrEmpty(searchString))
                {
                    return model.Where(x => x.Name.Contains(searchString) || x.Description.Contains(searchString)).Where(x => x.Status).OrderByDescending(x => x.CreateDate).ToList();
                }
                else
                {
                    return model.Where(x => x.Status).OrderByDescending(x => x.CreateDate).ToList();
                }

            }
            else
            {
                if (!string.IsNullOrEmpty(searchString))
                {
                    return model.Where(x => x.Name.Contains(searchString) || x.Description.Contains(searchString)).Where(x => x.Status && x.CategoryID == CategoryID).OrderByDescending(x => x.CreateDate).ToList();
                }
                else
                {
                    return model.Where(x => x.Status && x.CategoryID == CategoryID).OrderByDescending(x => x.CreateDate).ToList();
                }
            }


        }
    }
}