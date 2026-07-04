namespace Model.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("About")]
    public partial class About
    {
        [Key]
        public int idAbout { get; set; }

        [StringLength(250, ErrorMessage = "Số ký tự tối đa là 250")]
        [Required(ErrorMessage = "Yêu cầu bạn nhập")]
        [Display(Name = "Lời Giới Thiệu")]
        public string Name { get; set; }

        [StringLength(250, ErrorMessage = "Số ký tự tối đa là 250")]
        [Required(ErrorMessage = "Yêu cầu bạn nhập đường dẫn url")]
        [Display(Name = "Đường Dẫn URL")]
        public string MetaTitle { get; set; }

        [StringLength(500, ErrorMessage = "Số ký tự tối đa là 500")]
        [Required(ErrorMessage = "Yêu cầu bạn nhập mô tả tóm tắt")]
        [Display(Name = "Mô Tả")]
        [AllowHtml]
        public string Description { get; set; }

        [StringLength(250, ErrorMessage = "Số ký tự tối đa là 250")]
        [Required(ErrorMessage = "Yêu cầu bạn chọn hình ảnh")]
        [Display(Name = "Hình Ảnh")]
        public string Image { get; set; }

        [Column(TypeName = "ntext")]
        [Required(ErrorMessage = "Yêu cầu bạn nhập mô tả chi tiết")]
        [Display(Name = "Mô Tả Chi Tiết")]
        [AllowHtml]
        public string Detail { get; set; }

        [Display(Name = "Ngày Tạo")]
        public DateTime? CreateDate { get; set; }

        [Required(ErrorMessage = "Yêu cầu bạn chọn trạng thái")]
        [Display(Name = "Trạng Thái")]
        public bool? Status { get; set; }
    }
}
