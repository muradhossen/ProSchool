using Model.Pagging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ApiProject.Extentions
{
    public static class Extensions
    {
        public static void AddPagination(this HttpResponse response, int currentPage, int itemPerPage, int totalItems, int totalPages)
        {
            var paginationHeader = new PaginationHeader(currentPage, itemPerPage, totalItems, totalPages);
            var camelCaseFormatter = new JsonSerializerSettings();
            camelCaseFormatter.ContractResolver = new CamelCasePropertyNamesContractResolver();
            response.Headers.Add("Pagination", JsonConvert.SerializeObject(paginationHeader, camelCaseFormatter));
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
        }

        public static void AddPagination(this HttpResponse response, IPagedList entities)
        {
            var paginationHeader = new PaginationHeader()
            {
                CurrentPage = entities.CurrentPage,
                TotalItems = entities.TotalCount,
                TotalPages = entities.TotalPages,
                ItemsPerPage = entities.PageSize,
                NextPageLink = entities.NextLink,
                PreviousLink = entities.PreviousLink

            };
            var camelCaseFormatter = new JsonSerializerSettings();
            camelCaseFormatter.ContractResolver = new CamelCasePropertyNamesContractResolver();
            response.Headers.Add("Pagination", JsonConvert.SerializeObject(paginationHeader, camelCaseFormatter));
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
        }
    }
}
