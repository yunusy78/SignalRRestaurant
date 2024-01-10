using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DtoLayer.ShoppingCartDtos;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        [HttpGet("IncrementCount")]
        public ActionResult<int> IncrementCount(int cartId, int productId)
        {
            int newQuantity = _shoppingCartService.IncrementCount(cartId, productId);
            return Ok();
        }
        

        [HttpGet("DecrementCount")]
        public ActionResult<int> DecrementCount(int cartId, int productId)
        {
            int newQuantity = _shoppingCartService.DecrementCount(cartId, productId);
            return Ok();
        }

        [HttpGet("GetFirstOrDefault")]
        public ActionResult<ShoppingCart> GetFirstOrDefault(Expression<Func<ShoppingCart, bool>> filter, string includeProperties = null, bool tracked = true)
        {
            ShoppingCart result = _shoppingCartService.GetFirstOrDefault(filter, includeProperties, tracked);
            return Ok(result);
        }

        [HttpGet("GetAllListByFilter")]
        public ActionResult<IEnumerable<ShoppingCart>> GetAllListByFilter(Expression<Func<ShoppingCart, bool>> filter = null, string includeProperties = null, string includeProperties2 = null)
        {
            IEnumerable<ShoppingCart> resultList = _shoppingCartService.GetAllListByFilter(filter, includeProperties, includeProperties2);
            return Ok(resultList);
        }

        [HttpGet("RemoveRange")]
        public IActionResult RemoveRange(int cartId, int productId)
        {
            _shoppingCartService.RemoveRange(cartId, productId);
            return Ok("Entities removed successfully.");
        }
        
        
        [HttpGet("GetAllListByDiningTableAsync")]
        public async Task<ActionResult<List<ResultShoppingCartWithDiningTableDto>>> GetAllListByDiningTableAsync(int diningTableId)
        {
            List<ResultShoppingCartWithDiningTableDto> result = await _shoppingCartService.GetAllListByDiningTableAsync(diningTableId);
            return Ok(result);
        }
        
        
        [HttpPost("CreateBasketAsync")]
        
        public async Task<ActionResult<CreateShoppingCartDto>> CreateBasketAsync(CreateShoppingCartDto createBasketDto)
        {
            CreateShoppingCartDto result = await _shoppingCartService.CreateBasketAsync(createBasketDto);
            return Ok(result);
        }
    }
}

        
        
        
        
        
        
        
        
        
       
        
        
        
        
        
        

