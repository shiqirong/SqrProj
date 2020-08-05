using Microsoft.AspNetCore.Mvc;
using Sqr.Common;
using Sqr.Common.Paging;
using Sqr.DC.Dtos.Account;
using Sqr.DC.Entities;
using Sqr.DC.Services.Account;
using System.Threading.Tasks;

namespace Sqr.DC.WebApi.Controllers.Account
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ActionController : ControllerBase
    {
        [HttpGet]
        public async Task<PagingOutput<ActionInfo>> GetActionPaged([FromQuery]GetActionPagedInput input)
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
