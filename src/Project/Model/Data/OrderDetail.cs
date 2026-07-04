namespace Model.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderDetail")]
    public partial class OrderDetail
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Mã Sản Phẩm")]
        public int idProduct { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Mã Đơn Hàng")]
        public int idOrder { get; set; }

        [Display(Name = "Số Lượng Sản Phẩm")]
        public int? Quantity { get; set; }

        [Display(Name = "Đơn Giá")]
        public decimal? Price { get; set; }
        
    }
}
