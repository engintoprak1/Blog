using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void Add(Category category)
        {
            _categoryRepository.Add(category);
        }

        public void Update(Category category)
        {
            _categoryRepository.Update(category);
        }

        public void Delete(int id)
        {
            Category category = GetById(id);
            _categoryRepository.Delete(category);
        }

        public Category GetById(int id)
        {
            return _categoryRepository.Get(x=>x.CategoryId == id);
        }

        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }
    }
}
