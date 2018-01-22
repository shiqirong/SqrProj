//-----------------------------------------------------------------------
// <copyright file=" User.cs" company="xxxx Enterprises">
// * Copyright (C) 2018 xxxx Enterprises All Rights Reserved
// * version : 4.0.30319.42000
// * author  : auto generated by T4
// * FileName: User.cs
// * history : Created by T4 01/22/2018 11:09:22 
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Data.Entity.ModelConfiguration;
using Sqr.DC.EF.Models;


namespace Sqr.DC.EF.Configs
{
    /// <summary>
    /// User Entity Model Config
    /// </summary>   
    public class UserConfig :EntityTypeConfiguration<User>
    {

		public UserConfig()
        {
            ToTable("User");

            HasKey(m => m.Id).Property(m => m.Id).HasColumnType("int");
        
	        
			/// <summary>
			/// 主键
			/// </summary>
			Property(m=>m.Id).HasColumnType("int").IsRequired();
	        
			/// <summary>
			/// 账号
			/// </summary>
			Property(m=>m.Account).HasColumnType("varchar").HasMaxLength(50).IsRequired();
	        
			/// <summary>
			/// 密码
			/// </summary>
			Property(m=>m.Password).HasColumnType("varchar").HasMaxLength(50).IsRequired();
	        
			/// <summary>
			/// 昵称
			/// </summary>
			Property(m=>m.NickName).HasColumnType("varchar").HasMaxLength(100).IsRequired();
	        
			/// <summary>
			/// 性别
			/// </summary>
			Property(m=>m.Gender).HasColumnType("int").IsRequired();
	        
			/// <summary>
			/// 状态：1正常�?无效
			/// </summary>
			Property(m=>m.Status).HasColumnType("int").IsRequired();
	        
			/// <summary>
			/// 类型�?客户�?员工
			/// </summary>
			Property(m=>m.Type).HasColumnType("int").IsRequired();
	        
			/// <summary>
			/// 
			/// </summary>
			Property(m=>m.BizCode).HasColumnType("varchar").HasMaxLength(100);
	        
			/// <summary>
			/// 电子邮件
			/// </summary>
			Property(m=>m.EMail).HasColumnType("varchar").HasMaxLength(50).IsRequired();
	        
			/// <summary>
			/// 
			/// </summary>
			Property(m=>m.CreateTime).HasColumnType("datetime").IsRequired();
	        
			/// <summary>
			/// 
			/// </summary>
			Property(m=>m.CreateId).HasColumnType("int").IsRequired();
			}
	}
}
