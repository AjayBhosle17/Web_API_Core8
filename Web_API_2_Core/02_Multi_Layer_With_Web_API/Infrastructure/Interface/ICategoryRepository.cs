using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interface
{
    public interface ICategoryRepository
    {
        public Task<List<Category>> GetAll();

        public Task<Category> GetById(int? id);

        public Task Create(Category category);

        public Task Edit(Category category);

        public Task Delete(int? id);
    }
}
