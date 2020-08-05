using Microsoft.AspNetCore.Mvc;
using Sqr.Common.Paging;
using Sqr.DC.Entities;
using Sqr.DC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sqr.DC.WebApi.Controllers.Base
{
    public class SsoSitesController: ControllerBase
    {
        [HttpGet]
        public async Task<IList<SsoSites>> GetList()
        {
            //return await SsoSitesService.Instance.GetSSOSites();
            return null;
        }
    }
}
