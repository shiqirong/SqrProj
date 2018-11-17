using Sqr.Admin.App.Api.DC.Dtos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.Admin.App.Api.DC
{
    public  class SecurityApi : ApiBase
    {
        public  async Task<GetMenuListOutput> GetMenuList(string accountId,string systemId)
        {
            return await Get<GetMenuListOutput>(ApiUrl + "Api/Security/GetMenuList", new { accountId, systemId });
        }
        
    }
}
