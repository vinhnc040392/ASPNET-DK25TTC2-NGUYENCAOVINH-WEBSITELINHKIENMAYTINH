namespace Model.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VideoAdvertisement")]
    public partial class VideoAdvertisement
    {
        [Key]
        public int idVideo { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Yêu cầu bạn chọn video")]
        [Display(Name = "Tên Video")]
        public string TenVideo { get; set; }

        [Display(Name = "Ngày Tạo")]
        public DateTime? CreateDate { get; set; }

        [Display(Name = "Trạng Thái")]
        public bool? Status { get; set; }
    }
}
