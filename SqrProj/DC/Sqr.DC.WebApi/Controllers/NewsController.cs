using Sqr.Common.Response;
using Sqr.DC.BLL.News;
using Sqr.DC.BLL.News.Dtos;
using Sqr.DC.WebApi.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Sqr.DC.WebApi.Controllers
{
    public class NewsController: BaseController
    {
        [HttpGet]
        public async Task<PageResult<GetNewsListOutput>> GetNewsList([FromUri]PageRequest input)
        {
            return await new BLL_News().GetListAsync(input);
        }
    }
}