using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace DOANWEB.Models
{
    public class RegeditModel
    {
        // GET: Regedit
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Mời bạn nhập UserName")]
        public string UserName { set; get; }
        [Display(Name = "Họ và Tên")]
        [Required(ErrorMessage = "Mời bạn nhập Name")]
        public string Name { set; get; }
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Mời bạn nhập password")]
        public string Password { set; get; }
        [Display(Name = "Nhập lại mật khẩu")]
        [Required(ErrorMessage = "Mời bạn nhập lại password")]
        public string Password1 { set; get; }
    }
}