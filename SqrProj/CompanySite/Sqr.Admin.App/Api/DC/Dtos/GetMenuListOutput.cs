using System;
using System.Collections.Generic;
using System.Text;

namespace Sqr.Admin.App.Api.DC.Dtos
{
    public class GetMenuListOutput
    {
        /// <summary>
        /// 主键
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public sbyte IsDeleted { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long AccountId { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string Controller { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string Action { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string Parameters { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public int Category { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public long ParentId { get; set; }

    }
}
