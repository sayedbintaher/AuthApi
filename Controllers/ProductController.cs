using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthApi.Dtos;
using AuthApi.Models;
using AuthApi.Service.ProductService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static AuthApi.Utilities.AppConstants;

namespace AuthApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("AddProduct"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add(ProductDto product)
        {
            var response = await _productService.CreateProduct(product);
            if (response.Success == false)
            {
                return BadRequest(response.Message);
            }
            return Ok(response);
        }

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> Update(Product product)
        {
            var response = await _productService.UpdateProduct(product);
            if (response.Success == false)
            {
                return BadRequest(response.Message);
            }
            return Ok(response);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _productService.GetAll();
            return Ok(response);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _productService.GetProductById(id);
            if (response.Success == false)
            {
                return BadRequest(response.Message);
            }
            return Ok(response);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {

            var response = await _productService.DeleteProduct(id);
            if (response.Success == false)
            {
                return BadRequest(response.Message);
            }
            return Ok(response);
        }
    }
}