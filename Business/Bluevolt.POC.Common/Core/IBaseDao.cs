namespace Bluevolt.POC.Common.Core
{
    public interface IBaseDao<IEntity, IEntitySearch>
    {
        #region Methods
        
        IBaseSearchResult<IEntity> Search(IEntitySearch entity);
        bool Save(IEntity entity);
        bool Remove(IEntity entity); 

        #endregion
    }
}
