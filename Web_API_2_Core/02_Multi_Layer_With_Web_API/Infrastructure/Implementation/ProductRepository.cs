using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

public class ProductRepository : IProductRepository
{

    CoreDbContext _context;
    IMemoryCache _memoryCache;

    public ProductRepository(CoreDbContext context, IMemoryCache memoryCache)
    {
        _context = context;
        _memoryCache = memoryCache;
    }   

    public async Task Create(Product product)
    {
        _context.Products.Add(product);
       await _context.SaveChangesAsync();


    }

    public async Task Delete(int? id)
    {
        var product = await _context.Products.FindAsync(id);
        
        _context.Products.Remove(product);
        _context.SaveChanges();
        

    }

    public async Task Edit(Product product)
    {
       _context.Entry(product).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task<List<Product>> GetAll()
    {
        /* List<Product> products = _memoryCache.Get("products") as List<Product>;

         if (products == null)
         {

             products = await _context.Products.ToListAsync();

             _memoryCache.Set("products", products);
         }*/

        List<Product> products = await _context.Products.ToListAsync();


        return products;
    }

    public async Task<Product> GetById(int? id)
    {
        var product = await _context.Products.FindAsync(id);

        return product;
    }
}