//using Bloque2_DataAccessLayer.Models;
using Bloque2_BusinessLayer.DTOs;

namespace Bloque2_BusinessLayer.Services
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
