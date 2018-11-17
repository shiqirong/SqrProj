using Sqr.Common.Helper;
using Sqr.Common.Response;
using Sqr.DC.BLL.News.Dtos;
using Sqr.DC.EF.Models;
using Sqr.DC.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.DC.BLL.News
{
    public class BLL_News
    {
        public async Task<PageResult<GetNewsListOutput>> GetListAsync(PageRequest input)
        {
            var result= await new NewsInfoRepository().QueryPagedAsync(input, c => c.Ispublished == 1, q => q.OrderBy(c => c.PublishedTime));
            return result.MapTo<PageResult<GetNewsListOutput>>();
        }
    }
}
