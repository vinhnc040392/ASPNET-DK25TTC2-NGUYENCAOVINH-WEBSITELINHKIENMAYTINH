namespace Model.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menu")]
    public partial class Menu
    {
        [Key]
        public int idMenu { get; set; }

        [StringLength(50, ErrorMessage = "Số ký tự tối đa là 50")]
        [Required(ErrorMessage = "Yêu cầu bạn nhập tên menu")]
        [Display(Name = "Tên Menu")]
        public string Text { get; set; }

        [StringLength(250, ErrorMessage = "Số ký tự tối đa là 250")]
        [Required(ErrorMessage = "Yêu cầu bạn nhập đường dẫn url")]
        [Display(Name = "Đường Dẫn URL")]
        public string Link { get; set; }

        [Required(ErrorMessage = "Yêu cầu bạn nhập thứ tự hiển thị")]
        [Display(Name = "Thứ Tự Hiển Thị")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Bạn phải nhập số")]
        public int? DisplayOrder { get; set; }

        [StringLength(50, ErrorMessage = "Số ký tự tối đa là 50")]
        [Display(Name = "Kiểu Herf Trang")]
        public string Target { get; set; }

        [Required(ErrorMessage = "Yêu cầu bạn chọn trạng thái")]
        [Display(Name = "Trạng Thái")]
        public bool? Status { get; set; }

        [Required(ErrorMessage = "Yêu cầu bạn chọn danh mục menu")]
        [Display(Name = "Danh Mục Menu")]
        public int idMenuType { get; set; }

        public virtual MenuType MenuType { get; set; }
    }
}