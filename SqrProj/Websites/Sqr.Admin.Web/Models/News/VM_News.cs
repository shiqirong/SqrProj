using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sqr.Admin.Web.Models.News
{
    public  class VM_News
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public int Level { get; set; }

        public DateTime PublishDate { get; set; }

        public string Content { get; set; }
    }
}