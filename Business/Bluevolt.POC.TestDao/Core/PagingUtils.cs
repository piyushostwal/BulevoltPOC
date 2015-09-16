using Bluevolt.POC.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluevolt.POC.TestDao.Core
{

    public static class PagingUtils
    {
        public static BaseSearchResult<T> ToSearchResult<T>(this IEnumerable<T> items, IBaseSearch entity)
        {
            var listItems = items.ToList();
            return new BaseSearchResult<T>
            {
                Items = listItems.Skip(entity.RecordsPerPage * (entity.CurrentPage - 1)).Take(entity.RecordsPerPage).ToList(),
                TotalCount = listItems.Count
            };
        }
    }
}
