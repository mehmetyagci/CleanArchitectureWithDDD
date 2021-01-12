using Core.Entities;
using Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        // ICategoryRepository ' Özel Operasyonlar
        Task<Category> GetCategoryWithProductsAsync(int categoryId);
    }
}
