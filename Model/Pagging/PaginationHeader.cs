namespace Model.Pagging
{
    public class PaginationHeader
    {
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public string NextPageLink { get; set; }
        public string PreviousLink { get; set; }


        public PaginationHeader()
        {

        }

        public PaginationHeader(int currentPage, int itemPerPage, int totalItems, int totalPages)
        {
            this.CurrentPage = currentPage;
            this.ItemsPerPage = itemPerPage;
            this.TotalPages = totalPages;
            this.TotalItems = totalItems;
        }
    }
}
