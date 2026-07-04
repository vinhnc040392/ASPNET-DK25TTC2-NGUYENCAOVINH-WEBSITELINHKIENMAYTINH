namespace Model.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [Key]
        public int idUser { get; set; }

        [StringLength(50, ErrorMessage = "Số ký tự tối đa là 50")]
        [Required(ErrorMessage = "Yêu cầu bạn nhập tên đăng nhập")]
        [Display(Name = "Tên Đăng Nhập")]
        public string Username { get; set; }

        [StringLength(50, MinimumLength = 6, ErrorMessage = "Độ dài mật khẩu ít nhất là 6 ký tự.")]
        [Required(ErrorMessage = "Yêu cầu bạn nhập mật khẩu")]
        [Display(Name = "Mật Khẩu")]
        public string Password { get; set; }

        [StringLength(50, ErrorMessage = "Số ký tự tối đa là 50")]
        [Required(ErrorMessage = "Yêu cầu bạn nhập họ tên")]
        [Display(Name = "Họ Và Tên")]
        public string Name { get; set; }

        [StringLength(250, ErrorMessage = "Số ký tự tối đa là 250")]
        [Required(ErrorMessage = "Yêu cầu bạn nhập địa chỉ")]
        [Display(Name = "Địa Chỉ")]
        public string Address { get; set; }

        [StringLength(50, ErrorMessage = "Số ký tự tối đa là 50")]
        [Required(ErrorMessage = "Yêu cầu bạn nhập email")]
        [Display(Name = "Email")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Chưa đúng định dang email.")]
        public string Email { get; set; }

        [StringLength(11, ErrorMessage = "Số ký tự tối đa là 11")]
        [Required(ErrorMessage = "Yêu cầu bạn nhập số điện thoại")]
        [Display(Name = "Điện Thoại Liên Hệ")]
        [RegularExpression("(0)+\\d{9,10}", ErrorMessage = "Số điện thoại chưa đúng định dạng")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Bạn phải nhập số")]
        public string Phone { get; set; }

        [Display(Name = "Ngày Tạo")]
        //[DataType(DataType.Date)]
        public DateTime? CreateDate { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        [Display(Name = "Ngày Sửa")]
        //[DataType(DataType.Date)]
        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [StringLength(20)]
        [Display(Name="Phân Quyền")]
        public string idUserGroup { get; set; }

        [Display(Name = "Trạng Thái")]
        [Required(ErrorMessage = "Yêu cầu bạn chọn trạng thái")]
        public bool? Status { get; set; }

        public virtual UserGroup UserGroup { get; set; }
    }
}

