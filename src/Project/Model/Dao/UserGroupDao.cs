using Model.Data;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class UserGroupDao
    {
        OnlineShopDbContext db = null;

        public UserGroupDao()
        {
            db = new OnlineShopDbContext();
        }

        public string Insert(UserGroup entity)
        {
            db.UserGroups.Add(entity);
            db.SaveChanges();
            return entity.idUserGroup;
        }

        public bool Update(UserGroup entity)
        {
            try
            {
                var mn = db.UserGroups.Find(entity.idUserGroup);
                mn.Name = entity.Name;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                var mn = db.UserGroups.Find(id);
                db.UserGroups.Remove(mn);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public UserGroup ViewDetail(string id)
        {
            return db.UserGroups.Find(id); //tìm kiếm theo khóa chính
        }

        public IEnumerable<UserGroup> ListAll(string searchString, int page, int pageSize)
        {
            IQueryable<UserGroup> model = db.UserGroups;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderBy(x => x.idUserGroup).ToPagedList(page, pageSize);
        }

        //check lỗi xóa dữ liệu
        public bool CheckInUse(string id)
        {
            if (!db.Users.Where(x => x.idUserGroup == id).ToList().Any())
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
