//-----------------------------------------------------------------------
// <copyright file=" account_roles_relation.cs" company="xxxx Enterprises">
// * Copyright (C) 2018 xxxx Enterprises All Rights Reserved
// * version : 4.0.30319.42000
// * author  : auto generated by T4
// * FileName: AccountRolesRelation.cs
// * history : Created by T4 10/29/2018 21:39:04 
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace Sqr.DC.EF.Models
{
    /// <summary>
    /// AccountRolesRelation Entity Model
    /// </summary>    
    [Serializable]
    public class AccountRolesRelation:BaseMo
    {
      
			/// <summary>
			/// 账号ID
			/// </summary>
						public long AccountId { get; set; }

      
			/// <summary>
			/// 角色ID
			/// </summary>
						public long RoleId { get; set; }

    }
}
