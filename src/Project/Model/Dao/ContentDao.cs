using Model.Data;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ContentDao
    {
        OnlineShopDbContext db = null;

        public ContentDao()
        {
            db = new OnlineShopDbContext();
        }

        public IEnumerable<Content> ListAll(string searchString, int page, int pageSize)
        {
            IQueryable<Content> model = db.Contents;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Title.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }

        public int Insert(Content entity)
        {
            db.Contents.Add(entity);
            db.SaveChanges();
            return entity.idContent;
        }

        public bool Update(Content entity)
        {
            try
            {
                var ct = db.Contents.Find(entity.idContent);
                ct.MetaTitle = entity.MetaTitle;
                ct.Title = entity.Title;
                ct.Image = entity.Image;
                ct.Description = entity.Description;
                ct.Detail = entity.Detail;
                ct.ContenSource = entity.ContenSource;
                ct.CreateDate = DateTime.Now;
                ct.idUser = entity.idUser;
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
                var ct = db.Contents.Find(id);
                db.Contents.Remove(ct);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Content ViewDetail(int id)
        {
            return db.Contents.Find(id); //tìm kiếm theo khóa chính
        }

        public Content ViewDetailHome(int id)
        {
            return db.Contents.Find(id); //tìm kiếm theo khóa chính
        }

        public List<User> DropListUser()
        {
            return db.Users.Where(x => x.Status == true).ToList();
        }

        public IEnumerable<Content> ListAllHome(int page, int pageSize)
        {
            IQueryable<Content> model = db.Contents;
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }

    }
}

