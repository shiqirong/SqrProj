using Microsoft.AspNetCore.Mvc;
using Sqr.Common.Paging;
using Sqr.DC.Dtos.News;
using Sqr.DC.Services.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sqr.DC.WebApi.Controllers.News
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        [HttpPost]
        public async Task<PagingOutput<NewsInfoDto>> GetNewsPaged([FromBody]PagingInput<NewsInfoQueryDto> input)
        {
            return await NewsService.Instance.GetNewsPaged(input);

        }

        [HttpGet]
        public async Task<NewsInfoDto> Get(long id)
        {
            return await NewsService.Instance.Get(id);
        }

        [HttpPost]
        public async Task<bool> Add(NewsInfoDto input)
        {
            return await NewsService.Instance.Add(input);
        }

        [HttpPost]
        public async Task<bool> Update(NewsInfoDto input)
        {
            return await NewsService.Instance.Update(input);
        }

        [HttpPost]
        public async Task<bool> Delete(long id)
        {
            return await NewsService.Instance.Delete(id);
        }
    }
}
