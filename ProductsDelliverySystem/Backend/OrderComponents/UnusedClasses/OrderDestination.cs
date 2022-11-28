
namespace ProductsDelliverySystem.Backend.OrderComponents
{
    public class OrderDestination // Можно сделать через наследование
    {
        public OrderDestination()
        {
            // заглушка для сериализации
        }

        public OrderDestination(string name, int? index)
        {
            this.Name = name;
            this.Index = index;
        }

        public string Name { get; set; }
        public int? Index { get; set; }
    }
}
