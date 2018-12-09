using Sqr.Common;
using Sqr.DC.BLL.Security;
using Sqr.DC.BLL.Security.Dto;
using Sqr.DC.EF.Models;
using Sqr.DC.WebApi.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Sqr.DC.WebApi.Controllers
{
    public class SecurityController: BaseController
    {
        readonly BLL_Menu _BllMenu = null;
        readonly BLL_ActionInfo _BllActionInfo = null;

        public SecurityController(
            BLL_Menu bllMenu,
            BLL_ActionInfo bllActionInfo)
        {
            _BllMenu = bllMenu;
            _BllActionInfo = bllActionInfo;
        }

        [Route("api/Security/GetMenuList")]
        [HttpGet]
        public SqrResponse<List<GetMenuListOutput>> GetMenuList(long accountId,string systemId)
        {
            return SqrResponse<List<GetMenuListOutput>>.Ok(_BllMenu.GetMenuList(accountId,systemId));
        }

        [Route("api/Security/GetAllMenu")]
        [HttpGet]
        public SqrResponse<List<GetMenuListOutput>> GetAllMenu()
        {
            return SqrResponse<List<GetMenuListOutput>>.Ok(_BllMenu.GetAllMenu());
        }

        [Route("api/Security/GetActionInfo")]
        [HttpGet]
        public SqrResponse<ActionInfo> GetActionInfo(long id)
        {
            return SqrResponse< ActionInfo>.Ok(_BllActionInfo.GetById(id));
        }

        [Route("api/Security/AddActionInfo")]
        [HttpPost]
        public SqrResponse<long> AddActionInfo(ActionInfo model)
        {
            var id = _BllActionInfo.Add(model);
            if (id > 0)
                return SqrResponse<long>.Ok(id);
            return SqrResponse<long>.Fail();
        }

        [Route("api/Security/UpdateActionInfo")]
        [HttpPost]
        public SqrResponse<bool> UpdateActionInfo(ActionInfo model)
        {
            return SqrResponse<bool>.Ok(_BllActionInfo.Update(model)>0);
        }

        [Route("api/Security/DeleteActionInfo")]
        [HttpPost]
        public SqrResponse<bool> DeleteActionInfo(long id)
        {
            return SqrResponse<bool>.Ok(_BllActionInfo.Delete(id)>0);
        }

    }
}