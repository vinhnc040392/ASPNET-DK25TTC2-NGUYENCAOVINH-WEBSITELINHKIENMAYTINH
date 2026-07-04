using Model.Data;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class OrderDetailDao
    {
        OnlineShopDbContext db = null;

        public OrderDetailDao()
        {
            db = new OnlineShopDbContext();
        }

        public IEnumerable<OrderDetail> ListAll(int page, int pageSize)
        {
            IQueryable<OrderDetail> model = db.OrderDetails;
            return model.OrderByDescending(x => x.idOrder).ToPagedList(page, pageSize);
        }

        //them du lieu vao OrderDetail tu Order
        public bool Insert(OrderDetail detail)
        {
            try
            {
                db.OrderDetails.Add(detail);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public OrderDetail ViewDetail(int id)
        {
            return db.OrderDetails.Find(id); //tìm kiếm theo khóa chính
        }
    }
}
