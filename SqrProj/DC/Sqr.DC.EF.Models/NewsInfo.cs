//-----------------------------------------------------------------------
// <copyright file=" news_info.cs" company="xxxx Enterprises">
// * Copyright (C) 2018 xxxx Enterprises All Rights Reserved
// * version : 4.0.30319.42000
// * author  : auto generated by T4
// * FileName: NewsInfo.cs
// * history : Created by T4 10/19/2018 21:54:09 
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Runtime.Serialization;

namespace Sqr.DC.EF.Models
{
    /// <summary>
    /// NewsInfo Entity Model
    /// </summary>    
    [Serializable]
    [DataContract]
    public class NewsInfo:BaseMo
    {
      
			/// <summary>
			/// 标题
			/// </summary>
								[DataMember]
						public string Title { get; set; }

      
			/// <summary>
			/// 标题2
			/// </summary>
								[DataMember]
						public string Title2 { get; set; }

      
			/// <summary>
			/// 内容
			/// </summary>
								[DataMember]
						public string Content { get; set; }

      
			/// <summary>
			/// 内容2
			/// </summary>
								[DataMember]
						public string Content2 { get; set; }

      
			/// <summary>
			/// 小图
			/// </summary>
								[DataMember]
						public string Imagesmall { get; set; }

      
			/// <summary>
			/// 大图
			/// </summary>
								[DataMember]
						public string Imagebig { get; set; }

      
			/// <summary>
			/// 是否置顶
			/// </summary>
								[DataMember]
						public bool Ishot { get; set; }

      
			/// <summary>
			/// 是否是叶节点
			/// </summary>
								[DataMember]
						public bool Isleaf { get; set; }

      
			/// <summary>
			/// 发布时间
			/// </summary>
								[DataMember]
						public DateTime PublishedTime { get; set; }

      
			/// <summary>
			/// 状态：1发布，2不发布
			/// </summary>
								[DataMember]
						public bool Ispublished { get; set; }

    }
}
