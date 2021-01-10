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
    public class NewsService : ServiceBase<NewsService>
    {
        public async Task<PagingOutput<NewsInfoDto>> GetNewsPaged(PagingInput<NewsInfoQueryDto> input)
        {
            return await NewsinfoRepository.Instance.GetPaged(input);

        }

        public async Task<NewsInfoDto> Get(long id)
        {
            var output= await NewsinfoRepository.Instance.GetByIdSingleAsync(id);
            return output.MapTo<NewsInfoDto>();
        }

        public async Task<bool> Add(NewsInfoDto input)
        {
            return await NewsinfoRepository.Instance.InsertAsync(new Newsinfo()
            {
                Content = input.Content,
                Content2 = input.Content2,
                CreateTime = DateTime.Now,
                Imagebig = input.Imagebig,
                Imagesmall = input.Imagesmall,
                IsDeleted = 0,
                IsHot = input.IsHot,
                IsPublished = input.IsPublished,
                OrderIndex = NewsinfoRepository.Instance.GetMaxOrderIndex(),
                Publishedtime = input.IsPublished ? DateTime.Now : DateTime.MinValue,
                Title = input.Title,
                Title2 = input.Title2
            }) > 0;
        }

        public async Task<bool> Update(NewsInfoDto input)
        {
            return await NewsinfoRepository.Instance.UpdateAsync(input.MapTo<Newsinfo>()) ;
        }

        public async Task<bool> Delete(NewsInfoDto input)
        {
            return await NewsinfoRepository.Instance.DeleteAsync(new Newsinfo()
            {
                Id= input.Id
            });
        }
        
    }
}
