using Bluevolt.POC.Common.Core;
using System;

namespace Bluevolt.POC.Common
{
    public interface IBaseEntity<IEntity,IEntitySearch>
    {
        #region Property
        
        long ID { get; set; }
        long? CreatedBy { get; set; }
        DateTime? CreatedOn { get; set; }
        long? UpdatedBy { get; set; }
        DateTime? UpdatedOn { get; set; }
        
        #endregion

        #region Method
        
        IBaseSearchResult<IEntity> Search(IEntitySearch entitySearch);
        bool Save(IEntity entities);
        bool Remove(IEntity entity);
        
        #endregion
    }
}
