using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sqr.Admin.Web.Models.RoleManager
{
    public class VM_Role_AssignPower
    {
        public int Id { get; set; }

        public IList<TreeNode> ActionInfos { get; set; }
    }
}
