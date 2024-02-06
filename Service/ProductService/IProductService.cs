using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetAuthApi.Models;
using AuthApi.Dtos;
using AuthApi.Models;

namespace AuthApi.Service.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<List<Product>>> GetAll();
        Task<ServiceResponse<Product>> GetProductById(int id);
        Task<ServiceResponse<Product>> UpdateProduct(Product product);
        Task<ServiceResponse<Product>> CreateProduct(ProductDto product);
        Task<ServiceResponse<Product>> DeleteProduct(int id);
    }
}