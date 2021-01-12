using Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Entities
{
    public class Cart : Entity
    {
        public string UserName { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public void AddItem(int productId, int quantity = 1 , string color ="Black", decimal unitPrice = 0)
        {
            var existingItem = Items.FirstOrDefault(i => i.ProductId == productId);

            if(existingItem != null)
            {
                existingItem.Quantity = existingItem.Quantity + 1;
                existingItem.TotalPrice = existingItem.Quantity * existingItem.UnitPrice;
            }
            else
            {
                Items.Add(new CartItem()
                {
                    ProductId = productId,
                    Quantity = quantity,
                    Color = color,
                    UnitPrice = unitPrice,
                    TotalPrice = quantity * unitPrice
                });
            }
        }

        public void RemoveItem(int carItemId)
        {
            var removedItem = Items.FirstOrDefault(x => x.Id == carItemId);
            if(removedItem != null)
            {
                Items.Remove(removedItem);
            }
        }

        public void RemoveItemWithProduct(int productId)
        {
            var removedItem = Items.FirstOrDefault(x => x.ProductId == productId);
            if(removedItem != null)
            {
                Items.Remove(removedItem);
            }
        }

        public void ClearItems()
        {
            Items.Clear();
        }

    } //end of class
} // end of namespace
