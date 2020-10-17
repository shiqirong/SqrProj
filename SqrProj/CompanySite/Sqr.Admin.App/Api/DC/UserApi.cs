using Sqr.Common;
using Sqr.Common.Paging;
using Sqr.Common.Utils;
using Sqr.DC.Dtos.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.Admin.App.Api.DC
{
    public class UserApi : ApiBase<UserApi>
    {
        public UserApi()
        {
            ApiUrl = ConfigUtil.GetSection("DCConfig").GetSection("BaseUrl").Value;
        }


        public async Task<ResultMo<PagingOutput<UserDto>>> GetUserPaged(GetUserPagedInput input)
        {
            return await Get<PagingOutput<UserDto>>(ApiUrl + "Api/User/GetUserPaged", input);
        }
        
        public async Task<ResultMo<UserDto>> Get(long id)
        {
            return await Get<UserDto>(ApiUrl + $"Api/User/Get?id={id}",null);
        }

        public async Task<ResultMo<bool>> Add(UserDto input)
        {
            return await Post<bool>(ApiUrl + $"Api/User/Add",input);
        }

        public async Task<ResultMo<bool>> Update(UserDto input)
        {
            return await Post<bool>(ApiUrl + $"Api/User/Update", input);
        }
        
        public async Task<ResultMo<bool>> Delete(UserDto input)
        {
            return await Post<bool>(ApiUrl + $"Api/User/Delete", input);
        }
        
        public async Task<ResultMo<bool>> ResetPwd(UserDto input)
        {
            return await Post<bool>(ApiUrl + $"Api/User/ResetPwd", input);
        }
    }
}
