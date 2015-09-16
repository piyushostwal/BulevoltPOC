using Bluevolt.POC.Common;
using Bluevolt.POC.TestDao.Core;
using System.Collections.Generic;
using Bluevolt.POC.Common.Core;
using System.Linq;

namespace Bluevolt.POC.TestDao
{
    public class TestUserDetailsDao : IUserDetailsDao
    {
        public Common.Core.IBaseSearchResult<Common.IUserDetails> Search(Common.IUserDetailsSearch entity)
        {
            return (from User in TestBluevoltPOCDB.UserDetails
                    where (entity.ID == 0 ? true : entity.ID == User.ID)
                    select User).OrderByDescending(p => p.ID).ToSearchResult(entity);
        }

        public bool Save(IUserDetails entity)
        {
            var toReturn = new List<long>();
            if (entity.ID == 0)
            {
                entity.ID = TestBluevoltPOCDB.NextID;
                toReturn.Add(entity.ID);
            }
            else
            {
                toReturn.Add(entity.ID);
                TestBluevoltPOCDB.UserDetails.Remove(TestBluevoltPOCDB.UserDetails.First(br => br.ID == entity.ID));
            }
            TestBluevoltPOCDB.UserDetails.Add(entity);
            return true; ;
        }

        public bool Remove(Common.IUserDetails entity)
        {
            TestBluevoltPOCDB.UserDetails.Remove(TestBluevoltPOCDB.UserDetails.First(br => br.ID == entity.ID));
            return true;
        }

    }
}
