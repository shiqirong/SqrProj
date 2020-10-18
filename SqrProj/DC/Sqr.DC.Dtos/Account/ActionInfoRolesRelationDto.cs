using System;
using System.Collections.Generic;
using System.Text;

namespace Sqr.DC.Dtos.Account
{
    public class ActionInfoRolesRelationDto:DbBaseMo
    {
        /// <summary>
        /// 
        /// </summary>
        public long ActionInfoId { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public long RoleId { get; set; }
    }
}
