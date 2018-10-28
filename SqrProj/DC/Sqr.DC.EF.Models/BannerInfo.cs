//-----------------------------------------------------------------------
// <copyright file=" banner_info.cs" company="xxxx Enterprises">
// * Copyright (C) 2018 xxxx Enterprises All Rights Reserved
// * version : 4.0.30319.42000
// * author  : auto generated by T4
// * FileName: BannerInfo.cs
// * history : Created by T4 10/28/2018 21:44:15 
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Runtime.Serialization;

namespace Sqr.DC.EF.Models
{
    /// <summary>
    /// BannerInfo Entity Model
    /// </summary>    
    [Serializable]
    [DataContract]
    public class BannerInfo:BaseMo
    {
      
			/// <summary>
			/// 标题
			/// </summary>
								[DataMember]
						public string Title { get; set; }

      
			/// <summary>
			/// 链接地址
			/// </summary>
								[DataMember]
						public string Linkurl { get; set; }

      
			/// <summary>
			/// 链接方式
			/// </summary>
								[DataMember]
						public string Linktype { get; set; }

      
			/// <summary>
			/// 图片地址
			/// </summary>
								[DataMember]
						public string Imageurl { get; set; }

      
			/// <summary>
			/// 大图
			/// </summary>
								[DataMember]
						public string Imagebig { get; set; }

      
			/// <summary>
			/// 发布时间
			/// </summary>
								[DataMember]
						public DateTime PublishedTime { get; set; }

      
			/// <summary>
			/// 状态：1发布，2不发布
			/// </summary>
								[DataMember]
						public int Ispublished { get; set; }

    }
}