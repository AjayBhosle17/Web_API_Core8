using DTO;

public interface IProductService
{
    Task<List<ProductModel>> GetAll();

    Task<ProductModel> GetById(int? id);

    Task Create(ProductModel model);

    Task Edit(ProductModel model);

    Task Delete(int? id);
}