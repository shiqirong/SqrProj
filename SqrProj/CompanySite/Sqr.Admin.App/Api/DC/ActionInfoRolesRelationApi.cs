using Sqr.Common;
using Sqr.DC.Dtos.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.Admin.App.Api.DC
{
    public class ActionInfoRolesRelationApi : ApiBase<ActionInfoRolesRelationApi>
    {
        public async Task<ResultMo<IList<ActionInfoRolesRelationDto>>> GetByRoleId(long roleId)
        {
            return await Get<IList<ActionInfoRolesRelationDto>>(ApiUrl + "Api/ActionInfoRolesRelation/GetByRoleId", new { roleId });
        }

        public async Task<ResultMo> RemoveByRoleId(long roleId)
        {
            return await Post<bool>(ApiUrl + $"Api/ActionInfoRolesRelation/RemoveByRoleId", new { roleId });
        }

        public async Task<ResultMo> AssignPower(long roleId,IList<ActionInfoRolesRelationDto> input)
        {
            return await Post<bool>(ApiUrl + $"Api/ActionInfoRolesRelation/AssignPower?roleId={roleId}", input);
        }

    }
}
