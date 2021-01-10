using Microsoft.AspNetCore.Mvc;
using Sqr.Common;
using Sqr.Common.Paging;
using Sqr.DC.Dtos.Co;
using Sqr.DC.Services.Co;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sqr.DC.WebApi.Controllers.Co
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public async Task<PagingOutput<ProductInfoDto>> GetPaged([FromQuery]ProductQueryDto input, int page, int limit)
        {
            return await ProductService.Instance.GetPaged(new PagingInput<ProductQueryDto>
            {
                Page = page,
                Limit = limit,
                InputData = input
            });

        }

        [HttpGet]
        public async Task<ProductInfoDto> Get(long id)
        {
            return await ProductService.Instance.Get(id);
        }

        [HttpPost]
        public async Task<bool> Add(ProductInfoDto input)
        {
            return await ProductService.Instance.Add(input);
        }

        [HttpPost]
        public async Task<bool> Update(ProductInfoDto input)
        {
            return await ProductService.Instance.Update(input);
        }

        [HttpPost]
        public async Task<bool> Delete(ProductInfoDto input)
        {
            return await ProductService.Instance.Delete(input);
        }

        [HttpGet]
        public async Task<IList<ProductCategoryDto>> GetProductCategory()
        {
            return await ProductService.Instance.GetAll();
        }
    }
}
