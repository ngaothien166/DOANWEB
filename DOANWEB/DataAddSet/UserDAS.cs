using DOANWEB.EF;
using DOANWEB.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOANWEB.DataAddSet
{
    public class UserDAS
    {
        MyData db = null;
        public UserDAS()
        {
            db = new MyData();
        }
        public long Insert(User entity)
        {
            db.User.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(User entity)
        {
            try
            {
                var user = db.User.Find(entity.ID);
                user.Name = entity.Name;
                if (!string.IsNullOrEmpty(entity.Password))
                {
                    user.Password = entity.Password;
                }
                user.Address = entity.Address;
                user.Email = entity.Email;
                user.ModifieBy = entity.ModifieBy;
                user.ModifieBy = entity.ModifieBy;
                user.Status = entity.Status;
                user.Phone = entity.Phone;
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;

            }
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.User.Find(id);
                db.User.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public User GetByUserName(string username)
        {
            return db.User.SingleOrDefault(x => x.UserName == username);
        }
        public IEnumerable<User> ListAllPaging(string searchString, int page, int pagesize)
        {
            IQueryable<User> model = db.User;
            model = model.Where(x => x.UserName != "admin");
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString) || x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pagesize);
        }
        public User ViewDetail(int id)
        {

            return db.User.Find(id);
        }
        public int Login(string userName, string passWord, bool isLoginAdmin = false)
        {
            var result = db.User.SingleOrDefault(x => x.UserName == userName);
            if (result == null)
                return 0;
            else
            {
                if (isLoginAdmin == true)
                {
                    if (result.Status == false)
                    {
                        return -1;
                    }
                    else
                    {
                        if (result.Password == passWord)
                            return 1;
                        else
                            return -2;
                    }
                }
                else
                {
                    if (result.Status == false)
                    {
                        return -1;
                    }
                    else
                    {
                        if (result.Password == passWord)
                            return 1;
                        else
                            return -2;
                    }
                }
            }
        }
        public int Regedit(RegeditModel rege)
        {
            if (rege.Password == null || rege.UserName == null || rege.Name == null || rege.Password1 == null)
                return 0;
            else
            {
                if (rege.Password == rege.Password1)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
        }
    }
}