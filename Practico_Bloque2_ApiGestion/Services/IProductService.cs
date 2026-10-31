using Practico_Bloque1_Gestor.Models;
using Practico_Bloque2_ApiGestion.DTOs;

namespace Practico_Bloque2_ApiGestion.Services
{
    public interface IProductService
    {
        void Add(ProductDTO product);
        List<ProductDTO> GetAll();
        ProductDTO GetById(int id);
        List<ProductDTO> GetByCategory(string category);
        void UpdateProduct(ProductDTO product);
        void DeleteProduct(int id);
    }
}
