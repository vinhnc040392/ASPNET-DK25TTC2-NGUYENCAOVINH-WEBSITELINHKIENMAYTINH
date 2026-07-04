using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class FeedBackModel
    {
        [Key]
        public int idFeedBack { get; set; }

        [StringLength(50, ErrorMessage = "Số ký tự tối đa là 50")]
        [Required(ErrorMessage = "Yêu cầu bạn nhập tên của bạn")]
        [Display(Name = "Tên Của Bạn")]
        public string Name { get; set; }

        [StringLength(50, ErrorMessage = "Số ký tự tối đa là 50")]
        [Required(ErrorMessage = "Yêu cầu bạn nhập số điện thoại")]
        [Display(Name = "Số Điện Thoại")]
        [RegularExpression("(0)+\\d{9,10}", ErrorMessage = "Số điện thoại chưa đúng định dạng")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Bạn phải nhập số")]
        public string Phone { get; set; }

        [StringLength(50, ErrorMessage = "Số ký tự tối đa là 50")]
        [Required(ErrorMessage = "Yêu cầu bạn nhập email")]
        [Display(Name = "Email")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Chưa đúng định dang email.")]
        public string Email { get; set; }

        [StringLength(50, ErrorMessage = "Số ký tự tối đa là 50")]
        [Required(ErrorMessage = "Yêu cầu bạn nhập địa chỉ")]
        [Display(Name = "Địa Chỉ")]
        public string Address { get; set; }

        [StringLength(250, ErrorMessage = "Số ký tự tối đa là 250")]
        [Required(ErrorMessage = "Yêu cầu bạn nhập nội dung")]
        [Display(Name = "Nội Dung")]
        public string Content { get; set; }

        [Display(Name = "Ngày Tạo")]
        public DateTime? CreateDate { get; set; }

        [Required(ErrorMessage = "Yêu cầu bạn chọn trạng thái")]
        [Display(Name = "Trạng Thái")]
        public bool? Status { get; set; }
    }
}