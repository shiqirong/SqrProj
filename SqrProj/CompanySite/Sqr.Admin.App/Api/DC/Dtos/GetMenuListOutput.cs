using System;
using System.Collections.Generic;
using System.Text;

namespace Sqr.Admin.App.Api.DC.Dtos
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
