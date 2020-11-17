//-----------------------------------------------------------------------
// <copyright file=" NewsinfoRespository.cs" company="xxxx Enterprises">
// * Copyright (C) 2019 xxxx Enterprises All Rights Reserved
// * version : 4.0.30319.42000
// * author  : auto generated by T4
// * FileName: NewsinfoRespository.cs
// * history : Created by T4 03/11/2019 21:19:09 
// </copyright>
//-----------------------------------------------------------------------
using Sqr.Common.Helper;
using Sqr.Common.Paging;
using Sqr.Dapper.Linq.Common;
using Sqr.DC.Dtos.News;
using Sqr.DC.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sqr.DC.Repositories
{
    /// <summary>
    /// newsinfo Respository
    /// </summary>   
    public partial class NewsinfoRepository :BaseRepository<NewsinfoRepository,  Newsinfo>
    {
        public async Task<PagingOutput<NewsInfoDto>> GetPaged(PagingInput<NewsInfoQueryDto> input)
        {
            var output = await QueryPagedAsync<Newsinfo>(c =>
            c.IsDeleted == 0
            && WhereIf<Newsinfo>(!string.IsNullOrWhiteSpace(input.InputData.Title), () => c.Title.Contains( input.InputData.Title))
            && WhereIf<Newsinfo>(input.InputData.IsHot.HasValue, () => c.IsHot == input.InputData.IsHot.Value)
             && WhereIf<Newsinfo>(input.InputData.IsPublished.HasValue, () => c.IsHot == input.InputData.IsPublished.Value)
            && WhereIf<Newsinfo>(input.InputData.PublishedTimeStart.HasValue, () => c.Publishedtime >= input.InputData.PublishedTimeStart.Value)
            && WhereIf<Newsinfo>(input.InputData.PublishedTimeEnd.HasValue, () => c.Publishedtime <= input.InputData.PublishedTimeEnd.Value),
            c => new {c.OrderIndex,c.Publishedtime},
            new PagedQueryParams()
            {
                PageIndex = input.Page,
                PageSize = input.Limit
            });

            return new PagingOutput<NewsInfoDto>()
            {
                Total = output.Total,
                PageIndex = input.Page,
                PageSize = input.Limit,
                Rows = output.Data.MapTo<List<NewsInfoDto>>()
            };

        }

        public async Task<bool> UpdateAsync(Newsinfo mo)
        {
            return await UpdateAsync(c => new {
                mo.Content,
                mo.Content2,
                mo.Imagebig,
                mo.Imagesmall,
                mo.IsHot,
                mo.Ispublished,
                mo.OrderIndex,
                mo.Publishedtime,
                mo.Title,
                mo.Title2,
                UpdateTime=DateTime.Now,
                mo.UpdateUser
            }, c => c.Id == mo.Id) > 0;
        }

        public async Task<bool> DeleteAsync(Newsinfo mo)
        {
            return await UpdateAsync(c => new {
                IsDeleted=1,
                UpdateTime = DateTime.Now,
                mo.UpdateUser
            }, c => c.Id == mo.Id) > 0;
        }
    }
}
