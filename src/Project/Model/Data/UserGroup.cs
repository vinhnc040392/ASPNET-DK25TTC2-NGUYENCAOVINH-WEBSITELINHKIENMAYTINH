using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data
{
    [Table("UserGroup")]
    public class UserGroup
    {
        [Key]
        [StringLength(20)]
        [Display(Name ="Mã Quyền Người Dùng")]
        [Required(ErrorMessage ="Yêu cầu bạn nhập dữ liệu")]
        public string idUserGroup { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên Quyền Người Dùng")]
        [Required(ErrorMessage = "Yêu cầu bạn nhập dữ liệu")]
        public string Name { get; set; }
    }
}
