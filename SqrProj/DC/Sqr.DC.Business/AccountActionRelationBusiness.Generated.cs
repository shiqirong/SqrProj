//-----------------------------------------------------------------------
// <copyright file=" AccountActionRelationBusiness.Generated.cs" company="xxxx Enterprises">
// * Copyright (C) 2018 xxxx Enterprises All Rights Reserved
// * version : 4.0.30319.42000
// * author  : auto generated by T4
// * FileName: AccountActionRelationBusiness.cs
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
    /// account_action_relation Respository
    /// </summary>   
    public partial class AccountActionRelationBusiness :BaseBusiness
    {
		
        public PagingOutput<AccountActionRelation> GetPageList(PagingInput input)
        {
            return AutofacConfig.Resolve<AccountActionRelationRepository>().GetPageList(
                input.PageIndex,
                input.PageSize,
                null,
                a => a.CreateTime,
                true
            );
        }

        public List<AccountActionRelation> GeList()
        {
            return AutofacConfig.Resolve<AccountActionRelationRepository>().GetMany(null);
        }

        public AccountActionRelation GetById(long id)
        {
            return AutofacConfig.Resolve<AccountActionRelationRepository>().GetById(id);
        }

        public long Add(AccountActionRelation model)
        {
            model.Id = IdHelper.GetNewId();
            if (AutofacConfig.Resolve<AccountActionRelationRepository>().Add(model) > 0)
                return model.Id;
            return 0;
        }

        public int Add(List<AccountActionRelation> models)
        {
            models.ForEach(c => c.Id = IdHelper.GetNewId());
            return AutofacConfig.Resolve<AccountActionRelationRepository>().Add(models);
        }

        public bool Update(AccountActionRelation model)
        {
            return AutofacConfig.Resolve<AccountActionRelationRepository>().Update(model)>0;
        }

        public int Update(List<AccountActionRelation> models)
        {
            return AutofacConfig.Resolve<AccountActionRelationRepository>().Update(models) ;
        }
	}
}
