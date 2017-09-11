using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MicroNetCore.AspNetCore.Paging
{
    [DataContract]
    public sealed class Page<TItem>
    {
        public Page(int pageCount, int pageIndex, int pageSize, IEnumerable<TItem> items)
        {
            Items = items;
            PageCount = pageCount;
            PageIndex = pageIndex;
            PageSize = pageSize;
        }

        [DataMember]
        public IEnumerable<TItem> Items { get; }

        [DataMember]
        public int PageCount { get; }

        [DataMember]
        public int PageIndex { get; }

        [DataMember]
        public int PageSize { get; }
    }
}
