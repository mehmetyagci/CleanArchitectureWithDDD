using Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Entities
{
    public class Compare : Entity
    {
        public string UserName { get; set; }

        public List<ProductCompare> ProductCompares { get; set; } = new List<ProductCompare>();

        public void AddItem(int productId)
        {
            var existingItem = ProductCompares.FirstOrDefault(x => x.ProductId == productId);
            if (existingItem != null)
            {
                return;
            }

            ProductCompares.Add(new ProductCompare
            {
                ProductId = productId,
                CompareId = this.Id
            });
        }

        public void RemoveItem(int productId)
        {
            var removedItem = ProductCompares.FirstOrDefault(x => x.ProductId == productId);
            if(removedItem != null)
            {
                ProductCompares.Remove(removedItem);
            }
        }
    }
}
