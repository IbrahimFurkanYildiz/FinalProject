using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //Loosely coupled -- Gevşek bağımlılık -- Soyuta olan bağımlılık
        //IoC Container --- Inversion of Control
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        //http takma isim dışarıdan çağırılma şekli
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //Swagger -- hazır dökümantasyon oluşturma 
            //Dependecy chain -- Bağımlılık zinciri
            //IProductService productService = new ProductManager(new EfProductDal());
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int productId)
        {
            var result = _productService.GetById(productId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result); 
        }
        
        //silme ve güncelleme işlemlerinde httppost sektörde büyük oranda kullanılmaktadır. 
        //bunun yerine güncelleme için httpput ve silme için httpdelete metodu kullanılabilir. 
        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
