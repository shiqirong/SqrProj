using Sqr.Admin.App.Api.DC;
using Sqr.Admin.App.Api.DC.Dtos;
using Sqr.Common;
using Sqr.Common.Paging;
using Sqr.Common.Response;
using Sqr.DC.Dtos.News;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.Admin.App.News
{
    public class NewsBusiness
    {
        public async Task<ResultMo<PagingOutput<NewsInfoDto>>> GetNewsList(NewsInfoQueryDto input,int page,int limit)
        {
            return await   NewsApi.Instance.GetNewsPaged(input,page,limit);
        }
    }
}
