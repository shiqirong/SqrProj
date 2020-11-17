using System;
using System.Collections.Generic;
using System.Text;

namespace Sqr.DC.Dtos.News
{
    public class NewsInfoQueryDto
    {
        public string Title { get; set; }

        public bool? IsHot { get; set; }

        public bool? IsPublished { get; set; }

        public int OrderIndex { get; set; }

        public DateTime? PublishedTimeStart { get; set; }

        public DateTime? PublishedTimeEnd { get; set; }
    }
}
