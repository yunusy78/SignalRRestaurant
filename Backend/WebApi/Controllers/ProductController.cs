using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.ProductDtos;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IShoppingCartService _shoppingCartService;
        
        private readonly IMapper _mapper;
        
        
        
        public ProductController(IProductService productService, IMapper mapper, IShoppingCartService shoppingCartService)
        {
            _productService = productService;
            _mapper = mapper;
            _shoppingCartService = shoppingCartService;
        }
        
        
        
        
       
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _productService.GetAllAsync();
            return Ok(result);
        }
        
        [AllowAnonymous]
        [HttpGet("{id}")]
        
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _productService.GetByIdAsync(id);
            return Ok(result);
        }
        
        
        [HttpPost]
        public async Task<IActionResult> Add(CreateProductDto Product)
        {
            var result = _mapper.Map<Product>(Product);
            await _productService.AddAsync(result);
            return Ok("Added Successfully");
        }
        
        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductDto Product)
        {
            var result = _mapper.Map<Product>(Product);
            await _productService.UpdateAsync(result);
            return Ok("Updated Successfully");
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            await _productService.DeleteAsync(product);
            return Ok("Deleted Successfully");
        }
        
        [AllowAnonymous]
        [HttpGet("GetListWithCategory")]
        public async Task<IActionResult> GetListWithCategory()
        {
            var result = _mapper.Map<List<ResultProductWithCategoryDto>>(await _productService.GetListWithCategoryAsync());
            return Ok(result);
        }
        
        [AllowAnonymous]
        [HttpPost("AddToCart")]
        public async Task<IActionResult> AddToCart([FromBody] ShoppingCart addToCartRequest)
        {
            var product = await _productService.GetByIdAsync(addToCartRequest.ProductId);
            if (product == null)
            {
                return NotFound("Product not found");
            }

            ShoppingCart cartObj = new()
            {
                Quantity = 1,
                ProductId = addToCartRequest.ProductId,
                Price = product.Price,
                CreatedDate = DateTime.Now
            };
            
            await _shoppingCartService.AddAsync(cartObj);
            return Ok("Added Successfully");
        }
        
        
        
        
    }
}
