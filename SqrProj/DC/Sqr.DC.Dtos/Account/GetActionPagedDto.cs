using Sqr.Common.Paging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sqr.DC.Dtos.Account

{
    public class GetActionPagedInput:PagingInput
    {
        public string SystemId { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
    }

    public class GetActionPagedOutput  
    {

    }
}
