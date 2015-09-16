using Bluevolt.POC.Common;
using Bluevolt.POC.Common.Core;

namespace Bluevolt.POC.Database
{
    public class UserDetailsModel : IUserDetails
    {
        #region Properties
       
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        
        #endregion      
    
        public long ID { get; set; }

        public long? CreatedBy { get; set; }

        public System.DateTime? CreatedOn { get; set; }

        public long? UpdatedBy { get; set; }

        public System.DateTime? UpdatedOn { get; set; }

        public IBaseSearchResult<IUserDetails> Search(IUserDetailsSearch entitySearch)
        {
            throw new System.NotImplementedException();
        }

        public bool Save(IUserDetails entities)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(IUserDetails entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
