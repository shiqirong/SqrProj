//-----------------------------------------------------------------------
// <copyright file=" DicInfo.cs" company="xxxx Enterprises">
// * Copyright (C) 2018 xxxx Enterprises All Rights Reserved
// * version : 4.0.30319.42000
// * author  : auto generated by T4
// * FileName: DicInfo.cs
// * history : Created by T4 10/28/2018 21:39:12 
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Data.Entity.ModelConfiguration;
using Sqr.DC.EF.Models;


namespace Sqr.DC.EF.Configs
{
    /// <summary>
    /// dic_info Entity Model Config
    /// </summary>   
    public class DicInfoConfig :EntityTypeConfiguration<DicInfo>
    {
		public DicInfoConfig()
        {
            ToTable("dic_info");

            HasKey(m => m.Id).Property(m => m.Id).HasColumnType("bigint");
        
	        
			/// <summary>
			/// 主键
			/// </summary>
			Property(m=>m.Id).HasColumnName("Id").HasColumnType("bigint").IsRequired();
	        
			/// <summary>
			/// 编码
			/// </summary>
			Property(m=>m.Code).HasColumnName("Code").HasColumnType("varchar").HasMaxLength(50).IsRequired();
	        
			/// <summary>
			/// 值
			/// </summary>
			Property(m=>m.Value).HasColumnName("Value").HasColumnType("varchar").HasMaxLength(1000).IsRequired();
	        
			/// <summary>
			/// 类型
			/// </summary>
			Property(m=>m.Category).HasColumnName("Category").HasColumnType("smallint").IsRequired();
	        
			/// <summary>
			/// 父ID
			/// </summary>
			Property(m=>m.ParentId).HasColumnName("Parent_Id").HasColumnType("bigint").IsRequired();
	        
			/// <summary>
			/// 备注
			/// </summary>
			Property(m=>m.Remark).HasColumnName("Remark").HasColumnType("varchar").HasMaxLength(1000).IsRequired();
	        
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