using Model.Data;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class SupplierDao
    {
        OnlineShopDbContext db = null;

        public SupplierDao()
        {
            db = new OnlineShopDbContext();
        }

        public string Insert(Supplier entity)
        {
            db.Suppliers.Add(entity);
            db.SaveChanges();
            return entity.idSupplier;
        }

        public bool Update(Supplier entity)
        {
            try
            {
                var sup = db.Suppliers.Find(entity.idSupplier);
                sup.Name = entity.Name;
                sup.Logo = entity.Logo;
                sup.Email = entity.Email;
                sup.Phone = entity.Phone;
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
                var sup = db.Suppliers.Find(id);
                db.Suppliers.Remove(sup);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Supplier ViewDetail(string id)
        {
            return db.Suppliers.Find(id); //tìm kiếm theo khóa chính
        }

        public IEnumerable<Supplier> ListAll(string searchString, int page, int pageSize)
        {
            IQueryable<Supplier> model = db.Suppliers;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.idSupplier.Contains(searchString) || x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.idSupplier).ToPagedList(page, pageSize);
        }

        //check lỗi xóa dữ liệu
        public bool CheckInUse(string id)
        {
            if (!db.Products.Where(x => x.idSupplier == id).ToList().Any())
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
