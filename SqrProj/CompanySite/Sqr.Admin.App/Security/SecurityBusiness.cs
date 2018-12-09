using Sqr.Admin.App.Api.DC;
using Sqr.Admin.App.Api.DC.Dtos;
using Sqr.Admin.App.Security.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Sqr.Common.Helper;

namespace Sqr.Admin.App.Security
{
    public class SecurityBusiness
    {
        public async Task<List<GetMenuListOutput>> GetMenuList(long accountId, string systemId)
        {
            return await new SecurityApi().GetMenuList(accountId, systemId);
        }

        public async Task<List<MenuTree>> GetAllMenuTree()
        {
            //List<MenuTree> output = new List<MenuTree>();
            var result = await new SecurityApi().GetAllMenu();
            //if (result != null && result.Count > 0)
            //{
            //    output.AddRange(result.Where(c => c.ParentId == 0).Select(c => c.MapTo<MenuTree>()).ToList());
            //    FillChildren(output, result);
            //}
            return result?.MapTo<List<MenuTree>>();
        }

        public async Task<ActionInfo> GetActionInfo(long id)
        {
            return await  new SecurityApi().GetActionInfo(id);
        }

        public async Task<long> AddActionInfo(ActionInfo model)
        {
            return await new SecurityApi().AddActionInfo(model);
        }

        public async Task<bool> UpdateActionInfo(ActionInfo model)
        {
            return await new SecurityApi().UpdateActionInfo(model);
        }

        void FillChildren(List<MenuTree> pTree, List<GetMenuListOutput> result)
        {
            foreach (var p in pTree)
            {
                var children = result.Where(c => c.ParentId == p.Id).Select(c => c.MapTo<MenuTree>()).ToList();
                if (children != null && children.Count > 0)
                {
                    p.Children = children;
                    FillChildren(p.Children,result);
                }
            }
        }
    }
}
