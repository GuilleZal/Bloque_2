using Practico_Bloque2_ApiGestion.DTOs;

namespace Practico_Bloque2_ApiGestion.Services
{
    public class ProductService : IProductService
    {
        public void Add(ProductDTO product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "El libro no puede ser nulo");
            }
            if (product.Price < 0)
            {
                throw new ArgumentException("El precio no puede ser negativo", nameof(product.Price));
            }
            if (product.Name == null)
            {
                throw new ArgumentException("El nombre no puede ser nulo", nameof(product.Name));
            }
            if (product.Category == null)
            {
                throw new ArgumentException("La categoría no puede ser nula", nameof(product.Category));
            }
            if (product.Active == null)
            {
                throw new ArgumentException("El estado activo no puede ser nulo", nameof(product.Active));
            }
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public List<ProductDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<ProductDTO> GetByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public ProductDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(ProductDTO product)
        {
            throw new NotImplementedException();
        }
    }
}
