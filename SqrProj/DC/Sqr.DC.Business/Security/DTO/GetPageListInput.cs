using Sqr.Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.DC.BLL.Security.DTO
{
    public class GetPageListInput:PagingInput
    {
        /// <summary>
        /// 登入账号
        /// </summary>
        public string LoginAccount { get; set; }

        /// <summary>
        /// 登入名称
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 邮箱地址
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime? DeleteTimeBegin { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime? DeleteTimeEnd { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTimeBegin { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTimeEnd { get; set; }
    }
}
