//-----------------------------------------------------------------------
// <copyright file=" AccountActionRelation.cs" company="xxxx Enterprises">
// * Copyright (C) 2018 xxxx Enterprises All Rights Reserved
// * version : 4.0.30319.42000
// * author  : auto generated by T4
// * FileName: AccountActionRelation.cs
// * history : Created by T4 10/29/2018 21:39:19 
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Data.Entity.ModelConfiguration;
using Sqr.DC.EF.Models;


namespace Sqr.DC.EF.Configs
{
    /// <summary>
    /// account_action_relation Entity Model Config
    /// </summary>   
    public class AccountActionRelationConfig :EntityTypeConfiguration<AccountActionRelation>
    {
		public AccountActionRelationConfig()
        {
            ToTable("account_action_relation");

            HasKey(m => m.Id).Property(m => m.Id).HasColumnType("bigint");
        
	        
			/// <summary>
			/// 主键
			/// </summary>
			Property(m=>m.Id).HasColumnName("Id").HasColumnType("bigint").IsRequired();
	        
			/// <summary>
			/// 账号ID
			/// </summary>
			Property(m=>m.AccountId).HasColumnName("Account_Id").HasColumnType("bigint").IsRequired();
	        
			/// <summary>
			/// 动作ID
			/// </summary>
			Property(m=>m.ActionId).HasColumnName("Action_Id").HasColumnType("bigint").IsRequired();
	        
			/// <summary>
			/// 是否删除
			/// </summary>
			Property(m=>m.IsDeleted).HasColumnName("Is_Deleted").HasColumnType("tinyint").IsRequired();
	        
			/// <summary>
			/// 删除时间
			/// </summary>
			Property(m=>m.DeleteTime).HasColumnName("Delete_Time").HasColumnType("datetime");
	        
			/// <summary>
			/// 创建时间
			/// </summary>
			Property(m=>m.CreateTime).HasColumnName("Create_Time").HasColumnType("datetime").IsRequired();
	        
			/// <summary>
			/// 更新时间
			/// </summary>
			Property(m=>m.UpdateTime).HasColumnName("Update_Time").HasColumnType("datetime").IsRequired();
			}
	}
}
