//-----------------------------------------------------------------------
// <copyright file=" ProductinfoRespository.cs" company="xxxx Enterprises">
// * Copyright (C) 2019 xxxx Enterprises All Rights Reserved
// * version : 4.0.30319.42000
// * author  : auto generated by T4
// * FileName: ProductinfoRespository.cs
// * history : Created by T4 03/11/2019 21:19:09 
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Sqr.Common.Helper;
using Sqr.Common.Paging;
using Sqr.Dapper.Linq.Common;
using Sqr.DC.Dtos.Co;
using Sqr.DC.Entities;


namespace Sqr.DC.Repositories
{
    /// <summary>
    /// productinfo Respository
    /// </summary>   
    public partial class ProductinfoRepository : BaseRepository<ProductinfoRepository, Productinfo>
    {
        public async Task<PagingOutput<ProductInfoDto>> GetPagedAsync(PagingInput<ProductQueryDto> input)
        {
            var output = await QueryPagedAsync<Productinfo>(c =>
            c.IsDeleted == 0
            && WhereIf<Productinfo>(!string.IsNullOrWhiteSpace(input.InputData.Name), () => c.Name.Contains(input.InputData.Name))
            && WhereIf<Productinfo>(input.InputData.Category.HasValue, () => c.Category == input.InputData.Category.Value)
             && WhereIf<Productinfo>(!string.IsNullOrWhiteSpace(input.InputData.Model), () => c.Model.Contains(input.InputData.Model)),
            new PagedQueryParams()
            {
                PageIndex = input.Page,
                PageSize = input.Limit
            });

            return new PagingOutput<ProductInfoDto>()
            {
                Total = output.Total,
                PageIndex = input.Page,
                PageSize = input.Limit,
                Rows = output.Data.MapTo<List<ProductInfoDto>>()
            };
        }
        

        public async Task<bool> UpdateAsync(Productinfo mo)
        {
            return await UpdateAsync(c => new {
                mo.Content,
                mo.Imagebig,
                mo.Imagesmall,
                mo.Name,
                UpdateTime = DateTime.Now,
                mo.UpdateUser
            }, c => c.Id == mo.Id) > 0;
        }

        public async Task<bool> DeleteAsync(Productinfo mo)
        {
            return await UpdateAsync(c => new {
                IsDeleted = 1,
                DeleteTime = DateTime.Now,
                mo.UpdateUser
            }, c => c.Id == mo.Id) > 0;
        }

    }
}
