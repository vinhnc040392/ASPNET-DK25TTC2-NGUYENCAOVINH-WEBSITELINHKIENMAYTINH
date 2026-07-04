namespace Model.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Category
    {
        [Key]
        public int idCategories { get; set; }

        [StringLength(250, ErrorMessage = "Số ký tự tối đa là 250")]
        [Required(ErrorMessage = "Yêu cầu bạn nhập tên danh mục")]
        [Display(Name = "Tên Danh Mục")]
        public string Name { get; set; }

        [StringLength(250, ErrorMessage = "Số ký tự tối đa là 250")]
        [Required(ErrorMessage = "Yêu cầu bạn nhập đường dẫn url")]
        [Display(Name = "Đường Dẫn URL")]
        public string MetaTitle { get; set; }

        [Required(ErrorMessage = "Yêu cầu bạn chọn danh mục cha")]
        [Display(Name = "Danh Mục Cha")]
        public int? ParenId { get; set; }

        [Required(ErrorMessage = "Yêu cầu bạn chọn tài khoản đăng")]
        [Display(Name = "Tài Khoản Đăng")]
        public int idUser { get; set; }

        [Required(ErrorMessage = "Yêu cầu bạn nhập thứ tự hiển thị")]
        [Display(Name = "Thứ Tự Hiển Thị")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Bạn phải nhập số")]
        public int? DisplayOrder { get; set; }

        [Display(Name = "Ngày Tạo")]
        public DateTime? CreateDate { get; set; }

        [Required(ErrorMessage = "Yêu cầu bạn chọn trạng thái")]
        [Display(Name = "Trạng Thái")]
        public bool? Status { get; set; }
        
        public virtual User User { get; set; }
    }
}
