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
        public IEnumerable<User> ListAllPaging(int page, int pageSize)
        {
            return db.Users.OrderByDescending(x=>x.ID).ToPagedList(page,pageSize);
        }
        public User GetByID(string userName)
        {
            return db.Users.FirstOrDefault(x => x.UserName == userName);
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
    }

}
