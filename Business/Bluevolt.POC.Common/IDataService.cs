using Bluevolt.POC.Common.Core;
namespace Bluevolt.POC.Common
{
    public interface IDataService
    {
        #region Methods

        IBaseSearchResult<IUserDetails> Search(IUserDetailsSearch searchModel);
        bool Save(IUserDetails userDetails);
        bool Remove(IUserDetails userDetails);

        #endregion
    }
}
