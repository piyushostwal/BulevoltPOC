using System.Collections.Generic;

namespace Bluevolt.POC.Common.Core
{
    public class BaseSearchResult<IEntity> : IBaseSearchResult<IEntity>
    {
        #region Properties
        
        public long TotalCount { get; set; }
        public IList<IEntity> Items { get; set; } 

        #endregion
    }
}
