using Bluevolt.POC.Common;
using Bluevolt.POC.Common.Core;


namespace Bluevolt.POC.Business.Core
{
    public abstract class BaseSearch : IBaseSearch
    {
        #region Constructor

        public BaseSearch()
        {
            CurrentPage = 1;
            RecordsPerPage = 10;
        }

        #endregion

        #region Properties
        
        public long ID { get; set; }
        public int CurrentPage { get; set; }
        public int RecordsPerPage { get; set; }
        public string SearchString { get; set; }

        #endregion
    }
}
