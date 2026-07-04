namespace Model.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    public partial class Product
    {
        [Key]
        public int idProduct { get; set; }

        [StringLength(250, ErrorMessage = "Số ký tự tối đa là 250")]
        [Required(ErrorMessage = "Yêu cầu bạn nhập tên sản phẩm")]
        [Display(Name = "Tên Sản Phẩm")]
        public string Name { get; set; }

        [StringLength(250, ErrorMessage = "Số ký tự tối đa là 250")]
        [Required(ErrorMessage = "Yêu cầu bạn nhập đường dẫn url")]
        [Display(Name = "Đường Dẫn URL")]
        public string MetaTitle { get; set; }

        [StringLength(10, ErrorMessage = "Số ký tự tối đa là 10")]
        [Required(ErrorMessage = "Yêu cầu bạn nhập mã sản phẩm")]
        [Display(Name = "Mã Sản Phẩm")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Yêu cầu bạn nhập đơn giá")]
        [Display(Name = "Đơn Giá")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Bạn phải nhập số")]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "Yêu cầu bạn nhập giá khuyến mãi")]
        [Display(Name = "Giá Khuyến Mãi")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Bạn phải nhập số")]
        public decimal? Discount { get; set; }

        [StringLength(250, ErrorMessage = "Số ký tự tối đa là 250")]
        [Required(ErrorMessage = "Yêu cầu bạn chọn hình ảnh")]
        [Display(Name = "Hình Ảnh")]
        public string Image { get; set; }

        [Display(Name = "Trạng Thái Hàng")]
        [Required(ErrorMessage = "Yêu cầu bạn chọn trạng thái hàng")]
        public bool? Available { get; set; }

        [StringLength(500, ErrorMessage = "Số ký tự tối đa là 500")]
        [Required(ErrorMessage = "Yêu cầu bạn nhập mô tả tóm tắt")]
        [Display(Name = "Mô Tả")]
        [AllowHtml]
        public string Description { get; set; }

        [Column(TypeName = "ntext")]
        [Required(ErrorMessage = "Yêu cầu bạn nhập mô tả chi tiết")]
        [Display(Name = "Mô Tả Chi Tiết")]
        [AllowHtml]
        public string Detail { get; set; }

        [Required(ErrorMessage = "Yêu cầu bạn nhập bảo hành")]
        [Display(Name = "Bảo Hành")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Bạn phải nhập số")]
        public int? Warranty { get; set; }

        [Required(ErrorMessage = "Yêu cầu bạn nhập số lượng")]
        [Display(Name = "Số Lượng")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Bạn phải nhập số")]
        public int? Quantity { get; set; }

        [Required(ErrorMessage = "Yêu cầu bạn chọn thời gian khuyến mãi")]
        [Display(Name = "Thời Gian Khuyến Mại")]
        public DateTime? Special { get; set; }

        [Display(Name = "Ngày Tạo")]
        //[DataType(DataType.Date)]
        public DateTime? CreateDate { get; set; }

        [Display(Name = "Tài Khoản Đăng")]
        [Required(ErrorMessage = "Yêu cầu bạn chọn tài khoản đăng")]
        public int? idUser { get; set; }

        [Display(Name = "Lượt Xem")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Bạn phải nhập số")]
        public int? Views { get; set; }

        [Display(Name = "Trạng Thái")]
        [Required(ErrorMessage = "Yêu cầu bạn chọn trạng thái")]
        public bool? Status { get; set; }

        [Display(Name = "Danh Mục Sản Phẩm")]
        [Required(ErrorMessage = "Yêu cầu bạn chọn danh mục sản phẩm")]
        public int idCategories { get; set; }

        [StringLength(50, ErrorMessage = "Số ký tự tối đa là 50")]
        [Required(ErrorMessage = "Yêu cầu bạn nhập nhà cung cấp")]
        [Display(Name = "Nhà Cung Cấp")]
        public string idSupplier { get; set; }

        public virtual Category Category { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual User User { get; set; }
    }
}
