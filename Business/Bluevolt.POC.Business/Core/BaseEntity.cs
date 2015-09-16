using Bluevolt.POC.Common;
using Bluevolt.POC.Common.Core;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Configuration;

namespace Bluevolt.POC.Business
{
    public abstract class BaseEntity<IEntity, IEntitySearch>
        where IEntity : IBaseEntity<IEntity, IEntitySearch>
    {
        #region Declaration

        public long ID { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        #endregion

        #region Methods

        public IBaseSearchResult<IEntity> Search(IEntitySearch entity)
        {
            return GetDAO().Search(entity);
        }

        public bool Save(IEntity entity)
        {
            return GetDAO().Save(entity);
        }


        public bool Remove(IEntity entity)
        {
            return GetDAO().Remove(entity);
        }

        protected abstract IBaseDao<IEntity, IEntitySearch> GetDAO();
        
        #endregion
    }
}
