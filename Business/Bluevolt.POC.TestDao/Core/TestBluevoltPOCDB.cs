using Bluevolt.POC.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluevolt.POC.TestDao.Core
{
    public class TestBluevoltPOCDB
    {
        #region Declarations

        private static long _nextID;
        public static long UserID { get; set; }
        public static IList<IUserDetails> UserDetails { get; set; }

        #endregion

        #region Constructor

        static TestBluevoltPOCDB()
        {
            ClearAll();
        }

        #endregion

        #region Methods
        
        private static void ClearAll()
        {
            UserDetails = new List<IUserDetails>();
        }

        public static long NextID
        {
            get { return ++_nextID; }
        }
        
        #endregion
    }
}
