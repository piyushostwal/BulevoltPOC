using Bluevolt.POC.Common;
using Bluevolt.POC.Common.Core;
using Bluevolt.POC.Database.DBHelper;
using System.Collections.Generic;

namespace Bluevolt.POC.Database
{
    public class UserDetailsDao : IUserDetailsDao
    {
        #region Declarations
        
        BlueVoltPOCContext _dbobj = new BlueVoltPOCContext(); 

        #endregion

        #region Methods
        
        public IBaseSearchResult<IUserDetails> Search(IUserDetailsSearch entity)
        {
            IList<IUserDetails> users = new List<IUserDetails>();
            users = getUserDetails();
            return new BaseSearchResult<IUserDetails>
            {
                Items = users,
                TotalCount = users.Count
            };

        }

        private IList<IUserDetails> getUserDetails()
        {
            IList<IUserDetails> Users = new List<IUserDetails>();
            foreach (var user in _dbobj.SpSelectUserDetails())
            {
                
                Users.Add(new UserDetailsModel
                   {
                       ID = user.UserID,
                       UserName = user.UserName,
                       Password = user.Password,
                       FirstName = user.FirstName,
                       LastName = user.LastName,
                       Gender=user.Gender,
                       Phone = user.Phone,
                       Email = user.Email,
                       CreatedOn = user.CreatedOn
                   });
            }
            return Users;
        }

        public bool Save(IUserDetails entity)
        {
            _dbobj.SpAddUpdateUsers(entity.ID,entity.UserName,entity.Password,entity.FirstName,entity.LastName,entity.Gender,entity.Phone,entity.Email,entity.CreatedBy,entity.UpdatedBy);
            return true;
        }

        public bool Remove(IUserDetails entity)
        {
            _dbobj.SpDeleteUser(entity.ID);
            return true;
        } 

        #endregion
    }
}
