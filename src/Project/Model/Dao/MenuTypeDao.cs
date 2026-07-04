using Model.Data;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class MenuTypeDao
    {
        OnlineShopDbContext db = null;

        public MenuTypeDao()
        {
            db = new OnlineShopDbContext();
        }

        public int Insert(MenuType entity)
        {
            db.MenuTypes.Add(entity);
            db.SaveChanges();
            return entity.idMenuType;
        }

        public bool Update(MenuType entity)
        {
            try
            {
                var mn = db.MenuTypes.Find(entity.idMenuType);
                mn.Name = entity.Name;
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
                var mn = db.MenuTypes.Find(id);
                db.MenuTypes.Remove(mn);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public MenuType ViewDetail(int id)
        {
            return db.MenuTypes.Find(id); //tìm kiếm theo khóa chính
        }

        public IEnumerable<MenuType> ListAll(string searchString, int page, int pageSize)
        {
            IQueryable<MenuType> model = db.MenuTypes;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderBy(x => x.idMenuType).ToPagedList(page, pageSize);
        }

        //check lỗi xóa dữ liệu
        public bool CheckInUse(int id)
        {
            if (!db.Menus.Where(x => x.idMenuType == id).ToList().Any())
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
