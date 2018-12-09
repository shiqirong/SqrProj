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
        public  async Task<List<GetMenuListOutput>> GetMenuList(long accountId,string systemId)
        {
            return await Get<List<GetMenuListOutput>>(ApiUrl + "Api/Security/GetMenuList", new { accountId, systemId });
        }

        public async Task<List<GetMenuListOutput>> GetAllMenu()
        {
            return await Get<List<GetMenuListOutput>>(ApiUrl + "Api/Security/GetAllMenu",null);
        }

        public async Task<ActionInfo> GetActionInfo(long id)
        {
            return await Get<ActionInfo>(ApiUrl + $"Api/Security/GetActionInfo?id={id}",null );
        }

        public async Task<long> AddActionInfo(ActionInfo model)
        {
            return await Post<long>(ApiUrl + $"Api/Security/AddActionInfo", model);
        }

        public async Task<bool> UpdateActionInfo(ActionInfo model)
        {
            return await Post<bool>(ApiUrl + $"Api/Security/UpdateActionInfo", model);
        }

    }
}
