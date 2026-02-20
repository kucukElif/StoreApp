namespace StoreApp.Web.Models
{
    public class ProductsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Category { get; set; } = string.Empty;
    }

    public class ProductListModel
    {
        public IEnumerable<ProductsViewModel> Products { get; set; } = Enumerable.Empty<ProductsViewModel>();
        public PageInfo PageInfo { get; set; } = new();
    }

    public class PageInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
    }
}
