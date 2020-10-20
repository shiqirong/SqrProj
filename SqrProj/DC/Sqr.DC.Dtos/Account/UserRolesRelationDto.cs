using System;
using System.Collections.Generic;
using System.Text;

namespace Sqr.DC.Dtos.Account
{
    public class UserRolesRelationDto : DbBaseMo
    {
        /// <summary>
        /// 
        /// </summary>
        public long RoleId { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public long UserId { get; set; }
    }
}
