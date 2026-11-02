using Bloque2_DataAccessLayer.Repositories;
using Bloque2_BusinessLayer.DTOs;
using Bloque2_DataAccessLayer.Models;

namespace Bloque2_BusinessLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<ProductDTO> GetAll()
        {
            //Obtiene todos los productos de la base de datos y los convierte a DTOs
            var products = _productRepository.GetAll();
            var productsDTOs = products.Select(p => new ProductDTO
            {
                Name = p.Name,
                Price = p.Price,
                Category = p.Category,
                Active = p.Active
            }).ToList();

            return productsDTOs;
        }
        public ProductDTO GetById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id debe ser mayor que cero", nameof(id));
            }
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                throw new KeyNotFoundException($"El producto con id {id} no existe");
            }
            var productDTO = new ProductDTO
            {
                Name = product.Name,
                Price = product.Price,
                Category = product.Category,
                Active = product.Active
            };  
            return productDTO;
        }
        public List<ProductDTO> GetByCategory(string category)
        {
            var products = _productRepository.GetByCategory(category);
            var productsDTOs = products.Select(p => new ProductDTO
            {
                Name = p.Name,
                Price = p.Price,
                Category = p.Category,
                Active = p.Active
            }).ToList();
            return productsDTOs;
        }

        public void AddProduct(ProductCreateDTO productCreateDTO)
        {
            if (productCreateDTO == null)
            {
                throw new ArgumentNullException(nameof(productCreateDTO), "El producto a agregar no puede ser nulo");
            }
            if (productCreateDTO.Price < 0)
            {
                throw new ArgumentException("El precio no puede ser negativo", nameof(productCreateDTO.Price));
            }
            var newProduct = new Product
            {
                Name = productCreateDTO.Name,
                Price = productCreateDTO.Price,
                Category = productCreateDTO.Category,
                Active = true
            };
            _productRepository.AddProduct(newProduct);
        }

        public void UpdateProduct(int Id, ProductCreateDTO productCreateDTO)
        {
            
            if (productCreateDTO == null)
            {
                throw new ArgumentNullException(nameof(productCreateDTO), "El producto a actualizar no puede ser nulo");
            }
            if (productCreateDTO.Name == null)
            {
                throw new ArgumentException("El nombre del producto no puede ser nulo", nameof(productCreateDTO.Name));
            }
            if (productCreateDTO.Price < 0)
            {
                throw new ArgumentException("El precio no puede ser negativo", nameof(productCreateDTO.Price));
            }
            if (productCreateDTO.Category == null)
            {
                throw new ArgumentException("La categoría del producto no puede ser nula", nameof(productCreateDTO.Category));
            }
            if (Id <= 0)
            {
                throw new ArgumentException("El id debe ser mayor que cero", nameof(Id));
            }
            var existingProduct = _productRepository.GetById(Id);
            if (existingProduct == null)
            {
                throw new ArgumentException("El producto no existe", nameof(Id));
            }

            existingProduct.Name = productCreateDTO.Name;
            existingProduct.Price = productCreateDTO.Price;
            existingProduct.Category = productCreateDTO.Category;
            existingProduct.Active = true;  
            _productRepository.UpdateProduct(existingProduct);
        }
        public void DeleteProduct(int id)
        {
            var existingProduct = _productRepository.GetById(id);
            if (existingProduct == null)
            {
                throw new ArgumentException("El producto no existe", nameof(id));
            }
            _productRepository.DeleteProduct(id);
        }
    }
}
