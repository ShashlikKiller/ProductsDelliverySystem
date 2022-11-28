

namespace ProductsDelliverySystem.Backend.OrderComponents
{
    public class OrderComponent
    {
        public OrderComponent()
        {
            // заглушка для сериализации
        }

        public OrderComponent(string name, int? index)
        {
            this.Name = name;
            this.Index = index;
        }

        public string Name { get; set; }
        public int? Index { get; set; }
    }
}
