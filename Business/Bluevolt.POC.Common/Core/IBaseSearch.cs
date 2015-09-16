namespace Bluevolt.POC.Common.Core
{
    public interface IBaseSearch
    {
        #region Properties
        
        long ID { get; set; }
        int CurrentPage { get; set; }
        int RecordsPerPage { get; set; }
        string SearchString { get; set; } 

        #endregion
    }
}
