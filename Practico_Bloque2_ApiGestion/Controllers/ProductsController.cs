using Microsoft.AspNetCore.Mvc;
using Bloque2_BusinessLayer.Services;
using Bloque2_DataAccessLayer.Models;
using Bloque2_BusinessLayer.DTOs;

namespace Bloque2_PresentationLayer.Controllers
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

        //Read
        [HttpGet]
        public IActionResult GetAllProducts()
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
        [HttpGet("{category}")]
        public IActionResult GetByCategory(string category)
        {
            var products = _productService.GetByCategory(category);
            return Ok(products);
        }

        //Create
        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductCreateDTO productDTO)
        {
            try
            {
                _productService.AddProduct(productDTO);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(productDTO);
        }

        //Update
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] ProductCreateDTO productCreateDTO)
        {

            try
            {
                var existingProduct = _productService.GetById(id);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok();
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
