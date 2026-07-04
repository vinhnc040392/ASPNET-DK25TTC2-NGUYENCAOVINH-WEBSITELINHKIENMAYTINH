using Model.Data;
using Model.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class OrderDao
    {
        OnlineShopDbContext db = null;

        public OrderDao()
        {
            db = new OnlineShopDbContext();
        }

        public IEnumerable<Order> ListAll(string searchString, int page, int pageSize)
        {
            IQueryable<Order> model = db.Orders;
            var a = db.Orders.ToList();
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.ShipMobile.Contains(searchString));
            }
            
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }

        //them du lieu vao Order
        public int Insert(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return order.idOrder;
        }

        public bool Update(Order order)
        {
            try
            {
                var pro = db.Orders.Find(order.idOrder);
                //pro.Status = true;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public Order ViewDetail(int id)
        {
            return db.Orders.Find(id); //tìm kiếm theo khóa chính
        }
        public OrderViewModel ViewDetailOrder(int id)
        {
            var query = (from order in db.Orders
                        join orderdetail in db.OrderDetails on order.idOrder equals orderdetail.idOrder
                        join product in db.Products on orderdetail.idProduct equals product.idProduct
                        select new
                        {
                            idOrder = order.idOrder,
                            CreateDate = order.CreateDate,
                            ShipName = order.ShipName,
                            ShipMobile=order.ShipMobile,
                            ShipAdress= order.ShipAdress,
                            ShipEmai= order.ShipEmai,
                            Status= order.Status,
                            OrderDetailProduct = new OrderDetailViewModel() { idOrder = order.idOrder, Quantity= orderdetail.Quantity, Price = orderdetail.Price, idProduct = orderdetail.idProduct, Product = product }
                        }).Where(n=>n.idOrder== id).ToList();
            var query2 = from qr1 in query
                         group  qr1.OrderDetailProduct by new { qr1.idOrder, qr1.CreateDate, qr1.ShipMobile, qr1.ShipName, qr1.ShipAdress, qr1.ShipEmai, qr1.Status } into gr 
                         select new OrderViewModel
                         {
                             idOrder = gr.Key.idOrder,
                             CreateDate = gr.Key.CreateDate,
                             ShipName = gr.Key.ShipName,
                             ShipMobile = gr.Key.ShipMobile,
                             ShipAdress = gr.Key.ShipAdress,
                             ShipEmai = gr.Key.ShipEmai,
                             Status = gr.Key.Status,
                             ListOrderDetail = gr.ToList()
                         };

            return query2.FirstOrDefault(); //tìm kiếm theo khóa chính
        }

        public bool UpdateStatus(int idOrder, bool status)
        {
            try
            {
                var ord = db.Orders.Find(idOrder);
                ord.Status = status;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
