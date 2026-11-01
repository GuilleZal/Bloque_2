using Practico_Bloque2_ApiGestion.Repositories;
using Practico_Bloque2_ApiGestion.DTOs;
using Practico_Bloque2_ApiGestion.Models;

namespace Practico_Bloque2_ApiGestion_TheBusinessLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductRepository _productRepository;

        ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void AddProduct(ProductCreateDTO product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "El libro no puede ser nulo");
            }
            else if (product.Price < 0)
            {
                throw new ArgumentException("El precio no puede ser negativo", nameof(product.Price));
            }
            else
            {
                var newProduct = new Product
                {
                    Name = product.Name,
                    Price = product.Price,
                    Category = product.Category,
                    Active = true
                };
                _productRepository.AddProduct(newProduct);
            }
        }

        public void DeleteProduct(int id)
        {

            if (id <= 0)
            {
                throw new ArgumentException("El id debe ser mayor que cero", nameof(id));
            }
            else if (_productRepository.GetById(id) == null)
            {
                throw new ArgumentException("El producto no existe", nameof(id));
            }
            else if (_productRepository.GetById(id).Active == false)
            {
                throw new ArgumentException("El producto ya está inactivo", nameof(id));
            }
            else
            {
                _productRepository.DeleteProduct(id);
            }
        }

        public List<ProductDTO> GetAll()
        {
            return _productRepository.GetAll();
        }

        public List<ProductDTO> GetByCategory(string category)
        {
            return _productRepository.GetByCategory(category);
        }

        public ProductDTO GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public void UpdateProduct(int Id, ProductCreateDTO product)
        {
            
            var existingProduct = _productRepository.GetById(Id);
            if (existingProduct == null)
            {
                throw new ArgumentException("El producto no existe", nameof(Id));
            }
            else 
            { 
                _productRepository.UpdateProduct(Id, existingProduct);
            }
        }
    }
}
