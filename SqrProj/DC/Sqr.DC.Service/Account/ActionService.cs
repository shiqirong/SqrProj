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
        public async Task<PagingOutput<Actioninfo>> GetActionPaged(GetActionPagedInput input)
        {
            return await ActioninfoRepository.Instance.GetActionPaged(input);
                
        }
    }
}
