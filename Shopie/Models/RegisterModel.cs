using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shopie.Models
{
    public class RegisterModel
    {     
        [Key]
        public long ID { set; get; }

        [Required(ErrorMessage = "Chưa nhập tên đăng nhập")]
        [StringLength(32, MinimumLength=6, ErrorMessage = "Tên đăng nhập phải từ 6-32 ký tự")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Chưa nhập mật khẩu")]
        [StringLength(32, MinimumLength = 6, ErrorMessage = "Mật khẩu phải từ 6-32 ký tự")]
        public string Password { get; set; }

        [StringLength(32)]
        [Compare("Password", ErrorMessage = "Xác nhận mật khẩu không đúng")]
        public string ConfirmPassword { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Chưa nhập họ tên")]
        public string Name { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Chưa nhập email")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không đúng")]
        public string Email { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Chưa nhập số điện thoại")]
        [Phone(ErrorMessage = "Số điện thoại không đúng")]
        public string Phone { get; set; }
   
    }
}