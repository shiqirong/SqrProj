using System;
using System.Collections.Generic;
using System.Text;

namespace Sqr.DC.Dtos.Co
{
    public  class ProductCategoryDto : DbBaseMo
    {
        /// <summary>
        /// 
        /// </summary>
        public string Code { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public int Parentid { get; set; }
    }
}
