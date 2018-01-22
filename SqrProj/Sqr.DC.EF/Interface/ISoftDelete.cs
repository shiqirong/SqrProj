using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.DC.EF.Interface
{
    /// <summary>
    /// 删除接口
    /// </summary>
    public interface ISoftDelete
    {
        /// <summary>
        /// 标记实体是否已删除
        /// </summary>
        bool IsDeleted { get; set; }
    }
}
