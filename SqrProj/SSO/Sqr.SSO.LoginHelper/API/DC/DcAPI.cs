using Sqr.Common;
using Sqr.Common.Utils;
using Sqr.SSO.LoginHelper.API.DC.Dtos;
using Sqr.SSO.Web.API.DC.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.SSO.Web.API.DC
{
    public class DcAPI:ApiBase
    {
        string _baseUrl = string.Empty;
        private DcAPI() {
            var config = ConfigUtil.GetSection("DcApiConfig");
            _baseUrl = config.GetSection("BaseUrl").Value;
        }

        private static DcAPI _instance = null;
        public static DcAPI Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DcAPI();
                return _instance;
            }
        }

        internal async Task<ResultMo<CheckIsLoginOutput>> CheckIsLogin(string accessCode)
        {
            return await Post<CheckIsLoginOutput>($"{_baseUrl}Account/CheckIsLogin", new CheckIsLoginInput { AccessCode=accessCode });
        }

        internal async Task<ResultMo<LoginOutput>> Login(LoginInput input)
        {
            return await Post<LoginOutput>($"{_baseUrl}Account/LogIn", input);
        }

        internal async Task<ResultMo<GetOrCreateAccessCode>> GetOrCreateAccessCode(string LoginId)
        {
            return await Get<GetOrCreateAccessCode>($"{_baseUrl}Account/GetOrCreateAccessCode?LoginId={LoginId}");
        }

        internal async Task<ResultMo<IList<M_SSOSite>>> GetSSOSites()
        {
            return await Get<IList<M_SSOSite>>($"{_baseUrl}Account/GetSSOSites");
        }
    }
}
