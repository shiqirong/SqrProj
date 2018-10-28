//-----------------------------------------------------------------------
// <copyright file=" action_info_roles_relation.cs" company="xxxx Enterprises">
// * Copyright (C) 2018 xxxx Enterprises All Rights Reserved
// * version : 4.0.30319.42000
// * author  : auto generated by T4
// * FileName: ActionInfoRolesRelation.cs
// * history : Created by T4 10/28/2018 21:44:15 
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Runtime.Serialization;

namespace Sqr.DC.EF.Models
{
    /// <summary>
    /// ActionInfoRolesRelation Entity Model
    /// </summary>    
    [Serializable]
    [DataContract]
    public class ActionInfoRolesRelation:BaseMo
    {
      
			/// <summary>
			/// ActionInfoID
			/// </summary>
								[DataMember]
						public long ActionInfoId { get; set; }

      
			/// <summary>
			/// 角色ID
			/// </summary>
								[DataMember]
						public long RoleId { get; set; }

    }
}
