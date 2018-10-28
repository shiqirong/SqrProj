//-----------------------------------------------------------------------
// <copyright file=" action_info.cs" company="xxxx Enterprises">
// * Copyright (C) 2018 xxxx Enterprises All Rights Reserved
// * version : 4.0.30319.42000
// * author  : auto generated by T4
// * FileName: ActionInfo.cs
// * history : Created by T4 10/19/2018 21:39:33 
// </copyright>
//-----------------------------------------------------------------------
using System;
using Sqr.DC.Repository.Core;

namespace Sqr.DC.Repository.Models
{
    /// <summary>
    /// ActionInfo Entity Model
    /// </summary>    
    [Serializable]
    public class ActionInfo:ModelBase
    {
      
			/// <summary>
			/// 名称
			/// </summary>
						public string Name { get; set; }

      
			/// <summary>
			/// Controller
			/// </summary>
						public string Controller { get; set; }

      
			/// <summary>
			/// Action
			/// </summary>
						public string Action { get; set; }

      
			/// <summary>
			/// 地址参数
			/// </summary>
						public string Parameters { get; set; }

      
			/// <summary>
			/// 类型（1：分类，2：菜单，3：动作）
			/// </summary>
						public int Category { get; set; }

      
			/// <summary>
			/// 邮箱地址
			/// </summary>
						public int ParentId { get; set; }

    }
}