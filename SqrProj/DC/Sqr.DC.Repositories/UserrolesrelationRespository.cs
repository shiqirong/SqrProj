//-----------------------------------------------------------------------
// <copyright file=" UserrolesrelationRespository.cs" company="xxxx Enterprises">
// * Copyright (C) 2019 xxxx Enterprises All Rights Reserved
// * version : 4.0.30319.42000
// * author  : auto generated by T4
// * FileName: UserrolesrelationRespository.cs
// * history : Created by T4 03/11/2019 21:19:09 
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sqr.DC.Entities;


namespace Sqr.DC.Repositories
{
    /// <summary>
    /// userrolesrelation Respository
    /// </summary>   
    public partial class UserrolesrelationRepository : BaseRepository<UserrolesrelationRepository, Userrolesrelation>
    {
        public async Task<int> RemoveByRoleId(long roleId)
        {
            return await DeleteAsync<Userrolesrelation>(c => c.RoleId == roleId);
        }

        public async Task<IList<Userrolesrelation>> GetByRoleId(long roleId)
        {
            return await QueryListAsync<Userrolesrelation>(c => c.RoleId == roleId && c.IsDeleted==0);
        }
    }
}
