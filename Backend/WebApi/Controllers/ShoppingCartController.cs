using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartDal _shoppingCartDal;

        public ShoppingCartController(IShoppingCartDal shoppingCartDal)
        {
            _shoppingCartDal = shoppingCartDal;
        }

        [HttpPost("IncrementCount")]
        public ActionResult<int> IncrementCount([FromBody] ShoppingCart shoppingCart, int count)
        {
            int newQuantity = _shoppingCartDal.IncrementCount(shoppingCart, count);
            return Ok(newQuantity);
        }

        [HttpPost("DecrementCount")]
        public ActionResult<int> DecrementCount([FromBody] ShoppingCart shoppingCart, int count)
        {
            int newQuantity = _shoppingCartDal.DecrementCount(shoppingCart, count);
            return Ok(newQuantity);
        }

        [HttpGet("GetFirstOrDefault")]
        public ActionResult<ShoppingCart> GetFirstOrDefault(Expression<Func<ShoppingCart, bool>> filter, string includeProperties = null, bool tracked = true)
        {
            ShoppingCart result = _shoppingCartDal.GetFirstOrDefault(filter, includeProperties, tracked);
            return Ok(result);
        }

        [HttpGet("GetAllListByFilter")]
        public ActionResult<IEnumerable<ShoppingCart>> GetAllListByFilter(Expression<Func<ShoppingCart, bool>> filter = null, string includeProperties = null, string includeProperties2 = null)
        {
            IEnumerable<ShoppingCart> resultList = _shoppingCartDal.GetAllListByFilter(filter, includeProperties, includeProperties2);
            return Ok(resultList);
        }

        [HttpPost("RemoveRange")]
        public IActionResult RemoveRange([FromBody] IEnumerable<ShoppingCart> entity)
        {
            _shoppingCartDal.RemoveRange(entity);
            return Ok("Entities removed successfully.");
        }

        [HttpPost("SaveChanges")]
        public IActionResult SaveChanges()
        {
            _shoppingCartDal.SaveChanges();
            return Ok("Changes saved successfully.");
        }
    }
}

        
        
        
        
        
        
        
        
        
       
        
        
        
        
        
        

