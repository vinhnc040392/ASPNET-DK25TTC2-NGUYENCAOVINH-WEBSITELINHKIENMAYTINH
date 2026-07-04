using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class LoginModel
    {
        [Key]
        [StringLength(20)]
        [Display(Name = "Tên Đăng Nhập")]
        [Required(ErrorMessage ="Bạn phải nhập tài khoản")]
        public string Username { get; set; }

        [StringLength(50)]
        [Display(Name = "Mật Khẩu")]
        [Required(ErrorMessage = "Bạn phải nhập mật khẩu")]
        public string Password { get; set; }
    }
}