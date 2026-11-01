using Practico_Bloque2_ApiGestion.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practico_Bloque2_ApiGestion.Repositories
{
    public interface IProductRepository
    {
        void AddProduct(Product product);

        List<Product> GetAll();

        Product GetById(int id);

        List<Product> GetByCategory(string category);

        void DeleteProduct(int id);
        void UpdateProduct(int id, Product product);
    }
}
