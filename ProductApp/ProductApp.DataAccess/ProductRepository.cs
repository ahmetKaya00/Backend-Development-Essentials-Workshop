using Microsoft.EntityFrameworkCore;
using ProductApp.Entities;

namespace ProductApp.DataAccess{

    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context) => _context = context;
        public void Add(Product product) => _context.Products.Add(product);

        public void Delete(Product product) => _context.Products.Remove(product);

        public List<Product> GetAll()=> _context.Products.ToList();

        public Product? GetById(int id) => _context.Products.Find(id);

        public void Save() => _context.SaveChanges();

        public void Update(Product product) => _context.Products.Update(product);
    }
}