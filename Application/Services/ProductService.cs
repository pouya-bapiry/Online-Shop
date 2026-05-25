using Application.Interfaces;
using Core;
using Core.Entities;
using Infrastructure.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductService : IProductService
    {

        private readonly OnlineShopDbContext dbContext;

        public ProductService(OnlineShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<ProductDto> Add(ProductDto model)
        {
            //ProductDto to Product AutoMapper ??
            var product = new Product
            {
                ProductName = model.ProductName,
                Price = model.Price,
            };

            //dbContext.Products.Add(product);
            await dbContext.AddAsync(product);
            await dbContext.SaveChangesAsync();

            model.Id = product.Id;
            return model;
        }

        public async Task<ProductDto> Get(int id)
        {
            var product = await dbContext.Products.FindAsync(id);
            var model = new ProductDto
            {
                Id = product.Id,
                Price = product.Price,
                ProductName = product.ProductName,
                PriceWithComma = product.Price.ToString("###.###"),
            };
            return model;
        }

        public async Task<List<ProductDto>> GetAll()
        {
            var result = await dbContext.Products.Select(x => new ProductDto
            {
                Id = x.Id,
                Price = x.Price,
                ProductName = x.ProductName,
                PriceWithComma = x.Price.ToString("###.###"),

            }).ToListAsync();
            return result;
        }
    }
}
