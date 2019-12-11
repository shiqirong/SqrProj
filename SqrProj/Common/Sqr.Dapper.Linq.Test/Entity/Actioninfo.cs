using System;
using System.Collections.Generic;
using System.Text;

namespace Sqr.Dapper.Linq.Test.Entity
{
    /// <summary>
    /// Actioninfo Entity Model
    /// </summary>    
    public class Actioninfo : BaseMo
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
        public int Parentid { get; set; }

    }
}
