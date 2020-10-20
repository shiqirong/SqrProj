using Microsoft.AspNetCore.Mvc;
using Sqr.Common;
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
    public class RolesController : ControllerBase
    {
        [HttpPost]
        public async Task<PagingOutput<RolesDto>> GetPaged(PagingInput<RolesDto> input)
        {
            return await RolesService.Instance.GetPaged(input);

        }

        [HttpGet]
        public async Task<ResultMo<RolesDto>> Get(long id)
        {
            return await RolesService.Instance.Get(id);

        }

        [HttpPost]
        public async Task<ResultMo> Update(RolesDto input)
        {
            return await RolesService.Instance.Update(input);
        }

        [HttpPost]
        public async Task<ResultMo> Add(RolesDto input)
        {
            return await RolesService.Instance.Add(input);
        }

        [HttpPost]
        public async Task<ResultMo> Delete(RolesDto input)
        {
            return await RolesService.Instance.Delete(input);
        }

        [HttpPost]
        public async Task<ResultMo> AssignMember(long roleId, [FromBody]IList<UserRolesRelationDto> lstURR)
        {
            return await UserRolesRelationService.Instance.AssignMember(roleId, lstURR);
        }

        [HttpGet]
        public async Task<ResultMo<IList<UserRolesRelationDto>>> GetRoleUsers(long roleId){
            return await UserRolesRelationService.Instance.GetRoleUsers(roleId);
        }
    }
}
