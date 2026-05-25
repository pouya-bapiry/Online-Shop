using Core.Entities;
using Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAll();
        Task<ProductDto> Get(int id);
        Task<ProductDto> Add(ProductDto model);
    }
}
 