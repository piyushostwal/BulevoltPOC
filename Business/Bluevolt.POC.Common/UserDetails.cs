using Bluevolt.POC.Common;
using Bluevolt.POC.Common.Core;
using ESPL.Framework.Db;

namespace Bluevolt.POC.Business
{
    public class UserDetails : BaseEntity<IUserDetails, IUserDetailsSearch>, IUserDetails
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

        #region Methods

        protected override IBaseDao<IUserDetails, IUserDetailsSearch> GetDAO()
        {
            return DaoFactoryProvider.CreateInstance().GetDao<IUserDetailsDao>();
        }

        #endregion        
    }
}
