using Core;
using Core.Entities;
using Core.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly OnlineShopDbContext onlineShopDbContextl;

        public ProductRepository(OnlineShopDbContext onlineShopDbContextl)
        {
            this.onlineShopDbContextl = onlineShopDbContextl;
        }

        public async Task<Product> GetAsync(int id)
        {
            return await onlineShopDbContextl.Products.FindAsync(id);
        }

        public Task<List<Product>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<int> InsertAsync(Product product)
        {
            await onlineShopDbContextl.AddAsync(product);

            return product.Id;
        }
    }
}
