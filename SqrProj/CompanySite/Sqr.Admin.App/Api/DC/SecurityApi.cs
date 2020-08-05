using Sqr.Admin.App.Api.DC.Dtos;
using Sqr.Common.Paging;
using Sqr.Common.Utils;
using Sqr.DC.Dtos.Account;
using Sqr.DC.Dtos.Security;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sqr.Admin.App.Api.DC
{
    public  class SecurityApi : ApiBase<SecurityApi>
    {
        public SecurityApi()
        {
            ApiUrl = ConfigUtil.GetSection("DCConfig").GetSection("BaseUrl").Value;
        }

        #region action
        public async Task<PagingOutput<ActionInfo>> GetActionPaged(GetActionPagedInput input)
        {
            return await Get<PagingOutput<ActionInfo>>(ApiUrl + "Api/Action/GetActionPaged", input);
        }

        public async Task<bool> DeleteAction(long id)
        {
            return await Post<bool>(ApiUrl + $"Api/Action/Delete?id={id}", null);
        }

        public async Task<ActionInfo> GetActionInfo(long id)
        {
            return await Get<ActionInfo>(ApiUrl + $"Api/Action/Get?id={id}",null );
        }

        public async Task<long> AddAction(ActionInfo model)
        {
            return await Post<long>(ApiUrl + $"Api/Action/Add", model);
        }

        public async Task<bool> UpdateActionInfo(ActionInfo model)
        {
            return await Post<bool>(ApiUrl + $"Api/Action/Update", model);
        }

        public async Task<List<SsoSites>> GetSSOSites()
        {
            return await Get<List<SsoSites>>(ApiUrl + $"Api/Account/GetSSOSites",null);

        }
        #endregion

    }
}
