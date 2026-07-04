using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class RegisterModel
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

        [Display(Name = "Nhập Lại Mật Khẩu")]
        [StringLength(50, ErrorMessage = "Số ký tự tối đa là 50")]
        [Required(ErrorMessage = "Yêu cầu nhập mật khẩu")]
        [Compare("Password", ErrorMessage = "Xác nhận mật khẩu không chính xác.")]
        public string ConfirmPassword { get; set; }

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
    }
}