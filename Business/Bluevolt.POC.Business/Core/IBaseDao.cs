using Bluevolt.POC.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluevolt.POC.Business.Core
{
    public interface IBaseDao<IEntity, IEntitySearch>
    //where IEntity : IBaseEntity<IEntity, IEntitySearch>
    //where IEntitySearch : IBaseSearch
    {
        IBaseSearchResult<IEntity> Search(IEntitySearch entity);
        IList<long> Save(IList<IEntity> entity);
        bool Remove(IEntity entity);
       
    }
}
