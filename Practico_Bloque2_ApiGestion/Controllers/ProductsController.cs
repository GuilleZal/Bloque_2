using Microsoft.AspNetCore.Mvc;
using Practico_Bloque2_ApiGestion_TheBusinessLayer.Services;
using Practico_Bloque2_ApiGestion.Models;
using Practico_Bloque2_ApiGestion_TheBusinessLayer.DTOs;

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
        public IActionResult CreateProduct([FromBody] ProductCreateDTO productDTO)
        {
            var newProduct = new Product
            {
                Name = productDTO.Name,
                Price = productDTO.Price,
                Category = productDTO.Category,
                Active = true
            };

            _productService.AddProduct(newProduct);

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
            ProductDTO productDTO;
            try
            {
                productDTO = _productService.GetById(id);
            }
            //generalmente lanzan dos tipos de excepciones: KeyNotFoundException y ArgumentException.
            //Se pueden capturar ambas en un bloque try-catch.
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex) //este excepcion debe ir siempre al final y es opcional
            {
                return BadRequest(ex.Message);
            }
            return Ok(productDTO);
        }

        //Read by Category
        [HttpGet("{category:string}")]
        public IActionResult GetByCategory(string category)
        {
            var products = _productService.GetByCategory(category);
            return Ok(products);
        }

        //Update
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] ProductCreateDTO product)
        {
            var existingProduct = _productService.GetById(id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            else
            {
                _productService.UpdateProduct(id, product);
                return NoContent();
            }
            
        }

        //Delete
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                _productService.DeleteProduct(id);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            return NoContent();
        }
    }
}
