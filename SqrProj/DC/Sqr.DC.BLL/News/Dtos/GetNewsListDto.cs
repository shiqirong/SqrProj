﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.DC.BLL.News.Dtos
{
    public class GetNewsListOutput
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }


        /// <summary>
        /// 标题2
        /// </summary>
        public string Title2 { get; set; }


        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }


        /// <summary>
        /// 内容2
        /// </summary>
        public string Content2 { get; set; }


        /// <summary>
        /// 小图
        /// </summary>
        public string Imagesmall { get; set; }


        /// <summary>
        /// 大图
        /// </summary>
        public string Imagebig { get; set; }


        /// <summary>
        /// 是否置顶
        /// </summary>
        public sbyte Ishot { get; set; }


        /// <summary>
        /// 是否是叶节点
        /// </summary>
        public sbyte Isleaf { get; set; }


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
