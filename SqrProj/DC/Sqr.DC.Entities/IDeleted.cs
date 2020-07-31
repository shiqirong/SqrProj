using System;
using System.Collections.Generic;
using System.Text;

namespace Sqr.DC.Entities
{
    public interface IDeleted
    {
        /// <summary>
        /// 主键
        /// </summary>
        long Id { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        sbyte IsDeleted { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        DateTime? DeleteTime { get; set; }
        /// <summary>
        /// 删除者
        /// </summary>
        int DeleteUser { get; set; }

    }
}
