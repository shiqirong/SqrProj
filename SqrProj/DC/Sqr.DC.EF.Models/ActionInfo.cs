//-----------------------------------------------------------------------
// <copyright file=" action_info.cs" company="xxxx Enterprises">
// * Copyright (C) 2018 xxxx Enterprises All Rights Reserved
// * version : 4.0.30319.42000
// * author  : auto generated by T4
// * FileName: ActionInfo.cs
// * history : Created by T4 10/28/2018 21:44:15 
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Runtime.Serialization;

namespace Sqr.DC.EF.Models
{
    /// <summary>
    /// ActionInfo Entity Model
    /// </summary>    
    [Serializable]
    [DataContract]
    public class ActionInfo:BaseMo
    {
      
			/// <summary>
			/// 名称
			/// </summary>
								[DataMember]
						public string Name { get; set; }

      
			/// <summary>
			/// Controller
			/// </summary>
								[DataMember]
						public string Controller { get; set; }

      
			/// <summary>
			/// Action
			/// </summary>
								[DataMember]
						public string Action { get; set; }

      
			/// <summary>
			/// 地址参数
			/// </summary>
								[DataMember]
						public string Parameters { get; set; }

      
			/// <summary>
			/// 类型（1：分类，2：菜单，3：动作）
			/// </summary>
								[DataMember]
						public int Category { get; set; }

      
			/// <summary>
			/// 邮箱地址
			/// </summary>
								[DataMember]
						public long ParentId { get; set; }

    }
}