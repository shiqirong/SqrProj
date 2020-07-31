using Sqr.Common.Helper;
using Sqr.Common.Paging;
using Sqr.Dapper.Linq.Common;
using Sqr.DC.Dtos.Account;
using Sqr.DC.Entities;
using Sqr.DC.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.DC.Services.Account
{
    public class ActionService:ServiceBase<ActionService>
    {
        public async Task<PagingOutput<ActionInfo>> GetActionPaged(GetActionPagedInput input)
        {
            return await ActioninfoRepository.Instance.GetActionPaged(input);
                
        }

        public async Task<bool> AddAction(ActionInfo input)
        {
            if (input.Id == 0)
                input.Id = NumUtil.SnowNum();
            return await ActioninfoRepository.Instance.InsertAsync(input)>0;
            
        }

        public async Task<ActionInfo> Get(long id)
        {
            return await ActioninfoRepository.Instance.GetByIdSingleAsync(id);
        }

        public async Task<bool> Update(ActionInfo input){
            return await ActioninfoRepository.Instance.Update(input) > 0;
        }

        public async Task<bool> Delete(ActionInfo input)
        {
            return await ActioninfoRepository.Instance.Delete(input)>0;
        }
    }
}
