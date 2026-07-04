namespace Model.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("Contact")]
    public partial class Contact
    {
        [Key]
        public int idContact { get; set; }

        [Column(TypeName = "ntext")]
        [Required(ErrorMessage = "Yêu cầu bạn nhập nội dung")]
        [Display(Name = "Nội Dung")]
        [AllowHtml]
        public string Content { get; set; }

        [Required(ErrorMessage = "Yêu cầu bạn chọn trạng thái")]
        [Display(Name = "Trạng Thái")]
        public bool? Status { get; set; }
    }
}
