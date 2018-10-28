using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.DC.BLL.Security.Dto
{
    public class GetMenuListOutput
    {

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
