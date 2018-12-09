using System;
using System.Collections.Generic;
using System.Text;

namespace Sqr.Admin.App.Api.DC.Dtos
{
    public class ActionInfo
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
        /// 名称
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// Controller
        /// </summary>
        public string Controller { get; set; }


        /// <summary>
        /// Action
        /// </summary>
        public string Action { get; set; }


        /// <summary>
        /// 地址参数
        /// </summary>
        public string Parameters { get; set; }


        /// <summary>
        /// 类型（1：分类，2：菜单，3：动作）
        /// </summary>
        public short Category { get; set; }


        /// <summary>
        /// 邮箱地址
        /// </summary>
        public long ParentId { get; set; }
    }
}
