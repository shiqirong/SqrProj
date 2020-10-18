using Microsoft.AspNetCore.Mvc;
using Sqr.Common;
using Sqr.DC.Dtos.Account;
using Sqr.DC.Entities;
using Sqr.DC.Services.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sqr.DC.WebApi.Controllers.Account
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ActionInfoRolesRelationController: ControllerBase
    {
        [HttpGet]
        public async Task<ResultMo<IList<ActionInfoRolesRelationDto>>> GetByRoleId(long roleId)
        {
            return await ActionInfoRolesRelationService.Instance.GetByRoleId(roleId);

        }
        [HttpPost]
        public async Task<ResultMo> RemoveByRoleId(long roleId)
        {
            return await ActionInfoRolesRelationService.Instance.RemoveByRoleId(roleId);
        }

        [HttpPost]
        public async Task<ResultMo> AssignPower(long roleId,[FromBody]IList<ActionInfoRolesRelationDto> input)
        {
            return await ActionInfoRolesRelationService.Instance.AssignPower(roleId,input);
        }
    }
}
