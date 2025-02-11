using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface ICategoryService
    {
        public Task<List<CategoryModel>> GetAll();
        public Task<CategoryModel> GetById(int? id);
        public Task Create(CategoryModel categoryMd);
        public Task Update(CategoryModel categoryMd);
        public Task Delete(int? id);


    }
}
