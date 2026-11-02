using Bloque2_DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloque2_DataAccessLayer.Repositories
{
    public class ProductRepository : IProductRepository
    {
        // Utilizar una List<Producto> privada para almacenar los registros de forma temporal.
        private readonly List<Product> _products;

        public ProductRepository()
        {
            _products = new List<Product>()
            {
            new Product { Id = 1, Name = "Producto 1", Price = 10.99m, Category = "Limpieza", Active = true },
            new Product { Id = 2, Name = "Producto 2", Price = 19.99m, Category = "Liquidos", Active = true },
            new Product { Id = 3, Name = "Producto 3", Price = 5.99m, Category = "Jabones", Active = false },
            new Product { Id = 4, Name = "Producto 4", Price = 15.49m, Category = "Lacteos", Active = true }
            };
        }
       
        public List<Product> GetAll()
        {
            return _products;
        }
        public Product GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public List<Product> GetByCategory(string category)
        {
            return _products.Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public void AddProduct(Product product)
        {
            product.Id = _products.Max(p => p.Id) + 1;
            _products.Add(product);
        }

        //no estoy seguro si debe ir id como parametro pero en el product service
        //no tengo forma de obtener el id ya que el productDTO no tiene id, entonces lo dejo asi por ahora
        public void UpdateProduct(Product product)
        {
            var existingProduct = _products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                _products.Remove(existingProduct);
                _products.Add(product);
            }
        }
        public void DeleteProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _products.Remove(product);
            }
        }
    }
}
