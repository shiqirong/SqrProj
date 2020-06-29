using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sqr.SSO.Web.Models.Account
{
    public class VM_Login
    {
        /// <summary>
        /// 登录账户 
        /// </summary>
        [Required(AllowEmptyStrings =false,ErrorMessage ="请输入登录账户")]
        //[StringLength(maximumLength:20,MinimumLength =6,ErrorMessage ="登录账户长度在6~20位之间")]
        public string Account { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "请输入登录密码")]
        //[RegularExpression(@"/^[a-zA-z]\w{3,15}$/", ErrorMessage = "字母、数字、下划线组成，字母开头，4-16位")]
        public string Password { get; set; }

        [Required(AllowEmptyStrings=false, ErrorMessage="请输入验证码")]
        public string ValidCode { get; set; }

        public string ReturnUrl { get; internal set; }
    }
}
