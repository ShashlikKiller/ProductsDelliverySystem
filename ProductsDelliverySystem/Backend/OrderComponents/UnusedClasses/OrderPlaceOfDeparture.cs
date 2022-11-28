
namespace ProductsDelliverySystem.Backend.OrderComponents
{
    public class OrderPlaceOfDeparture
    {
        public OrderPlaceOfDeparture()
        {
            // заглушка для сериализации
        }
        public OrderPlaceOfDeparture(string name, int? index)
        {
            this.Name = name;
            this.Index = index;
        }

        public string Name { get; set; }
        public int? Index { get; set; }
    }
}
