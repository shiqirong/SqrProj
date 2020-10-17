using Microsoft.AspNetCore.Mvc;
using Sqr.Admin.App.Api.DC;
using Sqr.Admin.App.Security;
using Sqr.Admin.Web.Models;
using Sqr.Admin.Web.Models.ActionManager;
using Sqr.Common;
using Sqr.DC.Dtos.Account;
using Sqr.DC.Dtos.Security;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sqr.Admin.Web.Controllers
{
    public class ActionManagerController: ControllerAdminBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult MenuList()
        {
            //return Json(Newtonsoft.Json.JsonConvert.DeserializeObject("{'msg':'true','code':0,'data':[{'permissionId':1,'permissionName':'系统管理','permissionUrl':null,'permissionType':null,'icon':null,'pid':0,'seq':0,'resType':'0'},{'permissionId':2,'permissionName':'账户管理','permissionUrl':'/link/sysUsers','permissionType':'管理登录的账户','icon':null,'pid':1,'seq':1,'resType':'1'},{'permissionId':3,'permissionName':'部门管理','permissionUrl':'/link/deparAdministrate','permissionType':'部门的管理','icon':null,'pid':1,'seq':2,'resType':'1'},{'permissionId':4,'permissionName':'角色管理','permissionUrl':'/link/sysRoleManage','permissionType':'设定角色的权限','icon':null,'pid':1,'seq':3,'resType':'1'},{'permissionId':5,'permissionName':'权限管理','permissionUrl':'/link/sysPermission','permissionType':'对权限进行编辑','icon':null,'pid':1,'seq':4,'resType':'1'},{'permissionId':6,'permissionName':'系统日志','permissionUrl':'/link/sysLog','permissionType':'系统日志','icon':null,'pid':1,'seq':5,'resType':'1'}],'count':6}"));

            var output = ActionBusiness.Instance.MenuList().Result;

            return Json( new
            {
                data = output?.Rows.ToList(),
                count = output.Total
            });
        }
        [HttpGet]
        public JsonResult MenuTree()
        {
            //return Json(Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>("[{'name':'菜单功能管理','id':'91','children':[{'name':'菜单列表','id':'92','children':null},{'name':'用户列表','id':'93','children':null}]}]"));
            //return Json(Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>("[{'id':1,'name':'zzz','open':true,'children':[{'id':2,'name':'1','open':false,'checked':true},{'id':3,'name':'2','open':false,'checked':true},{'id':17,'name':'3z','open':false,'checked':true}],'checked':true},{'id':4,'name':'评论','open':false,'children':[{'id':5,'name':'留言列表','open':false,'checked':false},{'id':6,'name':'发表留言','open':false,'checked':false},{'id':333,'name':'233333','open':false,'checked':false}],'checked':false},{'id':10,'name':'权限管理','open':false,'children':[{'id':8,'name':'用户列表','open':false,'children':[{'id':40,'name':'添加用户','open':false,'url':null,'title':'40','checked':false,'level':2,'check_Child_State':0,'check_Focus':false,'checkedOld':false,'dropInner':false,'drag':false,'parent':false},{'id':41,'name':'编辑用户','open':false,'checked':false},{'id':42,'name':'删除用户','open':false,'checked':false}],'checked':false},{'id':11,'name':'角色列表','open':false,'checked':false},{'id':13,'name':'所有权限','open':false,'children':[{'id':34,'name':'添加权限','open':false,'checked':false},{'id':37,'name':'编辑权限','open':false,'checked':false},{'id':38,'name':'删除权限','open':false,'checked':false}],'checked':false},{'id':15,'name':'操作日志','open':false,'checked':false}],'checked':false}]"));
            var root = new TreeNode()
            {
                Id = 0,
                Name = "根节点",
                Open=true
                
            };
            var output = ActionBusiness.Instance.MenuList().Result;
            if (output != null && output.Rows != null && output.Rows.Any())
            {
                Action<List<ActionDto>, TreeNode> fillTreeNode = null;
                fillTreeNode = (lst, p) =>
                  {
                      p.Children = lst.Where(c => c.ParentId == p.Id).Select(c => new TreeNode()
                      {
                          Id = c.Id,
                          Name = c.Name,
                          Open=true
                      }).ToList();
                      if (p.Children != null && p.Children.Any())
                      {
                          foreach (var child in p.Children)
                          {
                              fillTreeNode(lst, child);
                          }
                      }
                      else
                      {
                          p.Children = null;
                      }
                  };

                fillTreeNode(output.Rows.ToList(), root);
            }

            return Json(root);
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            var sites = SecurityApi.Instance.GetSSOSites().GetAwaiter().GetResult();
            var actionInfoResult = ActionBusiness.Instance.GetActionInfo(id).Result;
            VM_ActionInfo_Edit model = new VM_ActionInfo_Edit()
            {
                ActionInfo= actionInfoResult.Data,
                Sites = sites.Data?.Select(c => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Sitename
                }).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public JsonResult Edit (ActionInfo input)
        {
           var output=  ActionBusiness.Instance.Update(input).Result;

            if (output.IsError)
            {
                return Json(new ResultMo()
                {
                    Code = ResultCode.Error,
                    Message = "操作异常！"
                });
            }
            return Json(output);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var sites = SecurityApi.Instance.GetSSOSites().GetAwaiter().GetResult();
            var model = new VM_ActionInfo_Add
            {
                Sites = sites.Data?.Select(c=>new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
                {
                     Value=c.Id.ToString(),
                     Text=c.Sitename
                }).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public JsonResult Add(ActionInfo input)
        {
            var output = ActionBusiness.Instance.Add(input).Result;

            if (output.IsError)
            {
                return Json(new ResultMo()
                {
                    Code = ResultCode.Error,
                    Message = "操作异常！"
                });
            }
            return Json(output);
        }

        public JsonResult Delete(long id)
        {
            var output = ActionBusiness.Instance.Delete(id).Result;

            if (output.IsError)
            {
                return Json(new ResultMo()
                {
                    Code = ResultCode.Error,
                    Message = "操作异常！"
                });
            }
            return Json(output);
        }
    }
}
