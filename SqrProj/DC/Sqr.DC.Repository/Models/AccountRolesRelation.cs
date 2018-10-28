//-----------------------------------------------------------------------
// <copyright file=" account_roles_relation.cs" company="xxxx Enterprises">
// * Copyright (C) 2018 xxxx Enterprises All Rights Reserved
// * version : 4.0.30319.42000
// * author  : auto generated by T4
// * FileName: AccountRolesRelation.cs
// * history : Created by T4 10/19/2018 21:39:33 
// </copyright>
//-----------------------------------------------------------------------
using System;
using Sqr.DC.Repository.Core;

namespace Sqr.DC.Repository.Models
{
    /// <summary>
    /// AccountRolesRelation Entity Model
    /// </summary>    
    [Serializable]
    public class AccountRolesRelation:ModelBase
    {
      
			/// <summary>
			/// 账号ID
			/// </summary>
						public int AccountId { get; set; }

      
			/// <summary>
			/// 角色ID
			/// </summary>
						public int RoleId { get; set; }

    }
}
