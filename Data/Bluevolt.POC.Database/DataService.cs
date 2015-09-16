using Bluevolt.POC.Common;
using Bluevolt.POC.Common.Core;

namespace Bluevolt.POC.Database
{
    public class DataService: IDataService
    {
        #region Methods
        
        public IBaseSearchResult<IUserDetails> Search(IUserDetailsSearch searchModel)
        {
            return new UserDetailsDao().Search(searchModel);
        }

        public bool Save(IUserDetails userDetails)
        {
            return new UserDetailsDao().Save(userDetails);
        }

        public bool Remove(IUserDetails userDetails)
        {
            return new UserDetailsDao().Remove(userDetails);
        } 

        #endregion
    }
}
