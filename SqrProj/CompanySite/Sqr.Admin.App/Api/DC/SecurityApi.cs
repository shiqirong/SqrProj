using Sqr.Admin.App.Api.DC.Dtos;
using Sqr.Common.Paging;
using Sqr.Common.Utils;
using Sqr.DC.Dtos.Account;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
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

        public async Task<List<GetMenuListOutput>> DeleteAction(long id)
        {
            return await Get<List<GetMenuListOutput>>(ApiUrl + "Api/Action/Delete?id={id}", null);
        }

        public async Task<ActionInfo> GetActionInfo(long id)
        {
            return await Get<ActionInfo>(ApiUrl + $"Api/Action/Get?id={id}",null );
        }

        public async Task<long> AddAction(ActionInfo model)
        {
            return await Post<long>(ApiUrl + $"Api/Action/Update", model);
        }

        public async Task<bool> UpdateActionInfo(ActionInfo model)
        {
            return await Post<bool>(ApiUrl + $"Api/Action/UpdateActionInfo", model);
        }
        #endregion

    }
}
