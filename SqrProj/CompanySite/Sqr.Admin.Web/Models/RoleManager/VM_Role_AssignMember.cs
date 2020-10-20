using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sqr.Admin.Web.Models.RoleManager
{
    public class VM_Role_AssignMember
    {
        [Required(ErrorMessage ="权限组ID是必填项")]
        public int Id { get; set; }

        public IList<long> UserIds { get; set; }
    }
}
