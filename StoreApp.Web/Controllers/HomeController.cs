using Microsoft.AspNetCore.Mvc;
using StoreApp.Data.Abstract;
using StoreApp.Web.Models;

namespace StoreApp.Web.Controllers
{
    public class HomeController : Controller

    {
        public int pageSize = 3;
        private IStoreRepository _storeRepository;

        public HomeController(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public IActionResult Index(int page = 1)
     {
            var products = _storeRepository
                .Products
                .Skip((page-1)* pageSize) // 1 -1 => 0 * 3 => 0 // 2 - 1 => 1 *3 => 3
                .Select(p => new ProductsViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price
                }).Take(pageSize);
            return View(new ProductListModel
            {
                Products = products,
                PageInfo = new PageInfo
                {
                    ItemsPerPage = pageSize,
                    CurrentPage = page,
                    TotalItems = _storeRepository.Products.Count()
                }
            });
        }
    }
}
