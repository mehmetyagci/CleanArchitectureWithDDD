using Core.Entities;
using Core.Specification.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Specification
{
    public class ProductWithCategorySpecification : BaseSpecification<Product>
    {
        public ProductWithCategorySpecification(string productName) 
            : base(p => p.ProductName.ToLower().Contains(productName.ToLower()))

        {
            AddInclude(p => p.Category);
        }

        public ProductWithCategorySpecification() : base(null)
        {
            AddInclude(p => p.Category);
        }
    } // end of class
} // end of namespace
