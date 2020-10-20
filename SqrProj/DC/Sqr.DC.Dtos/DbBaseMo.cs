﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sqr.DC.Dtos
{
    public class DbBaseMo
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
        /// 删除者
        /// </summary>
        public int DeleteUser { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// <summary>
        /// 更新者
        /// </summary>
        public int UpdateUser { get; set; }
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 创建者
        /// </summary>
        public int CreateUser { get; set; }
    }
}