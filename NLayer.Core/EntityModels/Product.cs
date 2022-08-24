namespace NLayer.Core.EntityModels
{
    public class Product : BaseEntity
    {

        public Category Category { get; set; }
        public ProductFeature ProductFeature { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        

    }
}
