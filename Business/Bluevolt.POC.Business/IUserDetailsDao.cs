using Bluevolt.POC.Business.Core;
using Bluevolt.POC.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluevolt.POC.Business
{
    public interface IUserDetailsDao : IBaseDao<IUserDetails, IUserDetailsSearch>
    {
    }
}
