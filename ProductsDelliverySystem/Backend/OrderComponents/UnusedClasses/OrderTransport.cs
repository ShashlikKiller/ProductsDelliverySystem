
namespace ProductsDelliverySystem.Backend.OrderComponents
{
    public class OrderTransport
    {
        public OrderTransport()
        {
            // заглушка для сериализации
        }
        public OrderTransport(string name, int? index)
        {
            this.Name = name;
            this.Index = index;
        }

        public string Name { get; set; }
        public int? Index { get; set; }
    }
}