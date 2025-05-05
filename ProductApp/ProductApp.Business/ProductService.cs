using ProductApp.DataAccess;
using ProductApp.Entities;

namespace ProductApp.Business{

    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo) => _repo = repo;
        public void Add(Product product)
        {
            _repo.Add(product);
            _repo.Save();
        }

        public void Delete(int id)
        {
           var p = _repo.GetById(id);
           if(p != null){
            _repo.Delete(p);
            _repo.Save();
           }
        }

        public List<Product> GetAll() => _repo.GetAll();

        public Product? GetById(int id) => _repo.GetById(id);

        public void Update(Product product)
        {
            var existing = _repo.GetById(product.Id);
            if (existing == null) throw new Exception("Bulunamadı!");
            existing.Name = product.Name;
            existing.Price = product.Price;
            _repo.Update(existing);
            _repo.Save();
        }
    }
}