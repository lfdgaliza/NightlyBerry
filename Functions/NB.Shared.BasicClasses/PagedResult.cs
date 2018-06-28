using System;
using System.Collections.Generic;

namespace NB.Shared.BasicClasses
{
    public class PagedResult<TResult>
    {
        public int LastPage => (int)Math.Ceiling((double)TotalItems / PageSize);
        public int TotalItems { get; set; }
        public int PageSize { get; protected set; }
        public int PageIndex { get; protected set; }
        public IList<TResult> Items { get; set; }

        public PagedResult(FilterBase filter)
        {
            PageSize = filter.PageSize;
            PageIndex = filter.PageIndex;
            TotalItems = -1;
            Items = new List<TResult>();
        }
    }
}
