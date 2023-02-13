using Project.BLL.Repository;
using Project.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> repository;
        public ProductService(IRepository<Product> repository)
        {
            this.repository = repository;
        }

        public void CreateProduct(Product product)
        {
            repository.Insert(product);
        }

        public void DeleteProduct(Product product)
        {
            repository.Remove(product);
        }

        public IEnumerable<Product> GetAll()
        {
            return repository.GetAll();
        }

        public Product GetProduct(int id)
        {
            return repository.Get(id);
        }

        public void UpdateProduct(Product product)
        {
            repository.Update(product);
        }
    }
}