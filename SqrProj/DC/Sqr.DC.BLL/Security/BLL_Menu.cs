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

        public List<GetMenuListOutput> GetMenuList(long accountId)
        {
            return VAccountActionInfoRep.GetMany(c => c.AccountId == accountId && c.IsDeleted == false)?.MapTo<List<GetMenuListOutput>>() ;
        }
    }
}
