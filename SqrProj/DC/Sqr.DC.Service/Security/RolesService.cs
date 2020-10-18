using Sqr.Common;
using Sqr.Common.Helper;
using Sqr.Common.Paging;
using Sqr.DC.Dtos.Account;
using Sqr.DC.Entities;
using Sqr.DC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.DC.Services.Security
{
    public class RolesService : ServiceBase<RolesService>
    {
        public async Task<PagingOutput<RolesDto>> GetPaged(PagingInput<RolesDto> input)
        {
            return await RolesRepository.Instance.GetPaged(input);

        }

        public async Task<ResultMo<RolesDto>> Get(long id)
        {
            var m= await RolesRepository.Instance.GetByIdSingleAsync(id);

            return ResultMo<RolesDto>.Success(m.MapTo<RolesDto>());
        }

        public async Task<ResultMo> Update(RolesDto input)
        {
            //检查是否存在相同名称的权限组
            var existList = await RolesRepository.Instance.QueryListByName(input.Id,input.Name);
            if (existList != null && existList.Any())
                return ResultMo.Fail( "权限组已经存在", ResultCode.DataExists);
            var iResult = await RolesRepository.Instance.Update(input);
            if (iResult > 0)
                return ResultMo.Success();
            else
                return ResultMo.Fail();
        }

        public async Task<ResultMo> Add(RolesDto input)
        {
            //检查是否存在相同名称的权限组
            var existList=await RolesRepository.Instance.QueryListByName(input.Id, input.Name);
            if (existList != null && existList.Any())
                return ResultMo.Fail( "权限组已经存在",ResultCode.DataExists);
            var iResult= await RolesRepository.Instance.InsertAsync(new Entities.Roles()
            {
                CreateTime = DateTime.Now,
                IsDeleted = 0,
                Name = input.Name
            });
            if (iResult > 0)
                return ResultMo.Success();
            else
                return ResultMo.Fail();

        }

        public async Task<ResultMo> Delete(RolesDto input)
        {
            var iResult = await RolesRepository.Instance.Delete(new Roles()
            {
                Id = input.Id
            });
            if (iResult > 0)
                return ResultMo.Success();
            else
                return ResultMo.Fail();
        }


    }
}
