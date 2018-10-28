using Microsoft.AspNetCore.Mvc;
using Sqr.Common;
using Sqr.DC.Business;
using System.Collections.Generic;
using WebApi.Controllers.VModels;
using Sqr.Common.Helper;

namespace WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ActionInfoController: ControllerBase
    {
        public ActionInfoBusiness _business { get; set; }

        public ActionInfoController(ActionInfoBusiness business)
        {
            this._business = business;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ResultMo<List<ActionInfo_List_Output>> List()
        {
            var list= _business.GeList();
            return new ResultMo<List<ActionInfo_List_Output>>()
            {
                Data = list.MapTo<List<ActionInfo_List_Output>>()
            };
        }
    }
}
