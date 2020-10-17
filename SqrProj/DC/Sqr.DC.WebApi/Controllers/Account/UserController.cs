using Microsoft.AspNetCore.Mvc;
using Sqr.Common.Paging;
using Sqr.DC.Dtos.Account;
using Sqr.DC.Services.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sqr.DC.WebApi.Controllers.Account
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class UserController: ControllerBase
    {
        [HttpGet]
        public async Task<PagingOutput<UserDto>> GetUserPaged([FromQuery]GetUserPagedInput input)
        {
            return await UsersService.Instance.GetUserPaged(input);
        }

        [HttpGet]
        public async Task<UserDto> Get(long id)
        {
            return await UsersService.Instance.Get(id);
        }

        [HttpPost]
        public async Task<bool> Add(UserDto input)
        {
            return await UsersService.Instance.Add(input);
        }

        [HttpPost]
        public async Task<bool> Update(UserDto input)
        {
            return await UsersService.Instance.Update(input);
        }

        [HttpPost]
        public async Task<bool> Delete(UserDto input)
        {
            return await UsersService.Instance.Delete(input);
        }

        [HttpPost]
        public async Task<bool> ResetPwd(UserDto input)
        {
            return await UsersService.Instance.ResetPwd(input);
        }
    }
}
