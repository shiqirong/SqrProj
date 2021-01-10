using Sqr.Admin.App.Api.DC;
using Sqr.Admin.App.Helper;
using Sqr.Common;
using Sqr.Common.Paging;
using Sqr.DC.Dtos.Account;
using Sqr.DC.Dtos.Security;
using System;
using System.Threading.Tasks;

namespace Sqr.Admin.App.Security
{
    public class ActionBusiness:BaseBusiness<ActionBusiness>
    {
        public async Task<PagingOutput<ActionDto>> MenuList(PagingInput<ActionDto> input)
        {
            var result= await SecurityApi.Instance.GetActionPaged(input);
            return result.Data;
        }
        

        public async Task<ResultMo<ActionInfo>> GetActionInfo(long id)
        {
            return await SecurityApi.Instance.GetActionInfo(id);
        }

        public async Task<ResultMo<bool>> Update(ActionInfo input)
        {
            return await SecurityApi.Instance.UpdateActionInfo(input);
        }

        public async Task<ResultMo<long>> Add(ActionInfo input)
        {
            return await SecurityApi.Instance.AddAction(input);
        }

        public async Task<ResultMo<bool>> Delete(long id)
        {
            return await SecurityApi.Instance.DeleteAction(id);
        }
    }
}
