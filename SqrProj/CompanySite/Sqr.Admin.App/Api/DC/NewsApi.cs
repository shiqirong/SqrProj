using Sqr.Admin.App.Api.DC.Dtos;
using Sqr.Common.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.Admin.App.Api.DC
{
    public class NewsApi:ApiBase
    {
        public async Task<PageResult<GetNewsListOutput>> GetNewsList(GetNewsListInput input)
        {
            return await Get<PageResult<GetNewsListOutput>>(ApiUrl + "Api/News/GetNewsList", input);
        }
    }
}
