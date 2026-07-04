using Model.Data;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class CategoryDao
    {
        OnlineShopDbContext db = null;

        public CategoryDao()
        {
            db = new OnlineShopDbContext();
        }

        public IEnumerable<Category> ListAll(string searchString, int page, int pageSize)
        {
            IQueryable<Category> model = db.Categories;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }

        public int Insert(Category entity)
        {
            db.Categories.Add(entity);
            db.SaveChanges();
            return entity.idCategories;
        }

        public bool Update(Category entity)
        {
            try
            {
                var ct = db.Categories.Find(entity.idCategories);
                ct.Name = entity.Name;
                ct.MetaTitle = entity.MetaTitle;
                ct.ParenId = entity.ParenId;
                ct.idUser = entity.idUser;
                ct.DisplayOrder = entity.DisplayOrder;
                ct.Status = entity.Status;
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
                var ct = db.Categories.Find(id);
                db.Categories.Remove(ct);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Category ViewDetail(int id)
        {
            return db.Categories.Find(id); //tìm kiếm theo khóa chính
        }

        public List<User> DropListUser()
        {
            return db.Users.Where(x => x.Status == true).ToList();
        }

        public List<Category> DropListCategory()
        {
            return db.Categories.Where(x => x.Status == true && x.idCategories < 11).ToList();
        }

        public List<Category> ListAllHome()
        {
            return db.Categories.Where(x => x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }

        public Category ViewDetailHome(int id)
        {
            return db.Categories.Find(id);
        }

        public bool CheckInUse(int id)
        {
            if (!db.Products.Where(x => x.idCategories == id).ToList().Any())
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
