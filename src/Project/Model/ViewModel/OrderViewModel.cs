using Model.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class OrderViewModel
    {        
        public int idOrder { get; set; }

        public DateTime? CreateDate { get; set; }

        public string ShipName { get; set; }

        public string ShipMobile { get; set; }

        public string ShipAdress { get; set; }

        public string ShipEmai { get; set; }

        public bool? Status { get; set; }

        public List<OrderDetailViewModel> ListOrderDetail { get; set; }

    }
}
