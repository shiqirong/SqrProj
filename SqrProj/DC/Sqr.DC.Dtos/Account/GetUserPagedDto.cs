using System;
using System.Collections.Generic;
using System.Text;

namespace Sqr.DC.Dtos.Account
{
    public class GetUserPagedInput
    {
        public int Page { get; set; }

        public int Limit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Account { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string Mobile { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
    }
}
