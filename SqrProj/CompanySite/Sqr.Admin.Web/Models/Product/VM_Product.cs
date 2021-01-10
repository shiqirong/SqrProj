using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sqr.Admin.Web.Models.Product
{
    public class VM_Product
    {
        public long Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Content { get; set; }



        /// <summary>
        /// 
        /// </summary>
        public string Imagebig { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string Imagesmall { get; set; }



        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string Model { get; set; }

        public long Category { get; set; }

    }
}
