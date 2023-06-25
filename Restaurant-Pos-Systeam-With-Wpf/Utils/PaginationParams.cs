namespace Restaurant_Pos_Systeam_With_Wpf.Utils
{
    public class PaginationParams
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public PaginationParams(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public PaginationParams()
        {

        }
    }
}
