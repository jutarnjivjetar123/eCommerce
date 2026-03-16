using eCommerce.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Services
{
    public class DummyDataService
    {
        private readonly eCommerceContext _dbContext;

        public DummyDataService(eCommerceContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Populates the database with fake/dummy data
        /// </summary>
        public async Task PopulateAsync()
        {
            // Only populate if database is empty
            if (_dbContext.ProductCategories.Any() || _dbContext.Products.Any())
            {
                return;
            }

            await PopulateCategoriesAsync();
            await PopulateUnitOfMeasuresAsync();
            await PopulateProductsAsync();

            await _dbContext.SaveChangesAsync();
        }

        private async Task PopulateCategoriesAsync()
        {
            var categories = new List<ProductCategories>
            {
                new ProductCategories { Name = "Electronics" },
                new ProductCategories { Name = "Clothing" },
                new ProductCategories { Name = "Food & Beverages" },
                new ProductCategories { Name = "Home & Garden" },
                new ProductCategories { Name = "Sports & Outdoors" },
                new ProductCategories { Name = "Books & Media" },
                new ProductCategories { Name = "Toys & Games" },
                new ProductCategories { Name = "Beauty & Personal Care" }
            };

            await _dbContext.ProductCategories.AddRangeAsync(categories);
            await _dbContext.SaveChangesAsync();
        }

        private async Task PopulateUnitOfMeasuresAsync()
        {
            var units = new List<UnitOfMeasures>
            {
                new UnitOfMeasures { Name = "Piece" },
                new UnitOfMeasures { Name = "Kilogram" },
                new UnitOfMeasures { Name = "Liter" },
                new UnitOfMeasures { Name = "Meter" },
                new UnitOfMeasures { Name = "Box" },
                new UnitOfMeasures { Name = "Pack" },
                new UnitOfMeasures { Name = "Pair" },
                new UnitOfMeasures { Name = "Set" }
            };

            await _dbContext.UnitOfMeasures.AddRangeAsync(units);
            await _dbContext.SaveChangesAsync();
        }

        private async Task PopulateProductsAsync()
        {
            var categories = await _dbContext.ProductCategories.ToListAsync();
            var units = await _dbContext.UnitOfMeasures.ToListAsync();

            var products = new List<Products>
            {
                // Electronics
                CreateProduct("Wireless Headphones", "WH-001", 79.99m, categories[0], units[0]),
                CreateProduct("USB-C Cable", "USB-001", 12.99m, categories[0], units[0]),
                CreateProduct("Phone Stand", "PS-001", 19.99m, categories[0], units[0]),
                CreateProduct("Portable Charger", "PC-001", 49.99m, categories[0], units[0]),

                // Clothing
                CreateProduct("Cotton T-Shirt", "TS-001", 24.99m, categories[1], units[0]),
                CreateProduct("Blue Jeans", "JN-001", 59.99m, categories[1], units[0]),
                CreateProduct("Running Shoes", "SH-001", 89.99m, categories[1], units[0]),
                CreateProduct("Winter Jacket", "JK-001", 129.99m, categories[1], units[0]),

                // Food & Beverages
                CreateProduct("Organic Coffee", "CF-001", 14.99m, categories[2], units[1]),
                CreateProduct("Whole Wheat Bread", "BR-001", 3.99m, categories[2], units[0]),
                CreateProduct("Almond Milk", "MK-001", 4.49m, categories[2], units[1]),
                CreateProduct("Dark Chocolate Bar", "CH-001", 2.99m, categories[2], units[0]),

                // Home & Garden
                CreateProduct("Desk Lamp", "LP-001", 34.99m, categories[3], units[0]),
                CreateProduct("Plant Pot", "PT-001", 9.99m, categories[3], units[0]),
                CreateProduct("Bath Towel", "TW-001", 19.99m, categories[3], units[0]),
                CreateProduct("Bed Sheets Set", "BS-001", 49.99m, categories[3], units[1]),

                // Sports & Outdoors
                CreateProduct("Yoga Mat", "YM-001", 29.99m, categories[4], units[0]),
                CreateProduct("Dumbbells Set", "DB-001", 99.99m, categories[4], units[1]),
                CreateProduct("Bicycle Helmet", "BH-001", 44.99m, categories[4], units[0]),
                CreateProduct("Camping Tent", "TN-001", 149.99m, categories[4], units[0]),

                // Books & Media
                CreateProduct("C# Programming Guide", "BK-001", 39.99m, categories[5], units[0]),
                CreateProduct("Science Fiction Novel", "BK-002", 16.99m, categories[5], units[0]),
                CreateProduct("Business Strategy Book", "BK-003", 24.99m, categories[5], units[0]),

                // Toys & Games
                CreateProduct("Board Game Set", "GM-001", 29.99m, categories[6], units[1]),
                CreateProduct("Building Blocks", "GB-001", 19.99m, categories[6], units[0]),
                CreateProduct("Action Figure", "AF-001", 14.99m, categories[6], units[0]),

                // Beauty & Personal Care
                CreateProduct("Face Cream", "FC-001", 22.99m, categories[7], units[0]),
                CreateProduct("Shampoo Bottle", "SP-001", 8.99m, categories[7], units[1]),
                CreateProduct("Toothbrush Set", "TB-001", 12.99m, categories[7], units[1])
            };

            await _dbContext.Products.AddRangeAsync(products);
            await _dbContext.SaveChangesAsync();
        }

        private Products CreateProduct(string name, string code, decimal price, ProductCategories category, UnitOfMeasures unit)
        {
            return new Products
            {
                Name = name,
                Code = code,
                Price = price,
                CategoryId = category.CategoryId,
                UnitOfMeasureId = unit.UnitOfMeasureId,
                Status = true,
                StateMachine = "Active"
            };
        }
    }
}
