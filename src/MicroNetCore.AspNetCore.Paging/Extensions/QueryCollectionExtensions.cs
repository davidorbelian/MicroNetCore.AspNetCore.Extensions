using System.Linq;
using System.Reflection;
using MicroNetCore.AspNetCore.Paging.Attributes;
using Microsoft.AspNetCore.Http;

namespace MicroNetCore.AspNetCore.Paging.Extensions
{
    public static class QueryCollectionExtensions
    {
        public static bool HasPaging(this IQueryCollection query, bool both = false)
        {
            var index = int.TryParse(query["pageIndex"].SingleOrDefault(), out var _);
            var size = int.TryParse(query["pageSize"].SingleOrDefault(), out var _);

            return both
                ? index && size
                : index || size;
        }

        public static int GetPageIndex(this IQueryCollection query)
        {
            var index = int.TryParse(query["pageIndex"].SingleOrDefault(), out var pageIndex);
            return index ? pageIndex : 1;
        }

        public static int GetPageSize(this IQueryCollection query, int defaultValue = 20)
        {
            var size = int.TryParse(query["pageSize"].SingleOrDefault(), out var pageSize);
            return size ? pageSize : defaultValue;
        }

        public static int GetPageSize<TModel>(this IQueryCollection query, int defaultValue = 20)
        {
            var pageSize = typeof(TModel).GetCustomAttribute<DefaultPageSizeAttribute>()?.PageSize ?? defaultValue;
            return query.GetPageSize(pageSize);
        }
    }
}