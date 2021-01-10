using System;
using System.Collections.Generic;
using System.Text;

namespace Sqr.DC.Dtos.Co
{
    public class ProductInfoDto: DbBaseMo
    {

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
