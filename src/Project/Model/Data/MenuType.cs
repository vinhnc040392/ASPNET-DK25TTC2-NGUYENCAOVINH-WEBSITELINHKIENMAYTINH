namespace Model.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MenuType")]
    public partial class MenuType
    {
        [Key]
        [Display(Name = "Mã Danh Mục Menu")]
        public int idMenuType { get; set; }

        [StringLength(50, ErrorMessage = "Số ký tự tối đa là 50")]
        [Required(ErrorMessage = "Yêu cầu bạn nhập tên danh mục menu")]
        [Display(Name = "Danh Mục Menu")]
        public string Name { get; set; }
    }
}