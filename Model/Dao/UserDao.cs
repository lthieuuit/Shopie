using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
namespace Model.Dao
{
    public class UserDao
    {
        OnlineShopDbContext db;
        public UserDao()
        {
            db = new OnlineShopDbContext();
        }
        public long Insert (User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Update(User uSer)
        {
            try
            {
                var user = db.Users.Find(uSer.ID);
                user.Name = uSer.Name;
                user.Address = uSer.Address;
                user.Email = uSer.Email;
                user.ModifiedBy = uSer.ModifiedBy;
                user.ModifiedDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
            
        }

        public IEnumerable<User> ListAllPaging(int page, int pageSize)
        {
            return db.Users.OrderByDescending(x=>x.ID).ToPagedList(page,pageSize);
        }

        public User GetByID(string userName)
        {
            return db.Users.FirstOrDefault(x => x.UserName == userName);
        }
        
        public User ViewDetails(int id)
        {
            return db.Users.Find(id);
        }

        public int Login(string userName, string passWord)
        {
            var result = db.Users.FirstOrDefault(x => x.UserName == userName);
            if (result == null)
            {
                return 0;
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
                    {
                        return 1;
                    }
                    else return -2;
                }
            }

        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

}
