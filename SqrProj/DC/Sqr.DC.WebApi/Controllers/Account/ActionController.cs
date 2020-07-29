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
        public async Task<PagingOutput<Actioninfo>> GetActionPaged(GetActionPagedInput input)
        {
            return await ActionService.Instance.GetActionPaged(input);
        }
    }
}
