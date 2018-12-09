using Sqr.Common.Helper;
using Sqr.DC.EF.Models;
using Sqr.DC.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.DC.BLL.Security
{
    public class BLL_ActionInfo:BLL_Base
    {
        ActionInfoRepository _ActionInfoRepository = null;

        public BLL_ActionInfo(ActionInfoRepository actionInfoRepository)
        {
            _ActionInfoRepository = actionInfoRepository;
        }

        public ActionInfo GetById(long id)
        {
            return _ActionInfoRepository.GetById(id);
        }

        public long Add(ActionInfo model)
        {
            model.Id = NumUtil.SnowNum();
            if (_ActionInfoRepository.Add(model) > 0)
                return model.Id;
            return 0;
        }

        public int Update(ActionInfo model)
        {
            return _ActionInfoRepository.Update(model
                , c => c.IsDeleted
                , c1 => c1.Name
                , c2 => c2.Parameters
                , c3 => c3.ParentId
                , c4 => c4.Action
                , c5 => c5.Category
                , c6 => c6.Controller)  ;
        }

        public int Delete(long id)
        {
            return _ActionInfoRepository.Delete(id);
        }
    }
}
