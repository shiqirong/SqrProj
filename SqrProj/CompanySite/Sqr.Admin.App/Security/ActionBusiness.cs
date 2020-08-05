using Sqr.Admin.App.Api.DC;
using Sqr.Common.Paging;
using Sqr.DC.Dtos.Account;
using Sqr.DC.Dtos.Security;
using System;
using System.Threading.Tasks;

namespace Sqr.Admin.App.Security
{
    public class ActionBusiness:BaseBusiness<ActionBusiness>
    {
        public async Task<PagingOutput<ActionInfo>> MenuList()
        {
            return await SecurityApi.Instance.GetActionPaged(new GetActionPagedInput()
            {
                SystemId = "1",
                Category = "1",
                PageIndex=1,
                PageSize=int.MaxValue
            });
           
        }
        

        public async Task<ActionInfo> GetActionInfo(long id)
        {
            return await SecurityApi.Instance.GetActionInfo(id);
        }

        public async Task< bool> Update(ActionInfo input)
        {
            return await SecurityApi.Instance.UpdateActionInfo(input);
        }

        public async Task<long> Add(ActionInfo input)
        {
            return await SecurityApi.Instance.AddAction(input);
        }

        public async Task<bool> Delete(long id)
        {
            return await SecurityApi.Instance.DeleteAction(id);
        }
    }
}
