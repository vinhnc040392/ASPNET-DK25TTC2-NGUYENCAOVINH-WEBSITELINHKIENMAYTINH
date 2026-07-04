using Model.Data;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class FeedBackDao
    {
        OnlineShopDbContext db = null;

        public FeedBackDao()
        {
            db = new OnlineShopDbContext();
        }

        public FeedBack ViewDetail(int id)
        {
            return db.FeedBacks.Find(id); //tìm kiếm theo khóa chính
        }

        public IEnumerable<FeedBack> ListAll(string searchString, int page, int pageSize)
        {
            IQueryable<FeedBack> model = db.FeedBacks;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.idFeedBack).ToPagedList(page, pageSize);
        }

        //them du lieu vao Order
        public int Insert(FeedBack feedback)
        {
            db.FeedBacks.Add(feedback);
            db.SaveChanges();
            return feedback.idFeedBack;
        }
    }
}