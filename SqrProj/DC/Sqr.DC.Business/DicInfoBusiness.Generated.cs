//-----------------------------------------------------------------------
// <copyright file=" DicInfoBusiness.Generated.cs" company="xxxx Enterprises">
// * Copyright (C) 2018 xxxx Enterprises All Rights Reserved
// * version : 4.0.30319.42000
// * author  : auto generated by T4
// * FileName: DicInfoBusiness.cs
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
    /// dic_info Respository
    /// </summary>   
    public partial class DicInfoBusiness :BaseBusiness
    {
		
        public PagingOutput<DicInfo> GetPageList(PagingInput input)
        {
            return AutofacConfig.Resolve<DicInfoRepository>().GetPageList(
                input.PageIndex,
                input.PageSize,
                null,
                a => a.CreateTime,
                true
            );
        }

        public List<DicInfo> GeList()
        {
            return AutofacConfig.Resolve<DicInfoRepository>().GetMany(null);
        }

        public DicInfo GetById(long id)
        {
            return AutofacConfig.Resolve<DicInfoRepository>().GetById(id);
        }

        public long Add(DicInfo model)
        {
            model.Id = IdHelper.GetNewId();
            if (AutofacConfig.Resolve<DicInfoRepository>().Add(model) > 0)
                return model.Id;
            return 0;
        }

        public int Add(List<DicInfo> models)
        {
            models.ForEach(c => c.Id = IdHelper.GetNewId());
            return AutofacConfig.Resolve<DicInfoRepository>().Add(models);
        }

        public bool Update(DicInfo model)
        {
            return AutofacConfig.Resolve<DicInfoRepository>().Update(model)>0;
        }

        public int Update(List<DicInfo> models)
        {
            return AutofacConfig.Resolve<DicInfoRepository>().Update(models) ;
        }
	}
}