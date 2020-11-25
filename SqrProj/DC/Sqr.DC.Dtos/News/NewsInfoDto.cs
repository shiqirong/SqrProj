using System;
using System.Collections.Generic;
using System.Text;

namespace Sqr.DC.Dtos.News
{
    public class NewsInfoDto:DbBaseMo
    {
        /// <summary>
        /// 
        /// </summary>
        public string Content { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string Content2 { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string Imagebig { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string Imagesmall { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public bool IsHot { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public bool IsPublished { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public DateTime PublishedTime { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string Title2 { get; set; }
        public int OrderIndex { get; set; }
    }
}
