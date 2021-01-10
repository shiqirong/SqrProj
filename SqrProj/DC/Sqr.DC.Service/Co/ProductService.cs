using Sqr.Common;
using Sqr.Common.Helper;
using Sqr.Common.Paging;
using Sqr.DC.Dtos.Co;
using Sqr.DC.Entities;
using Sqr.DC.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.DC.Services.Co
{
    public class ProductService : ServiceBase<ProductService>
    {
        public async Task<PagingOutput<ProductInfoDto>> GetPaged(PagingInput<ProductQueryDto> input)
        {
            return await ProductinfoRepository.Instance.GetPagedAsync(input);

        }

        public async Task<ProductInfoDto> Get(long id)
        {
            var output = await ProductinfoRepository.Instance.GetByIdSingleAsync(id);
            return output.MapTo<ProductInfoDto>();
        }

        public async Task<bool> Add(ProductInfoDto input)
        {
            return await ProductinfoRepository.Instance.InsertAsync(new Productinfo()
            {
                Content = input.Content,
                CreateTime = DateTime.Now,
                Imagebig = input.Imagebig,
                Imagesmall = input.Imagesmall,
                Model=input.Model,
                Category=input.Category,
                IsDeleted = 0,
                Name = input.Name
            }) > 0;
        }

        public async Task<bool> Update(ProductInfoDto input)
        {
            return await ProductinfoRepository.Instance.UpdateAsync(input.MapTo<Productinfo>());
        }

        public async Task<bool> Delete(ProductInfoDto input)
        {
            return await ProductinfoRepository.Instance.DeleteAsync(new Productinfo()
            {
                Id = input.Id
            });
        }

        public async Task<IList<ProductCategoryDto>> GetAll()
        {
            var result= await ProductcategoryRepository.Instance.GetAll();
            return result.MapTo<IList<ProductCategoryDto>>();
        }
    }
}
