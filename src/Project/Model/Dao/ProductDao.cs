using Model.Data;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ProductDao
    {
        OnlineShopDbContext db = null;

        public ProductDao()
        {
            db = new OnlineShopDbContext();
        }

        public IEnumerable<Product> ListAll(string searchString, int page, int pageSize)
        {
            IQueryable<Product> model = db.Products;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Code.Contains(searchString) || x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }

        public int Insert(Product entity)
        {
            db.Products.Add(entity);
            db.SaveChanges();
            return entity.idProduct;
        }

        public bool Update(Product entity)
        {
            try
            {
                var pro = db.Products.Find(entity.idProduct);
                pro.Name = entity.Name;
                pro.MetaTitle = entity.MetaTitle;
                pro.Code = entity.Code;
                pro.Price = entity.Price;
                pro.Discount = entity.Discount;
                pro.Image = entity.Image;
                pro.Available = entity.Available;
                pro.Description = entity.Description;
                pro.Detail = entity.Detail;
                pro.Warranty = entity.Warranty;
                pro.Quantity = entity.Quantity;
                pro.Special = entity.Special;
                pro.Status = entity.Status;
                pro.idCategories = entity.idCategories;
                pro.idSupplier = entity.idSupplier;
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
                var pro = db.Products.Find(id);
                db.Products.Remove(pro);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        

        public Product ViewDetail(int id)
        {
            return db.Products.Find(id); //tìm kiếm theo khóa chính
        }

        public List<Category> DropListCategory()
        {
            return db.Categories.Where(x => x.Status == true && x.idCategories>10).ToList();
        }

        public List<User> DropListUser()
        {
            return db.Users.Where(x => x.Status == true).ToList();
        }

        public List<Supplier> DropListSupplier()
        {
            return db.Suppliers.ToList();
        }

        //lay ra danh sach san pham moi nhat theo id
        public List<Product> ListNewProduct(int top)
        {
            return db.Products.OrderByDescending(x => x.idProduct).Take(top).ToList();
        }

        //lay ra danh sach san pham theo idCategory + phan trang
        public List<Product> ListByCategoryId(int categoryID, ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
            totalRecord = db.Products.Where(x => x.idCategories == categoryID).Count();
            var model = db.Products.Where(x => x.idCategories == categoryID).OrderByDescending(x => x.idProduct).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return model;
        }

        //lay ra danh sach san pham hot tinh theo ngay
        public List<Product> ListFeatureProduct1(int hot)
        {
            return db.Products.Where(x => x.Special != null && x.Special > DateTime.Now).OrderByDescending(x => x.idProduct).Take(hot).ToList();
        }

        //lay ra danh sach san pham hot tinh theo ngay
        public List<Product> ListFeatureProduct2(int hot)
        {
            return db.Products.Where(x => x.Special != null && x.Special > DateTime.Now).OrderByDescending(x => x.idProduct).Take(hot).ToList();
        }

        //lay ra danh sach san pham lien quan theo idProduct
        public List<Product> ListRelatedProduct(int productId)
        {
            var product = db.Products.Find(productId);
            return db.Products.Where(x => x.idProduct != productId && x.idCategories == product.idCategories).ToList();
        }

        public Product ViewDetailHome(int id)
        {
            return db.Products.Find(id); //tìm kiếm theo khóa chính
        }

        public List<string> ListName(string keyword)
        {
            return db.Products.Where(x => x.Name.Contains(keyword)).Select(x => x.Name).ToList();
        }

        //lay ra danh sach san pham dc search theo name = phan trang
        public List<Product> Search(string keyword, ref int totalRecord, int pageIndex = 1, int pageSize = 1)
        {
            totalRecord = db.Products.Where(x => x.Name.Contains(keyword)).Count();
            var model = db.Products.Where(x => x.Name.Contains(keyword)).OrderByDescending(x => x.idProduct).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return model;
        }

        //check lỗi xóa dữ liệu
        public bool CheckInUse(int id)
        {
            if (!db.OrderDetails.Where(x => x.idProduct == id).ToList().Any())
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
