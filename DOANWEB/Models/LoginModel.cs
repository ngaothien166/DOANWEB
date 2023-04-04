﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace DOANWEB.Models
{
    public class LoginModel
    {
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Mời bạn nhập UserName")]
        public string UserName { set; get; }
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Mời bạn nhập password")]
        public string Password { set; get; }
    }
}