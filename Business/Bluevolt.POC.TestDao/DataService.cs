using Bluevolt.POC.Common;
using Bluevolt.POC.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluevolt.POC.TestDao
{
    public class DataServiceDummy : IDataService
    {
        private TestUserDetailsDao _dummyDao = new TestUserDetailsDao();

        public IBaseSearchResult<IUserDetails> Search(IUserDetailsSearch searchModel)
        {
            return _dummyDao.Search(searchModel);
        }

        public bool Save(IUserDetails userDetails)
        {
            return _dummyDao.Save(userDetails);
        }

        public bool Remove(IUserDetails userDetails)
        {
            return _dummyDao.Remove(userDetails);
        }
    }
}
