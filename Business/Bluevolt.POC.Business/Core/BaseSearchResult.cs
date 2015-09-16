

using Bluevolt.POC.Common.Core;
using System.Collections.Generic;

namespace Bluevolt.POC.Business.Core
{
    public class BaseSearchResult<IEntity> : IBaseSearchResult<IEntity>
    {  
        public long TotalCount { get; set; }
        public IList<IEntity> Items { get; set; }
    }
}
