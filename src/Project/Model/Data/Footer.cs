namespace Model.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Footer")]
    public partial class Footer
    {
        [Key]
        [StringLength(50, ErrorMessage = "Số ký tự tối đa là 50")]
        [Required(ErrorMessage = "Yêu cầu bạn nhập mã footer")]
        [Display(Name = "Mã Footer")]
        public string idFooter { get; set; }

        [Column(TypeName = "ntext")]
        [Required(ErrorMessage = "Yêu cầu bạn nhập nội dung")]
        [Display(Name = "Nội Dung")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Yêu cầu bạn chọn trạng thái")]
        [Display(Name = "Trạng Thái")]
        public bool? Status { get; set; }
    }
}
