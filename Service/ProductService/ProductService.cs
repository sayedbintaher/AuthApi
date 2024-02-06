using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetAuthApi.Database;
using AspNetAuthApi.Models;
using AuthApi.Dtos;
using AuthApi.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AuthApi.Service.ProductService
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public ProductService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Product>> CreateProduct(ProductDto product)
        {
            var response = new ServiceResponse<Product>();
            var productExist = await _db.Products.AnyAsync(x => x.Name == product.Name);
            if (productExist)
            {
                response.Message = "Product already exist";
                response.Success = false;
            }
            var productSave = _mapper.Map<Product>(product);
            await _db.Products.AddAsync(productSave);
            await _db.SaveChangesAsync();

            response.Data = productSave;
            response.Message = "Product Save Successful";
            return response;
        }

        public async Task<ServiceResponse<Product>> DeleteProduct(int id)
        {
            var response = new ServiceResponse<Product>();
            var productToDelete = await _db.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (productToDelete == null)
            {
                response.Success = false;
                response.Message = "Product with the given Id does not exist";
                return response;
            }

            response.Data = productToDelete;
            response.Message = "Product Deleted Successfully";
            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetAll()
        {
            var response = new ServiceResponse<List<Product>>();
            var products = await _db.Products.ToListAsync();
            response.Data = products;
            response.Message = "Successful";
            return response;
        }

        public async Task<ServiceResponse<Product>> GetProductById(int id)
        {
            var response = new ServiceResponse<Product>();
            var product = await _db.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                response.Message = "Data Does not Exist";
                response.Success = false;
                return response;
            }
            response.Data = product;
            response.Message = "Successful";
            return response;
        }

        public async Task<ServiceResponse<Product>> UpdateProduct(Product product)
        {
            var response = new ServiceResponse<Product>();

            var productExist = await _db.Products.FirstOrDefaultAsync(p => p.Id == product.Id);
            if (productExist == null)
            {
                response.Message = $"Product with {product.Id} does not exist.";
                response.Success = false;
                return response;
            }
            _db.Products.Update(product);
            await _db.SaveChangesAsync();

            response.Data = product;
            response.Message = "Updated Successfully";
            return response;
        }
    }
}