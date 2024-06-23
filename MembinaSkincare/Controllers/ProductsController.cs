using MembinaSkincare.Data;
using MembinaSkincare.Models;
using MembinaSkincare.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MembinaSkincare.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductDbContext productDbContext;
        public ProductsController(ProductDbContext productDbContext)
        {
           this.productDbContext = productDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await productDbContext.Products.ToListAsync();
            return View(products);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductViewModel addProductRequest)
        {
            // Normalize the input currency name to lower case
            string normalizedCurrencyName = addProductRequest.CurrencyName.ToLower();

            // Check if the currency exists, if not add it
            Currency currency = await productDbContext.Currency
                .FirstOrDefaultAsync(c => c.CurrencyName.ToLower() == normalizedCurrencyName);

            if (currency == null)
            {
                // Create new currency if it does not exist
                currency = new Currency { CurrencyName = addProductRequest.CurrencyName };
                productDbContext.Currency.Add(currency);
                await productDbContext.SaveChangesAsync(); // Save to generate an ID for the new currency
            }

            var product = new Product()
            {
                Category = addProductRequest.Category,
                BrandName = addProductRequest.BrandName,
                ProductSeriesName = addProductRequest.ProductSeriesName,
                ProductName = addProductRequest.ProductName,
                Size = addProductRequest.Size,
                ProductDescription = addProductRequest.ProductDescription,
                SGDPrice = addProductRequest.SGDPrice,
                PhotoLink = addProductRequest.PhotoLink,
                CurrencyId = currency.Id,
                CurrencyRate = currency.CurrencyRate,  // Store the rate at the time of product creation
                MMKPrice = addProductRequest.SGDPrice * (double)currency.CurrencyRate  // Calculate MMKPrice using double values
            };


            await productDbContext.Products.AddAsync(product);
            await productDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            // Retrieve the product from the database
            var product = await productDbContext.Products
                .Include(p => p.Currency)  // Ensure Currency is included in the query
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product != null)
            {
                // Calculate MMKPrice based on the CurrencyRate
                double mmkPrice = product.SGDPrice * (double)product.Currency.CurrencyRate;

                // Create the view model with the product details and calculated MMKPrice
                var viewModel = new AddProductViewModel()
                {
                    BrandName = product.BrandName,
                    ProductSeriesName = product.ProductSeriesName,
                    ProductName = product.ProductName,
                    Size = product.Size,
                    ProductDescription = product.ProductDescription,
                    SGDPrice = product.SGDPrice,
                    PhotoLink = product.PhotoLink,
                    MMKPrice = mmkPrice,
                    CurrencyName = product.Currency.CurrencyName  // Include the currency name
                };

                // Return the view with the view model
                return View("View", viewModel);
            }

            // If the product is not found, redirect to the index action
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var product = await productDbContext.Products.FindAsync(id);
            if (product != null)
            {
                var viewModel = new UpdateProductViewModel
                {
                    Id = product.Id,
                    Category = product.Category,
                    BrandName = product.BrandName,
                    ProductSeriesName = product.ProductSeriesName,
                    ProductName = product.ProductName,
                    Size = product.Size,
                    ProductDescription = product.ProductDescription,
                    SGDPrice = product.SGDPrice,
                    PhotoLink = product.PhotoLink,
                    MMKPrice = product.MMKPrice
                };
                return View(viewModel);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductViewModel model)
        {
            var product = await productDbContext.Products.FindAsync(model.Id);
            if (product != null)
            {
                product.Id = model.Id;
                product.Category = model.Category;
                product.BrandName = model.BrandName;
                product.ProductSeriesName = model.ProductSeriesName;
                product.ProductName = model.ProductName;
                product.Size = model.Size;
                product.ProductDescription = model.ProductDescription;
                product.SGDPrice = model.SGDPrice;
                product.PhotoLink = model.PhotoLink;
                product.MMKPrice = model.MMKPrice;

                await productDbContext.SaveChangesAsync();
                return RedirectToAction("View", new { id = model.Id });


            }
            return RedirectToAction("Index");
        }

    }
}
