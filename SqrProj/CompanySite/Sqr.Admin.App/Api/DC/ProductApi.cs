using Sqr.Common;
using Sqr.Common.Paging;
using Sqr.DC.Dtos.Co;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.Admin.App.Api.DC
{
    public class ProductApi : ApiBase<ProductApi>
    {
        public async Task<ResultMo<PagingOutput<ProductInfoDto>>> GetPaged( ProductQueryDto input, int page, int limit)
        {
            return await Get<PagingOutput<ProductInfoDto>>(ApiUrl + $"Api/Product/GetPaged?page={page}&limit={limit}", input);
        }

        public async Task<ResultMo<ProductInfoDto>> Get(long id)
        {
            return await Get<ProductInfoDto>(ApiUrl + $"Api/Product/Get?id={id}", null);
        }

        public async Task<ResultMo<bool>> Add(ProductInfoDto input)
        {
            return await Post<bool>(ApiUrl + $"Api/Product/Add", input);
        }

        public async Task<ResultMo<bool>> Update(ProductInfoDto input)
        {
            return await Post<bool>(ApiUrl + $"Api/Product/Update", input);
        }

        public async Task<ResultMo<bool>> Delete(long id)
        {
            return await Post<bool>(ApiUrl + $"Api/Product/Delete", new { id });
        }

        public async Task<ResultMo<List<ProductCategoryDto>>> GetProductCategory()
        {
            return await Get< List < ProductCategoryDto >> (ApiUrl + $"Api/Product/GetProductCategory", null);
        }
    }
}
