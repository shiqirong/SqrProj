using Sqr.Common;
using Sqr.Common.IOC;
using Sqr.Common.Paging;
using Sqr.DC.BLL.Security.DTO;
using Sqr.DC.Entities;
using Sqr.DC.Repositories;
using System.Collections.Generic;

namespace Sqr.DC.Services.Security
{
    public class B_Account:BaseService
    {
        
        public PagingOutput<Accounts> GetPageList(GetPageListInput input)
        {
            
            return AutofacConfig.Resolve<AccountsRepository>().GetPageList(
                input.PageIndex,
                input.PageSize,
                PredicateExtensionses.True<Accounts>().AndIf(a => a.LoginAccount == input.LoginAccount, !string.IsNullOrWhiteSpace(input.LoginAccount))
                                                      .AndIf(a => a.LoginName.Contains(input.LoginName), !string.IsNullOrWhiteSpace(input.LoginName))
                                                      .And(a => a.IsDeleted == input.IsDeleted)
                                                      .AndIf(a => a.Email == input.Email, !string.IsNullOrWhiteSpace(input.Email))
                                                      .AndIf(a => a.CreateTime >= input.CreateTimeBegin.Value, input.CreateTimeBegin.HasValue)
                                                      .AndIf(a => a.CreateTime < input.CreateTimeEnd.Value, input.CreateTimeEnd.HasValue)
                                                      .AndIf(a => a.DeleteTime >= input.DeleteTimeBegin.Value, input.DeleteTimeBegin.HasValue)
                                                      .AndIf(a => a.DeleteTime < input.DeleteTimeEnd.Value, input.DeleteTimeEnd.HasValue),
                a => a.CreateTime,
                true
            );
        }

        public List<Accounts> GeList()
        {
            return AutofacConfig.Resolve<AccountsRepository>().GetMany(null);
        }

        public Accounts GetById(long id)
        {
            return AutofacConfig.Resolve<AccountsRepository>().GetById(id);
        }

        public long Add(Accounts model)
        {
            model.Id = IdHelper.GetNewId();
            if (AutofacConfig.Resolve<AccountsRepository>().Add(model) > 0)
                return model.Id;
            return 0;
        }

        public int Add(List<Accounts> models)
        {
            models.ForEach(c => c.Id = IdHelper.GetNewId());
            return AutofacConfig.Resolve<AccountsRepository>().Add(models);
        }

        public bool Update(Accounts model)
        {
            return AutofacConfig.Resolve<AccountsRepository>().Update(model)>0;
        }

        public int Update(List<Accounts> models)
        {
            return AutofacConfig.Resolve<AccountsRepository>().Update(models) ;
        }
    }
}
