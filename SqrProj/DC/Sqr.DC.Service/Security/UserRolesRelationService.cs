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
    public class UserRolesRelationService : ServiceBase<UserRolesRelationService>
    {
        public async Task<ResultMo> AssignMember(long roleId, IList<UserRolesRelationDto> lstURR)
        {
            using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeAsyncFlowOption.Enabled))
            {
                await UserrolesrelationRepository.Instance.RemoveByRoleId(roleId);
                if (lstURR != null && lstURR.Count > 0)
                {
                    foreach (var dto in lstURR)
                    {
                        var iResult = await UserrolesrelationRepository.Instance.InsertAsync(new Userrolesrelation()
                        {
                            CreateTime = DateTime.Now,
                            RoleId = dto.RoleId,
                            UserId = dto.UserId
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

        public async Task<ResultMo<IList<UserRolesRelationDto>>> GetRoleUsers(long roleId)
        {
            var result=await UserrolesrelationRepository.Instance.GetByRoleId(roleId);
            return ResultMo<IList<UserRolesRelationDto>>.Success(result.MapTo<List<UserRolesRelationDto>>());
        }
    }
}
