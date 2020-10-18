using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sqr.Admin.Web.Models
{
    public class TreeNode
    {
        public long Id { get; set; }
        public string Field { get; set; }
        public int Level { get; set; }
        public string Title { get; set; }
        public bool Lazy { get; set; }
        public bool Checked { get; set; }

        public bool Spread { get; set; }
        public List<TreeNode> Children { get; set; }
    }
}
