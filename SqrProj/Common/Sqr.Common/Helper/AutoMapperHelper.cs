using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.Common.Helper
{
    public static class AutoMapperHelper
    {
        static AutoMapperHelper()
        {
            Mapper.Initialize(c =>
            {

            });
        }
        /// <summary>
        /// AutoMapper 
        /// </summary>
        public static TDestination MapTo<TDestination>(this object source)
        {
            if (source == null)
                return default(TDestination);
            
            return Mapper.Instance.Map<TDestination>(source);
        }
        
    }
}
