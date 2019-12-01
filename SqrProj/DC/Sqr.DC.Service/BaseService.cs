using Sqr.Common.IOC;
using Sqr.Common.Paging;
using Sqr.DC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sqr.DC.Services
{
    public class BaseService<TEntity>
    {

        public PagingOutput<TEntity> GetPageList(PagingInput input)
        {
            return AutofacConfig.Resolve<BaseRepository<TEntity>>().GetPageList(
                input.PageIndex,
                input.PageSize,
                null,
                a => a.CreateTime,
                true
            );
        }

        public List<TEntity> GeList()
        {
            return AutofacConfig.Resolve<BaseRepository<TEntity>>().GetMany(null);
        }

        public TEntity GetById(long id)
        {
            return AutofacConfig.Resolve<BaseRepository<TEntity>>().GetById(id);
        }

        public long Add(TEntity model)
        {
            model.Id = IdHelper.GetNewId();
            if (AutofacConfig.Resolve<BaseRepository<TEntity>>().Add(model) > 0)
                return model.Id;
            return 0;
        }

        public int Add(List<TEntity> models)
        {
            models.ForEach(c => c.Id = IdHelper.GetNewId());
            return AutofacConfig.Resolve<BaseRepository<TEntity>>().Add(models);
        }

        public bool Update(TEntity model)
        {
            return AutofacConfig.Resolve<BaseRepository<TEntity>>().Update(model) > 0;
        }

        public int Update(List<TEntity> models)
        {
            return AutofacConfig.Resolve<BaseRepository<TEntity>>().Update(models);
        }
    }
}
