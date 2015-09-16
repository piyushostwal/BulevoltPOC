using System.Collections.Generic;

namespace Bluevolt.POC.Common.Core
{
    public interface IBaseSearchResult<IEntity>
    {
        #region Properties
        
        long TotalCount { get; set; }
        IList<IEntity> Items { get; set; } 

        #endregion
    }
}
