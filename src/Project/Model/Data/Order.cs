namespace Model.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [Key]
        public int idOrder { get; set; }

        [Display(Name = "Ngày Tạo")]
        public DateTime? CreateDate { get; set; }

        [StringLength(50, ErrorMessage = "Số ký tự tối đa là 50")]
        [Required(ErrorMessage = "Yêu cầu bạn nhập tên khách hàng")]
        [Display(Name = "Khách Hàng")]
        public string ShipName { get; set; }

        [StringLength(11, ErrorMessage = "Số ký tự tối đa là 11")]
        [Required(ErrorMessage = "Yêu cầu bạn nhập số điện thoại")]
        [Display(Name = "Điện Thoại Liên Hệ")]
        //[RegularExpression("(0)+\\d{9,10}", ErrorMessage = "Số điện thoại chưa đúng định dạng")]
        //[Range(0, Int32.MaxValue, ErrorMessage = "Bạn phải nhập số")]
        public string ShipMobile { get; set; }

        [StringLength(50, ErrorMessage = "Số ký tự tối đa là 50")]
        [Required(ErrorMessage = "Yêu cầu bạn nhập địa chỉ nhận hàng")]
        [Display(Name = "Địa Chỉ Nhận Hàng")]
        public string ShipAdress { get; set; }

        [StringLength(50, ErrorMessage = "Số ký tự tối đa là 50")]
        [Required(ErrorMessage = "Yêu cầu bạn nhập email liên hệ")]
        [Display(Name = "Email Liên Hệ")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Chưa đúng định dang email.")]
        public string ShipEmai { get; set; }

        [Required(ErrorMessage = "Yêu cầu bạn chọn trạng thái")]
        [Display(Name = "Trạng Thái")]
        public bool? Status { get; set; }

    }
}
