using Bluevolt.POC.Business.Core;
using Bluevolt.POC.Common;

namespace Bluevolt.POC.Business
{
    public class UserDetailsSearch : BaseSearch, IUserDetailsSearch
    {
        #region Properties
        
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; } 

        #endregion
    }
}
