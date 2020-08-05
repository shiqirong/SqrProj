//-----------------------------------------------------------------------
// <copyright file=" ActioninfoRespository.cs" company="xxxx Enterprises">
// * Copyright (C) 2019 xxxx Enterprises All Rights Reserved
// * version : 4.0.30319.42000
// * author  : auto generated by T4
// * FileName: ActioninfoRespository.cs
// * history : Created by T4 03/11/2019 21:19:09 
// </copyright>
//-----------------------------------------------------------------------
using Sqr.Common.Paging;
using Sqr.Dapper.Linq.Common;
using Sqr.DC.Dtos.Account;
using Sqr.DC.Entities;
using System;
using System.Threading.Tasks;

namespace Sqr.DC.Repositories
{
    /// <summary>
    /// actioninfo Respository
    /// </summary>   
    public partial class ActioninfoRepository :BaseRepository<ActioninfoRepository, ActionInfo>
    {
        public async Task<PagingOutput<ActionInfo>> GetActionPaged(GetActionPagedInput input)
        {
            var output= await  QueryPagedAsync<ActionInfo>(c =>
            c.IsDeleted==0
            && WhereIf<ActionInfo>(!string.IsNullOrWhiteSpace(input.Action),()=>c.Action == input.Action)
            && WhereIf<ActionInfo>(!string.IsNullOrWhiteSpace(input.Controller), () => c.Controller == input.Controller)
            && WhereIf<ActionInfo>(!string.IsNullOrWhiteSpace(input.Category), () => c.Category == input.Category)
            && WhereIf<ActionInfo>(!string.IsNullOrWhiteSpace(input.Name), () => c.Category.Contains(input.Name)),
            
            new PagedQueryParams()
            {
                PageIndex = input.PageIndex,
                PageSize = input.PageSize
            });

            return new PagingOutput<ActionInfo>()
            {
                Total = output.Total,
                PageIndex = input.PageIndex,
                PageSize = input.PageSize,
                Rows = output.Data
            };

        }

        public async Task<int> Update(ActionInfo input)
        {
            return Update(c => new
            {
                input.Action,
                input.Category,
                input.Controller,
                input.Name,
                input.Parameters,
                input.ParentId,
                UpdateTime=DateTime.Now,
                input.UpdateUser,
                input.SystemId,
                input.SystemName
            }, c => c.Id == input.Id);
        }


    }
}
