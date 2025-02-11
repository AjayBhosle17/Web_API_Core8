using AutoMapper;
using Data.Entities;
using DTO;
using Infrastructure.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class CategoryService : ICategoryService
    {
        ICategoryRepository _repo;
        IMapper _mapper;

        public CategoryService(ICategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task Create(CategoryModel categoryMd)
        {
            var category =  _mapper.Map<Category>(categoryMd);
            await _repo.Create(category);
        }

        public async Task Delete(int? id)
        {
            await _repo.Delete(id);
        }

        public async Task<List<CategoryModel>> GetAll()
        {
            var Categories = await _repo.GetAll();
            var categoryModel=  _mapper.Map<List<CategoryModel>>(Categories);

            return  categoryModel;
        }

        public async Task<CategoryModel> GetById(int? id)
        {
            var category = await _repo.GetById(id);
            if (category != null)
            {
                return _mapper.Map<CategoryModel>(category);
            }
            return null;
           
        }

        public async Task Update(CategoryModel categoryMd)
        {
            var category = _mapper.Map<Category>(categoryMd);

            await _repo.Edit(category);

        }
            
    }
}
