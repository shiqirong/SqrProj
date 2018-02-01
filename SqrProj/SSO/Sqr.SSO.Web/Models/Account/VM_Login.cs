using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sqr.SSO.Web.Models.Account
{
    public class VM_Login
    {
        [Required(ErrorMessage ="登录账户不能为空")]
        [StringLength(50,ErrorMessage = "登录账户的长度不能超过过50个字符")]
        public string Account { get; set; }

        [Required(ErrorMessage ="登录密码不能为空")]
        [StringLength(50,ErrorMessage ="登录密码的长度不能超过50个字符")]
        public string Password { get; set; }
    }
}