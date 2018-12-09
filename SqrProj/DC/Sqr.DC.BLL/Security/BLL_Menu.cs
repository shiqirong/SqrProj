using Sqr.DC.BLL.Security.Dto;
using Sqr.DC.EF.Models;
using Sqr.DC.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sqr.Common.Helper;


namespace Sqr.DC.BLL.Security
{
    public class BLL_Menu:BLL_Base
    {
        public VAccountActioninfoRepository VAccountActionInfoRep { get; set; }
        public string SystemId { get; private set; }

        public List<GetMenuListOutput> GetMenuList(long accountId,string systemId)
        {
            return VAccountActionInfoRep.GetMany(c => c.AccountId == accountId  && c.SystemId==systemId && c.IsDeleted==0)?.MapTo<List<GetMenuListOutput>>() ;
        }

        public List<GetMenuListOutput> GetAllMenu()
        {
            return VAccountActionInfoRep.GetAll()?.MapTo<List<GetMenuListOutput>>();
        }
    }
}
