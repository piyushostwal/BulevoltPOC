namespace Bluevolt.POC.Common
{
    public interface IUserDetails : IBaseEntity<IUserDetails,IUserDetailsSearch>
    {
        #region Property
        
        string UserName { get; set; }
        string Password { get; set; }
        string FirstName { get; set; }        
        string LastName { get; set; }
        string Gender { get; set; }
        string Phone { get; set; }
        string Email { get; set; }  
        
        #endregion
    }
}
