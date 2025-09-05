//using M01.ModelAndInMemoryStoreSetup.Models;


public class ProductStore
{
    private readonly List<Product> _products = [
        new Product { Id = Guid.NewGuid(), Name = "Product 1", Price = 10.99m },
        new Product { Id = Guid.NewGuid(), Name = "Product 2", Price = 20.99m },
        new Product { Id = Guid.NewGuid(), Name = "Product 3", Price = 30.99m }
    ];

    public IEnumerable<Product> GetAll() => _products;

    public Product? GetById(Guid id) => _products.FirstOrDefault(p=>p.Id == id);

    public void Add(Product product)
    {
        _products.Add(product);
    }
    
    public bool Update(Product updatedProduct)
    {
        var existing = _products.FirstOrDefault(p => p.Id == updatedProduct.Id);

        if(existing is null)
            return false;
        
        existing.Name = updatedProduct.Name;
        existing.Price = updatedProduct.Price;

        return true;
    }

    public bool Delete(Product product)
    {
        var existing = _products.FirstOrDefault(p => p.Id == product.Id);
 
        return existing != null && _products.Remove(product);
    }
}

