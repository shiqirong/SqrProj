//-----------------------------------------------------------------------
// <copyright file=" banner_info.cs" company="xxxx Enterprises">
// * Copyright (C) 2018 xxxx Enterprises All Rights Reserved
// * version : 4.0.30319.42000
// * author  : auto generated by T4
// * FileName: BannerInfo.cs
// * history : Created by T4 10/29/2018 21:39:04 
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace Sqr.DC.EF.Models
{
    /// <summary>
    /// BannerInfo Entity Model
    /// </summary>    
    [Serializable]
    public class BannerInfo:BaseMo
    {
      
			/// <summary>
			/// 标题
			/// </summary>
						public string Title { get; set; }

      
			/// <summary>
			/// 链接地址
			/// </summary>
						public string Linkurl { get; set; }

      
			/// <summary>
			/// 链接方式
			/// </summary>
						public string Linktype { get; set; }

      
			/// <summary>
			/// 图片地址
			/// </summary>
						public string Imageurl { get; set; }

      
			/// <summary>
			/// 大图
			/// </summary>
						public string Imagebig { get; set; }

      
			/// <summary>
			/// 发布时间
			/// </summary>
						public DateTime PublishedTime { get; set; }

      
			/// <summary>
			/// 状态：1发布，2不发布
			/// </summary>
						public sbyte Ispublished { get; set; }

    }
}
