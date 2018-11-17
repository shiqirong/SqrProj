using Sqr.Admin.App.Api.DC;
using Sqr.Admin.App.Api.DC.Dtos;
using Sqr.Common.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.Admin.App.News
{
    public class NewsBusiness
    {
        public async Task<PageResult<GetNewsListOutput>> GetNewsList(GetNewsListInput input)
        {
            return await new NewsApi().GetNewsList(input);
        }
    }
}
