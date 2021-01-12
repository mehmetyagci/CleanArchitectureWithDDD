using Core.Entities.Base;

namespace Core.Entities
{
    public class ProductCompare : Entity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int CompareId { get; set; }
        public Compare Compare { get; set; }
    }
}