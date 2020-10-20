using Sqr.Common.Encrypt;
using Sqr.Common.Helper;
using Sqr.Common.Paging;
using Sqr.DC.Dtos.Account;
using Sqr.DC.Entities;
using Sqr.DC.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.DC.Services.Security
{
    public class UsersService : ServiceBase<UsersService>
    {
        public async Task<PagingOutput<UserDto>> GetUserPaged(GetUserPagedInput input)
        {
            return await UsersRepository.Instance.GetUserPaged(input);

        }

        public async Task<bool> Add(UserDto input)
        {
            input.Id = 0;
            input.CreateTime = DateTime.Now;
            input.Status = 1;
            input.Password = Md5.EncryptHexString("123456");
            var user = input.MapTo<Users>();
            user.CreateTime = DateTime.Now;
            return await UsersRepository.Instance.InsertAsync(user) > 0;

        }

        public async Task<UserDto> Get(long id)
        {
            return (await UsersRepository.Instance.GetByIdSingleAsync(id)).MapTo<UserDto>();
        }

        public async Task<bool> Update(UserDto input)
        {
            return await UsersRepository.Instance.Update(input) > 0;
        }

        public async Task<bool> Delete(UserDto input)
        {
            return await UsersRepository.Instance.Delete(new Users() { Id = input.Id,DeleteUser=input.DeleteUser,DeleteTime=DateTime.Now }) > 0;
        }

        public async Task<bool> ResetPwd(UserDto input)
        {
            input.Password = Md5.EncryptHexString("123456");
            return await UsersRepository.Instance.ResetPwd(input) > 0;
        }
    }
}
