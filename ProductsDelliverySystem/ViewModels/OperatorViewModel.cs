using ProductsDelliverySystem.Backend.OrderComponents;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using static ProductsDelliverySystem.Backend.BuilderPattern;
using static ProductsDelliverySystem.OrdersSaveAndLoad;

namespace ProductsDelliverySystem
{
    class OperatorViewModel : INotifyPropertyChanged
    {
        #region Переменные и коллекции
        private Order selectedOrder; // Выбранный заказ
        private string orderVariableName = null; // Переменная выбранного места отправления
        private int? orderVariableIndex;
        private ObservableCollection<Order> orders = new ObservableCollection<Order>(); // Список заказов
        private ObservableCollection<Order> ordersReady = new ObservableCollection<Order>();
        private ObservableCollection<string> placesNames = new ObservableCollection<string>()
        {
            "Москва", "Питер", "Томск", "Владивосток"
        };
        #endregion

        #region Команды
        private Command refreshOrders; // Загрузить заказы в листбокс окна оператора
        public Command RefreshOrders
        {
            get
            {
                return refreshOrders ?? (refreshOrders = new Command(obj =>
                {
                    Orders = LoadCollectionFromFile<Order>("OrdersList.json"); // Загрузка из xml файла
                    OnPropertyChanged("Orders"); // Уведомление об изменении листа (при полной замене нет уведомлений)
                }));
            }
        }

        private Command makeThisOrderReady; // команда для чекбокса(изменить бул readytosend)
        public Command MakeThisOrderReady
        {
            get
            {
                return makeThisOrderReady ?? (makeThisOrderReady = new Command(obj =>
                {
                    if (OrderVariableName != null && SelectedOrder != null)
                    {
                        orderVariableIndex = PlacesNames.IndexOf(orderVariableName);
                        SelectedOrder.ReadyToSend = true; // можно убрать из Order бул готовности, тк он все равно не нужен
                        ConcreteBuilder builder = new ConcreteBuilder();
                        Director director = new Director(builder);
                        director.OperatorBuild(orderVariableName, orderVariableIndex, SelectedOrder);
                        OrdersReady.Add(SelectedOrder);
                        SaveCurrentOrderToFile("ReadyOrdersList.json", OrdersReady); // Перезапись списка готовых заказов
                        Orders.RemoveAt(Orders.IndexOf(SelectedOrder));
                        OnPropertyChanged("OrdersReady"); // тоже не нужен, т.к. obs. Collection уведомляет о своем изменении
                        MessageBox.Show("Данный заказ получил статус готового к отправлению.");
                    }
                    else MessageBox.Show("Сначала выберите место отправления заказа.");
                }
                ));
            }
        }
        #endregion

        #region Getters And Setters
        public ObservableCollection<Order> OrdersReady
        {
            get
            {
                return ordersReady;
            }
            set
            {
                ordersReady = value;
            }
        }

        public Order SelectedOrder
        {
            get
            {
                return this.selectedOrder;
            }

            set
            {
                this.selectedOrder = value;
                OnPropertyChanged("SelectedOrder");
            }
        }

        public ObservableCollection<Order> Orders
        {
            get
            {
                return this.orders;
            }
            set
            {
                orders = value;
            }
        }

        public ObservableCollection<string> PlacesNames { get => placesNames; set => placesNames = value; }
        public string OrderVariableName { get => orderVariableName; set => orderVariableName = value; }
        #endregion

        #region Notify about prop changes
        public event PropertyChangedEventHandler PropertyChanged; // notify
        public void OnPropertyChanged([CallerMemberName] string prop = "") // notify bout prop changes
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        #endregion
    }
}