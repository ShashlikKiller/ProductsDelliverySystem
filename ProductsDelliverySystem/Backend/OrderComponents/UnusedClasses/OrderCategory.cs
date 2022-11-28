
namespace ProductsDelliverySystem.Backend.OrderComponents
{
    public class OrderCategory
    {


        public OrderCategory(string name, int? index)
        {
            this.Name = name;
            this.Index = index;
        }

        public string Name { get; set; }
        public int? Index { get; set; }
    }
}
