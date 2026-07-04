namespace Model.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Slide")]
    public partial class Slide
    {
        [Key]
        public int idSlide { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Yêu cầu bạn chọn ảnh")]
        [Display(Name = "Hình Ảnh")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Yêu cầu bạn nhập thứ tự hiển thị")]
        [Display(Name = "Thứ Tự Hiển Thị")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Bạn phải nhập số")]
        public int? DisplayOrder { get; set; }

        [Display(Name = "Ngày Tạo")]
        public DateTime? CreateDate { get; set; }

        [Display(Name = "Trạng Thái")]
        [Required(ErrorMessage = "Yêu cầu bạn chọn trạng thái")]
        public bool? Status { get; set; }
    }
}
