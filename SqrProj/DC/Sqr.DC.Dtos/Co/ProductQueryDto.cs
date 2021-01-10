using System;
using System.Collections.Generic;
using System.Text;

namespace Sqr.DC.Dtos.Co
{
    public class ProductQueryDto
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string Model { get; set; }

        public long? Category { get; set; }
    }
}
