using Model.Data;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class SlideDao
    {
        OnlineShopDbContext db = null;

        public SlideDao()
        {
            db = new OnlineShopDbContext();
        }

        public int Insert(Slide entity)
        {
            db.Slides.Add(entity);
            db.SaveChanges();
            return entity.idSlide;
        }

        public bool Update(Slide entity)
        {
            try
            {
                var sl = db.Slides.Find(entity.idSlide);
                sl.Image = entity.Image;
                sl.DisplayOrder = entity.DisplayOrder;
                sl.Status = entity.Status;
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
                var mn = db.Slides.Find(id);
                db.Slides.Remove(mn);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Slide ViewDetail(int id)
        {
            return db.Slides.Find(id); //tìm kiếm theo khóa chính
        }

        public IEnumerable<Slide> ListAll(int page, int pageSize)
        {
            IQueryable<Slide> model = db.Slides;
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }

        //lay ra danh sach slide ra trang giao dien khach hang
        public List<Slide> ListAllHome()
        {
            return db.Slides.Where(x => x.Status == true).OrderBy(y => y.DisplayOrder).ToList();
        }
    }
}
