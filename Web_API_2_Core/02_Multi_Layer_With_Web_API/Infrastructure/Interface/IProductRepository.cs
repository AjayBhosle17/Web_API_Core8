using Data.Entities;

public interface IProductRepository
{
    public Task<List<Product>> GetAll();

    public Task<Product> GetById(int? id);

    public Task Create(Product category);

    public Task Edit(Product category);

    public Task Delete(int? id);
}