//-----------------------------------------------------------------------
// <copyright file=" SsoSites.cs" company="xxxx Enterprises">
// * Copyright (C) 2018 xxxx Enterprises All Rights Reserved
// * version : 4.0.30319.42000
// * author  : auto generated by T4
// * FileName: SsoSites.cs
// * history : Created by T4 10/28/2018 21:39:12 
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Data.Entity.ModelConfiguration;
using Sqr.DC.EF.Models;


namespace Sqr.DC.EF.Configs
{
    /// <summary>
    /// sso_sites Entity Model Config
    /// </summary>   
    public class SsoSitesConfig :EntityTypeConfiguration<SsoSites>
    {
		public SsoSitesConfig()
        {
            ToTable("sso_sites");

            HasKey(m => m.Id).Property(m => m.Id).HasColumnType("bigint");
        
	        
			/// <summary>
			/// 主键
			/// </summary>
			Property(m=>m.Id).HasColumnName("Id").HasColumnType("bigint").IsRequired();
	        
			/// <summary>
			/// 站点名称
			/// </summary>
			Property(m=>m.SiteName).HasColumnName("Site_Name").HasColumnType("varchar").HasMaxLength(50).IsRequired();
	        
			/// <summary>
			/// 站点域名
			/// </summary>
			Property(m=>m.SiteUrl).HasColumnName("Site_Url").HasColumnType("varchar").HasMaxLength(100).IsRequired();
	        
			/// <summary>
			/// 登入地址
			/// </summary>
			Property(m=>m.SiteLoginUrl).HasColumnName("Site_Login_Url").HasColumnType("varchar").HasMaxLength(100).IsRequired();
	        
			/// <summary>
			/// 登出地址
			/// </summary>
			Property(m=>m.SiteLogoutUrl).HasColumnName("Site_Logout_Url").HasColumnType("varchar").HasMaxLength(100).IsRequired();
	        
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
