namespace Model.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Supplier
    {
        [Key]
        [StringLength(50)]
        [Required(ErrorMessage = "Yêu cầu bạn nhập mã nhà cung cấp")]
        [Display(Name = "Mã Nhà Cung Cấp")]
        public String idSupplier { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Yêu cầu bạn nhập tên nhà cung cấp")]
        [Display(Name = "Tên Nhà Cung Cấp")]
        public string Name { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Yêu cầu bạn nhập chọn logo nhà cung cấp")]
        [Display(Name = "Logo Nhà Cung Cấp")]
        public string Logo { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Yêu cầu bạn nhập email nhà cung cấp")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email chưa đúng định dạng.")]
        [Display(Name = "Email Nhà Cung Cấp")]
        public string Email { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Yêu cầu bạn nhập số điện thoại nhà cung cấp")]
        [RegularExpression("(0)+\\d{9,10}", ErrorMessage = "Số điện thoại chưa đúng định dạng")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Bạn phải nhập số")]
        [Display(Name = "Điện Thoại Liên Hệ")]
        public string Phone { get; set; }
    }
}