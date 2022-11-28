using ProductsDelliverySystem.Backend.OrderComponents;

namespace ProductsDelliverySystem.Backend
{
    public class BuilderPattern
    {
        public abstract class OrderBuilder
        {
            public abstract void AddCategory(string name, int? index, Order order); // Добавить структуру категории
            public abstract void AddDestination(string name, int? index, Order order); // Добавить структуру места назначения
            public abstract void AddTransport(string name, int? index, Order order); // Добавить структуру транспорта
            public abstract void AddPlaceOfDeparture(string name, int? index, Order order); // Добавить структуру места отправления
            public abstract void AddNumber(int number, Order order);
            public abstract int? AddPrice(Order order);
            public abstract Order GetResult(Order order); // Собрать заказ
        }

        public class Director
        {
            OrderBuilder selectedOrderBuilder;
            public Director(OrderBuilder builder)
            {
                this.selectedOrderBuilder = builder;
            }
            public void ClientBuild(string CategoryName, int? CategoryIndex, string DestinationName, int? DestinationIndex, string TransportName, int? TransportIndex, int number, Order order)
            {                
                selectedOrderBuilder.AddCategory(CategoryName, CategoryIndex, order);
                selectedOrderBuilder.AddDestination(DestinationName, DestinationIndex, order);
                selectedOrderBuilder.AddTransport(TransportName, TransportIndex, order);
                selectedOrderBuilder.AddNumber(number, order);
                selectedOrderBuilder.GetResult(order);
                
            }
            public void OperatorBuild(string DepartureName, int? DepartureIndex, Order order)
            {
                selectedOrderBuilder.AddPlaceOfDeparture(DepartureName, DepartureIndex, order);
                selectedOrderBuilder.AddPrice(order);
                selectedOrderBuilder.GetResult(order);
            }
        }
        public class ConcreteBuilder : OrderBuilder
        {
            public override void AddCategory(string name, int? index, Order order) // Добавление категории
            {
                order.OrderCategory = new OrderComponent(name, index);
            }
            public override void AddDestination(string name, int? index, Order SelectedOrder) // Добавление категории
            {
                SelectedOrder.OrderDestination = new OrderComponent(name, index);
            }
            public override void AddTransport(string name, int? index, Order SelectedOrder) // Добавление категории
            {
                SelectedOrder.OrderTransport = new OrderComponent(name, index); 
            }
            public override void AddPlaceOfDeparture(string name, int? index, Order SelectedOrder) // Добавление категории
            {
                SelectedOrder.OrderPlaceOfDeparture = new OrderComponent(name, index);
            }
            public override void AddNumber(int number, Order order)
            {
                order.OrderNumber = number;
            }

            /// <summary>
            /// Вычисление цены заказа в зависимости от его параметров
            /// </summary>
            /// <param name="SelectedOrder"> Заказ, для которого нужно вычислить стоимость </param>
            /// <returns></returns>
            public override int? AddPrice(Order SelectedOrder)
            {
                int distance = 0;
                if (SelectedOrder.OrderDestination.Index != SelectedOrder.OrderPlaceOfDeparture.Index)
                {
                    if (SelectedOrder.OrderDestination.Index == 0 || SelectedOrder.OrderPlaceOfDeparture.Index == 0)
                    {
                        if (SelectedOrder.OrderDestination.Index == 1 || SelectedOrder.OrderPlaceOfDeparture.Index == 1) distance = 100;
                        else if (SelectedOrder.OrderDestination.Index == 2 || SelectedOrder.OrderPlaceOfDeparture.Index == 2) distance = 200;
                        else if (SelectedOrder.OrderDestination.Index == 3 || SelectedOrder.OrderPlaceOfDeparture.Index == 3) distance = 100500;
                    }
                    if (SelectedOrder.OrderDestination.Index == 1 || SelectedOrder.OrderPlaceOfDeparture.Index == 1)
                    {
                        if (SelectedOrder.OrderDestination.Index == 2 || SelectedOrder.OrderPlaceOfDeparture.Index == 2) distance = 50;
                        else if (SelectedOrder.OrderDestination.Index == 3 || SelectedOrder.OrderPlaceOfDeparture.Index == 3) distance = 100500;
                    }
                    if (SelectedOrder.OrderDestination.Index == 2 || SelectedOrder.OrderPlaceOfDeparture.Index == 2)
                    {
                        if (SelectedOrder.OrderDestination.Index == 3 || SelectedOrder.OrderPlaceOfDeparture.Index == 3) distance = 100500;
                    }
                }
                return SelectedOrder.Price = (distance * (SelectedOrder.OrderCategory.Index + 1) / 10) + 500; // Если точка отправления и доставки
            }
            public override Order GetResult(Order order)
            {
                return order;
            }
        }
    }
}
