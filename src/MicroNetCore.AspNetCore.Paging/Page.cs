using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MicroNetCore.AspNetCore.Paging
{
    public sealed class Page<TItem> : List<TItem>
    {
        public Page(int pageCount, int pageIndex, int pageSize, IEnumerable<TItem> items)
            : base(items)
        {
            PageCount = pageCount;
            PageIndex = pageIndex;
            PageSize = pageSize;
        }

        [DataMember]
        public int PageCount { get; }

        [DataMember]
        public int PageIndex { get; }

        [DataMember]
        public int PageSize { get; }
    }
}
