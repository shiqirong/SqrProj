using Sqr.Common;
using Sqr.DC.Business;
using System.Collections.Generic;
using Sqr.Common.Helper;
using System.Web.Http;
using Sqr.DC.WebApi.Controllers.VModels;

namespace Sqr.DC.WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class ActionInfoController: ApiController
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
