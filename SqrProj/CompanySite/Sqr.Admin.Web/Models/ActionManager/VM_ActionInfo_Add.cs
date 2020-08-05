using Microsoft.AspNetCore.Mvc.Rendering;
using Sqr.DC.Dtos.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sqr.Admin.Web.Models.ActionManager
{
    public class VM_ActionInfo_Add
    {
        public IList<SelectListItem> Sites { get; set; }

    }
}
