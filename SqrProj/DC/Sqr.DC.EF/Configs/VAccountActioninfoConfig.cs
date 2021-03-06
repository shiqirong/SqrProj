//-----------------------------------------------------------------------
// <copyright file=" VAccountActioninfo.cs" company="xxxx Enterprises">
// * Copyright (C) 2018 xxxx Enterprises All Rights Reserved
// * version : 4.0.30319.42000
// * author  : auto generated by T4
// * FileName: VAccountActioninfo.cs
// * history : Created by T4 10/29/2018 21:39:19 
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Data.Entity.ModelConfiguration;
using Sqr.DC.EF.Models;


namespace Sqr.DC.EF.Configs
{
    /// <summary>
    /// v_account_actioninfo Entity Model Config
    /// </summary>   
    public class VAccountActioninfoConfig :EntityTypeConfiguration<VAccountActioninfo>
    {
		public VAccountActioninfoConfig()
        {
            ToTable("v_account_actioninfo");

            HasKey(m => m.Id).Property(m => m.Id).HasColumnType("bigint");
        
	        
			/// <summary>
			/// 
			/// </summary>
			Property(m=>m.AccountId).HasColumnName("account_id").HasColumnType("bigint").IsRequired();
	        
			/// <summary>
			/// 
			/// </summary>
			Property(m=>m.Id).HasColumnName("Id").HasColumnType("bigint").IsRequired();
	        
			/// <summary>
			/// 
			/// </summary>
			Property(m=>m.Name).HasColumnName("Name").HasColumnType("varchar").HasMaxLength(50).IsRequired();
	        
			/// <summary>
			/// 
			/// </summary>
			Property(m=>m.Controller).HasColumnName("Controller").HasColumnType("varchar").HasMaxLength(50).IsRequired();
	        
			/// <summary>
			/// 
			/// </summary>
			Property(m=>m.Action).HasColumnName("Action").HasColumnType("varchar").HasMaxLength(50).IsRequired();
	        
			/// <summary>
			/// 
			/// </summary>
			Property(m=>m.Parameters).HasColumnName("Parameters").HasColumnType("varchar").HasMaxLength(100);
	        
			/// <summary>
			/// 
			/// </summary>
			Property(m=>m.Category).HasColumnName("Category").HasColumnType("smallint").IsRequired();
	        
			/// <summary>
			/// 
			/// </summary>
			Property(m=>m.ParentId).HasColumnName("Parent_Id").HasColumnType("bigint");
	        
			/// <summary>
			/// 
			/// </summary>
			Property(m=>m.IsDeleted).HasColumnName("Is_Deleted").HasColumnType("tinyint").IsRequired();
	        
			/// <summary>
			/// 
			/// </summary>
			Property(m=>m.DeleteTime).HasColumnName("Delete_Time").HasColumnType("datetime");
	        
			/// <summary>
			/// 
			/// </summary>
			Property(m=>m.CreateTime).HasColumnName("Create_Time").HasColumnType("datetime").IsRequired();
	        
			/// <summary>
			/// 
			/// </summary>
			Property(m=>m.UpdateTime).HasColumnName("Update_Time").HasColumnType("datetime").IsRequired();
			}
	}
}
