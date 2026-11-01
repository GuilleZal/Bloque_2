using Practico_Bloque2_ApiGestion.Models;
using Practico_Bloque2_ApiGestion_TheBusinessLayer.DTOs;

namespace Practico_Bloque2_ApiGestion_TheBusinessLayer.Services
{
    public interface IProductService
    {
        void AddProduct(ProductCreateDTO product);
        List<ProductDTO> GetAll();
        ProductDTO GetById(int id);
        List<ProductDTO> GetByCategory(string category);
        void UpdateProduct(int id, ProductCreateDTO product);
        void DeleteProduct(int id);
    }
}
