using Sqr.Common;
using Sqr.Common.Paging;
using Sqr.DC.Dtos.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.Admin.App.Api.DC
{
    public class RolesApi: ApiBase<RolesApi>
    {

        public async Task<ResultMo<PagingOutput<RolesDto>>> GetPaged(PagingInput<RolesDto> input)
        {
            return await Post<PagingOutput<RolesDto>>(ApiUrl + "Api/Roles/GetPaged", input);
        }

        public async Task<ResultMo<RolesDto>> Get(long id)
        {
            return await Get<RolesDto>(ApiUrl + $"Api/Roles/Get?id={id}", null);
        }

        public async Task<ResultMo<bool>> Add(RolesDto input)
        {
            return await Post<bool>(ApiUrl + $"Api/Roles/Add", input);
        }

        public async Task<ResultMo<bool>> Update(RolesDto input)
        {
            return await Post<bool>(ApiUrl + $"Api/Roles/Update", input);
        }

        public async Task<ResultMo<bool>> Delete(RolesDto input)
        {
            return await Post<bool>(ApiUrl + $"Api/Roles/Delete", input);
        }
    }
}
