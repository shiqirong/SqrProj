//-----------------------------------------------------------------------
// <copyright file=" accounts.cs" company="xxxx Enterprises">
// * Copyright (C) 2018 xxxx Enterprises All Rights Reserved
// * version : 4.0.30319.42000
// * author  : auto generated by T4
// * FileName: Accounts.cs
// * history : Created by T4 10/29/2018 21:39:04 
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace Sqr.DC.EF.Models
{
    /// <summary>
    /// Accounts Entity Model
    /// </summary>    
    [Serializable]
    public class Accounts:BaseMo
    {
      
			/// <summary>
			/// 登入账号
			/// </summary>
						public string LoginAccount { get; set; }

      
			/// <summary>
			/// 登入密码
			/// </summary>
						public string LoginPassword { get; set; }

      
			/// <summary>
			/// 登入名称
			/// </summary>
						public string LoginName { get; set; }

      
			/// <summary>
			/// 邮箱地址
			/// </summary>
						public string Email { get; set; }

    }
}
