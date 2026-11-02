using Bloque2_DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloque2_DataAccessLayer.Repositories
{
    public interface IProductRepository
    {
        void AddProduct(Product product);

        List<Product> GetAll();

        Product GetById(int id);

        List<Product> GetByCategory(string category);

        void DeleteProduct(int id);
        void UpdateProduct(Product product);
    }
}
