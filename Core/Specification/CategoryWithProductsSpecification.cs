using Core.Entities;
using Core.Specification.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Specification
{
    public sealed class CategoryWithProductsSpecification : BaseSpecification<Category>
    {
        public CategoryWithProductsSpecification(int categoryId) : base(b => b.Id == categoryId)
        {
            AddInclude(b => b.Products);
        }
    }
}
