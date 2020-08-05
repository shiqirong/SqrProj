using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sqr.DC.WebApi.Controllers.Account
{
    public class UserController: ControllerBase
    {
        [HttpGet]
        public async Task<PagingOutput<User>> GetActionPaged([FromQuery]GetActionPagedInput input)
        {
            return await ActionService.Instance.GetActionPaged(input);
        }

        [HttpGet]
        public async Task<ActionInfo> Get(long id)
        {
            return await ActionService.Instance.Get(id);
        }

        [HttpPost]
        public async Task<bool> Add(ActionInfo input)
        {
            return await ActionService.Instance.Add(input);
        }

        [HttpPost]
        public async Task<bool> Update(ActionInfo input)
        {
            return await ActionService.Instance.Update(input);
        }

        [HttpPost]
        public async Task<bool> Delete(long id)
        {
            return await ActionService.Instance.Delete(id);
        }
    }
}
