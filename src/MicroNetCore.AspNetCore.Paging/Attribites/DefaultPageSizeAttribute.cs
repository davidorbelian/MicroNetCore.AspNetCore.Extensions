using System;

namespace MicroNetCore.AspNetCore.Paging.Attributes
{
    public sealed class DefaultPageSizeAttribute : Attribute
    {
        public DefaultPageSizeAttribute(int pageSize)
        {
            PageSize = pageSize;
        }

        public int PageSize { get; }
    }
}