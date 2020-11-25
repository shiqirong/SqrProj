using Sqr.Admin.App.Api.DC.Dtos;
using Sqr.Common;
using Sqr.Common.Paging;
using Sqr.Common.Response;
using Sqr.DC.Dtos.News;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.Admin.App.Api.DC
{
    public class NewsApi:ApiBase<NewsApi>
    {
        public async Task<ResultMo<PagingOutput<NewsInfoDto>>> GetNewsPaged(NewsInfoQueryDto input,int page,int limit)
        {
            return await Get<PagingOutput<NewsInfoDto>>(ApiUrl + $"Api/News/GetNewsPaged?page={page}&limit={limit}", input);
        }

        public async Task<ResultMo<NewsInfoDto>> Get(long id)
        {
            return await Get<NewsInfoDto>(ApiUrl + $"Api/News/Get?id={id}",null);
        }

        public async Task<ResultMo<bool>> Add(NewsInfoDto input)
        {
            return await Post<bool>(ApiUrl + $"Api/News/Add", input);
        }

        public async Task<ResultMo<bool>> Update(NewsInfoDto input)
        {
            return await Post<bool>(ApiUrl + $"Api/News/Update", input);
        }

        public async Task<ResultMo<bool>> Delete(long id)
        {
            return await Post<bool>(ApiUrl + $"Api/News/Delete", new { id});
        }
    }
}
