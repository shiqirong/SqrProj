using Sqr.Common;
using Sqr.Common.Helper;
using Sqr.DC.Dtos.Account;
using Sqr.DC.Entities;
using Sqr.DC.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.DC.Services.Security
{
    public class ActionInfoRolesRelationService:ServiceBase<ActionInfoRolesRelationService>
    {
        public async Task<ResultMo<IList<ActionInfoRolesRelationDto>>> GetByRoleId(long roleId)
        {
            var result= await ActioninforolesrelationRepository.Instance.GetByRoleId(roleId);
            return ResultMo<IList<ActionInfoRolesRelationDto>>.Success(result.MapTo<IList<ActionInfoRolesRelationDto>>());
        }

        public async Task<ResultMo> RemoveByRoleId(long roleId)
        {
            var result= await ActioninforolesrelationRepository.Instance.RemoveByRoleId(roleId);
            return ResultMo.Success();
        }

        public async Task<ResultMo> AssignPower(long roleId,IList<ActionInfoRolesRelationDto> input)
        {
        
            using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeAsyncFlowOption.Enabled))
            {
                await ActioninforolesrelationRepository.Instance.RemoveByRoleId(roleId);
                if (input != null && input.Count > 0)
                {
                    foreach (var dto in input)
                    {
                        var iResult = await ActioninforolesrelationRepository.Instance.InsertAsync(new Actioninforolesrelation()
                        {
                            CreateTime = DateTime.Now,
                            Roleid = dto.RoleId,
                            Actioninfoid = dto.ActionInfoId
                        });
                        if (iResult == 0)
                        {
                            return ResultMo.Fail();
                        }
                    }
                }
                ts.Complete();
            }
            return ResultMo.Success();
        }
    }
}
