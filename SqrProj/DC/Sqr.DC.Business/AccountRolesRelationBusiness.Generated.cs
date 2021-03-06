//-----------------------------------------------------------------------
// <copyright file=" AccountRolesRelationBusiness.Generated.cs" company="xxxx Enterprises">
// * Copyright (C) 2018 xxxx Enterprises All Rights Reserved
// * version : 4.0.30319.42000
// * author  : auto generated by T4
// * FileName: AccountRolesRelationBusiness.cs
// * history : Created by T4 10/13/2018 17:38:57 
// </copyright>
//-----------------------------------------------------------------------
using Sqr.Common;
using Sqr.Common.Paging;
using Sqr.DC.BLL.Security.DTO;
using Sqr.DC.EF.Models;
using Sqr.DC.EF.Repositories;
using System.Collections.Generic;
using Sqr.Common.IOC;

namespace Sqr.DC.Business
{
    /// <summary>
    /// account_roles_relation Respository
    /// </summary>   
    public partial class AccountRolesRelationBusiness :BaseBusiness
    {
		
        public PagingOutput<AccountRolesRelation> GetPageList(PagingInput input)
        {
            return AutofacConfig.Resolve<AccountRolesRelationRepository>().GetPageList(
                input.PageIndex,
                input.PageSize,
                null,
                a => a.CreateTime,
                true
            );
        }

        public List<AccountRolesRelation> GeList()
        {
            return AutofacConfig.Resolve<AccountRolesRelationRepository>().GetMany(null);
        }

        public AccountRolesRelation GetById(long id)
        {
            return AutofacConfig.Resolve<AccountRolesRelationRepository>().GetById(id);
        }

        public long Add(AccountRolesRelation model)
        {
            model.Id = IdHelper.GetNewId();
            if (AutofacConfig.Resolve<AccountRolesRelationRepository>().Add(model) > 0)
                return model.Id;
            return 0;
        }

        public int Add(List<AccountRolesRelation> models)
        {
            models.ForEach(c => c.Id = IdHelper.GetNewId());
            return AutofacConfig.Resolve<AccountRolesRelationRepository>().Add(models);
        }

        public bool Update(AccountRolesRelation model)
        {
            return AutofacConfig.Resolve<AccountRolesRelationRepository>().Update(model)>0;
        }

        public int Update(List<AccountRolesRelation> models)
        {
            return AutofacConfig.Resolve<AccountRolesRelationRepository>().Update(models) ;
        }
	}
}
