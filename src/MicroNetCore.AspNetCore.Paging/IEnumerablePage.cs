using System.Collections.Generic;

namespace MicroNetCore.AspNetCore.Paging
{
    public interface IEnumerablePage
    {
        int PageCount { get; }
        int PageIndex { get; }
        int PageSize { get; }
    }

    public interface IEnumerablePage<out TItem> : IEnumerablePage
    {
        IEnumerable<TItem> Items { get; }
    }
}