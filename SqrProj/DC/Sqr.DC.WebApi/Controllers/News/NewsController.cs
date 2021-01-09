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
        [HttpGet]
        public async Task<PagingOutput<NewsInfoDto>> GetNewsPaged([FromQuery]NewsInfoQueryDto input, int page, int limit )
        {
            return await NewsService.Instance.GetNewsPaged(new PagingInput<NewsInfoQueryDto> {
                Page=page,
                Limit=limit,
                InputData=input
            });

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
        public async Task<bool> Delete(NewsInfoDto input)
        {
            return await NewsService.Instance.Delete(input);
        }
    }
}
