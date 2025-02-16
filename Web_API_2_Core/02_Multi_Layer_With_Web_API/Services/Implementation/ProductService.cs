using AutoMapper;
using Data.Entities;
using DTO;

public class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _repository;

    public ProductService(IMapper mapper, IProductRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task Create(ProductModel model)
    {
        var product = _mapper.Map<Product>(model);
        await _repository.Create(product);
    }

    public async Task Delete(int? id)
    {
       await _repository.Delete(id);
    }

    public async Task Edit(ProductModel model)
    {
        var product = _mapper.Map<Product>(model);
       await _repository.Edit(product);
    }

    public async Task<List<ProductModel>> GetAll()
    {
       List<Product> products = await _repository.GetAll();
       return _mapper.Map<List<ProductModel>>(products);
    }

    public async Task<ProductModel> GetById(int? id)
    {
        var product = await _repository.GetById(id);

        return _mapper.Map<ProductModel>(product);
    }
}