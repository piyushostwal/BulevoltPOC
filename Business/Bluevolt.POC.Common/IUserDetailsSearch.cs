using Bluevolt.POC.Common.Core;

namespace Bluevolt.POC.Common
{
    public interface IUserDetailsSearch : IBaseSearch
    {
        #region Properties
        
        string UserName { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Phone { get; set; }
        string Email { get; set; } 

        #endregion
    }
}
