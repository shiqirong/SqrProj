using Sqr.SSO.Web.API.DcApi.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.SSO.Web.API.DcApi
{
    public class DcAPI:ApiBase
    {
        string _baseUrl = "";
        private DcAPI() { }

        private static DcAPI _instance = null;
        public DcAPI Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DcAPI();
                return _instance;
            }
        }

        public async Task<LoginOutput> Login(LoginInput input)
        {
            return await Post<LoginOutput>($"{_baseUrl}/Account/LogIn", input);
        }
    }
}
