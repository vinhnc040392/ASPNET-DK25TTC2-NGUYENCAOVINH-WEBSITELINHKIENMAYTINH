using Model.Data;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class MenuDao
    {
        OnlineShopDbContext db = null;

        public MenuDao()
        {
            db = new OnlineShopDbContext();
        }

        public int Insert(Menu entity)
        {
            db.Menus.Add(entity);
            db.SaveChanges();
            return entity.idMenu;
        }

        public bool Update(Menu entity)
        {
            try
            {
                var mn = db.Menus.Find(entity.idMenu);
                mn.Text = entity.Text;
                mn.Link = entity.Link;
                mn.DisplayOrder = entity.DisplayOrder;
                mn.Target = entity.Target;
                mn.Status = entity.Status;
                mn.idMenuType = entity.idMenuType;
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
                var mn = db.Menus.Find(id);
                db.Menus.Remove(mn);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Menu ViewDetail(int id)
        {
            return db.Menus.Find(id); //tìm kiếm theo khóa chính
        }

        public IEnumerable<Menu> ListAll(string searchString, int page, int pageSize)
        {
            IQueryable<Menu> model = db.Menus;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Text.Contains(searchString));
            }
            return model.OrderBy(x => x.idMenu).ToPagedList(page, pageSize);
        }

        public List<MenuType> DropListMenuType()
        {
            return db.MenuTypes.ToList();
        }

        public List<Menu> ListByGroupId(int groupId)
        {
            return db.Menus.Where(x => x.idMenuType == groupId &&x.Status==true).ToList();
        }
    }
}
