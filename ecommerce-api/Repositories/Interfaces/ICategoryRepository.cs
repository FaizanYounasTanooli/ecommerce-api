using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecommerce_api.Models;

namespace PosCommon.Services.Interfaces
{
    public interface ICategoryRepository
    {
        Category AddCategory(Category category);
        Category UpdateCategory(Category category);
        bool DeleteCategory(long Id);
        List<Category> GetAllCategories();

    }
}
