using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shopie.Models
{
    public class LoginModel
    {
        [Key]
        [Required(ErrorMessage = "Chưa nhập tên đăng nhập")]
        public string UserName { set; get; }

        [Required(ErrorMessage = "Chưa nhập mật khẩu")]
        public string Password { set; get; }

    }
}