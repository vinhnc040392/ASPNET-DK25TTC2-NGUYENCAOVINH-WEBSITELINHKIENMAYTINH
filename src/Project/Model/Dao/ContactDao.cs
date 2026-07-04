using Model.Data;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ContactDao
    {
        OnlineShopDbContext db = null;

        public ContactDao()
        {
            db = new OnlineShopDbContext();
        }

        public IEnumerable<Contact> ListAll(string searchString, int page, int pageSize)
        {
            IQueryable<Contact> model = db.Contacts;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Content.Contains(searchString));
            }
            return model.OrderByDescending(x => x.idContact).ToPagedList(page, pageSize);
        }

        public int Insert(Contact entity)
        {
            db.Contacts.Add(entity);
            db.SaveChanges();
            return entity.idContact;
        }

        public bool Update(Contact entity)
        {
            try
            {
                var cont = db.Contacts.Find(entity.idContact);
                cont.Content = entity.Content;
                cont.Status = entity.Status;
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
                var cont = db.Contacts.Find(id);
                db.Contacts.Remove(cont);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public Contact ViewDetail(int id)
        {
            return db.Contacts.Find(id); //tìm kiếm theo khóa chính
        }

        //khoi tao view contact
        public Contact GetActiveContact()
        {
            return db.Contacts.Single(x => x.Status == true);
        }
    }
}
