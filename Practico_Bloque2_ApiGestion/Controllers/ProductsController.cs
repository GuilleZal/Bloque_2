using Microsoft.AspNetCore.Mvc;
using Practico_Bloque2_ApiGestion.Services;
using Practico_Bloque1_Gestor.Models;
using Practico_Bloque2_ApiGestion.DTOs;

namespace Practico_Bloque2_ApiGestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {

        //Inyeccion de dependencias del servicio producto
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        //expone los endpoints HTTP y retorna IActionResult (Ok, CreatedAtAction, BadRequest, NotFound, NoContent).

        //Create
        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductDTO productDTO)
        {
            var newProduct = new ProductDTO
            {
                Name = productDTO.Name,
                Price = productDTO.Price,
                Category = productDTO.Category,
                Active = productDTO.Active
            };

            _productService.Add(newProduct);

            return Ok(newProduct);
        }

        //Read
        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productService.GetAll();
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var product = _productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        //Read by Category
        [HttpGet("{category:string}")]
        public IActionResult GetByCategory(string category)
        {
            var books = _productService.GetByCategory(category);
            return Ok(books);
        }

        //Update
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] ProductDTO productDTO)
        {
            var existingProduct = _productService.GetById(id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            existingProduct.Name = productDTO.Name;
            existingProduct.Price = productDTO.Price;
            existingProduct.Category = productDTO.Category;
            existingProduct.Active = productDTO.Active;
            _productService.Add(existingProduct);
            return Ok(existingProduct);
        }

        //Delete
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var product = _productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            _productService.DeleteProduct(id);
            return NoContent();
        }
    }
}
