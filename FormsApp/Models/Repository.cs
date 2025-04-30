namespace FormsApp.Models{

    public class Repository{

        private static readonly List<Product> _products = new();
        private static readonly List<Category> _categories = new();

        static Repository(){
            _categories.Add(new Category{CategoryId = 1, Name="Telefon"});
            _categories.Add(new Category{CategoryId = 2, Name="Bilgisayar"});

            _products.Add(new Product{ProductId = 1, Name="MacBook",Image="1.jpg",Price=80000,isActive=true,CategoryId=2});
            _products.Add(new Product{ProductId = 2, Name="MacBook Pro",Image="2.jpeg",Price=90000,isActive=true,CategoryId=2});
            _products.Add(new Product{ProductId = 3, Name="Iphone 15 Pro",Image="3.jpg",Price=100000,isActive=true,CategoryId=1});
            _products.Add(new Product{ProductId = 4, Name="Iphone 15 Pro Max",Image="4.jpg",Price=120000,isActive=true,CategoryId=1});
        }

        public static List<Product> Products{get{return _products;}}

        public static void CraeteProduct(Product entity){
            _products.Add(entity);
        }

        public static void EditProduct(Product updateEntity){
            var entity = _products.FirstOrDefault(p=>p.ProductId == updateEntity.ProductId);
            if(entity != null){
                entity.Name = updateEntity.Name;
                entity.Price = updateEntity.Price;
                entity.Image = updateEntity.Image;
                entity.isActive = updateEntity.isActive;
                entity.CategoryId = updateEntity.CategoryId;
            }
        }

        public static void DeleteProduct(Product entity){
            var prdEntity = _products.FirstOrDefault(p=>p.ProductId == entity.ProductId);

            if(prdEntity != null){
                _products.Remove(prdEntity);
            }
        }
        public static List<Category> Categories{get{return _categories;}}
    }
}