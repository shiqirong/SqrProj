using System;
using System.Collections.Generic;
using System.Text;

namespace Sqr.DC.Dtos.Account
{
    public class ActionDto:DbBaseMo
    {
        /// <summary>
        /// 
        /// </summary>
        public string Action { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string Category { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string Controller { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string Parameters { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public int ParentId { get; set; }

        public long SystemId { get; set; }

        public string SystemName { get; set; }
    }
}
