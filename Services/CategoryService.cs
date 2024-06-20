using BusinessObjects.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository iCategoryService;

        public CategoryService()
        {
            iCategoryService = new CategoryRepository();
        }
        public List<Category> GetCategories()
        {
            return iCategoryService.GetCategories();
        }
    }
}
