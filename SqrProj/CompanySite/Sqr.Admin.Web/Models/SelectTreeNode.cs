using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sqr.Admin.Web.Models
{
    public class SelectTreeNode
    {
        public string Name { get; set; }

        public long Id { get; set; }

        public List<SelectTreeNode> Children { get; set; }

        public bool Open { get; set; }

        public bool Checked { get; set; }
    }
}
