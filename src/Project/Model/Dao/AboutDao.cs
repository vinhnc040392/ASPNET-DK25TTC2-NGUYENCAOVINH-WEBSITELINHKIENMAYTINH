using Model.Data;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class AboutDao
    {
        OnlineShopDbContext db = null;

        public AboutDao()
        {
            db = new OnlineShopDbContext();
        }

        public int Insert(About entity)
        {
            db.Abouts.Add(entity);
            db.SaveChanges();
            return entity.idAbout;
        }

        public bool Update(About entity)
        {
            try
            {
                var About = db.Abouts.Find(entity.idAbout);
                About.Name = entity.Name;
                About.MetaTitle = entity.MetaTitle;
                About.Description = entity.Description;
                About.Image = entity.Image;
                About.Detail = entity.Detail;
                About.Status = entity.Status;
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
                var About = db.Abouts.Find(id);
                db.Abouts.Remove(About);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public About ViewDetail(int id)
        {
            return db.Abouts.Find(id); //tìm kiếm theo khóa chính
        }

        public IEnumerable<About> ListAll(string searchString, int page, int pageSize)
        {
            IQueryable<About> model = db.Abouts;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }

        //lay ra danh sach san pham hot tinh theo ngay
        public List<About> ListAboutHome(int top)
        {
            return db.Abouts.OrderByDescending(x => x.Status==true).Take(top).ToList();
        }
    }
}
