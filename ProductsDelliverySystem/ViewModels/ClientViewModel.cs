using ProductsDelliverySystem.Backend.OrderComponents;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using static ProductsDelliverySystem.OrdersSaveAndLoad;
using static ProductsDelliverySystem.Backend.BuilderPattern;

namespace ProductsDelliverySystem
{
    public class ClientViewModel : INotifyPropertyChanged
    {
        #region Переменные и коллекции
        private Order selectedOrder; // Выбранный заказ
        private ObservableCollection<Order> orders = new ObservableCollection<Order>(); // Список заказов
        private string orderVariableCategory = null; // Переменная категории
        private string orderVariableDestination = null; // Переменная места назначения
        private string orderVariableTransportSelection = null; // Переменная выбранного транспорта
        private int orderNumber = 1;
        private ObservableCollection<string> categoryNames = new ObservableCollection<string>()
        {
            "Продукты", "Арбузы", "Коробки", "Валенки" // Категории для заказа
        };
        private ObservableCollection<string> destinationNames = new ObservableCollection<string>()
        {
            "Москва", "Питер", "Томск", "Владивосток" // Место назначения для заказа
        };
        private ObservableCollection<string> transportNames = new ObservableCollection<string>()
        {
            "Грузовик", "Самолёт", "Реактивный сланец" // Доступный транспорт для заказа (зависимость от категории)
        };
        #endregion

        #region Команды

        private Command sendOrder; // Отправить заказ (Добавить его в коллекцию orders)
        public Command SendOrder
        {
            get
            {
                return sendOrder ?? (sendOrder = new Command(obj =>
                {
                    if (CategoryName != null && DestinationNames != null && TransportName != null)
                    {
                        int CategoryIndex = categoryNames.IndexOf(CategoryName);
                        int DestinationIndex = destinationNames.IndexOf(DestinationName);
                        int TransportIndex = transportNames.IndexOf(TransportName);
                        ConcreteBuilder builder = new ConcreteBuilder();
                        Director director = new Director(builder);
                        Order VariableOrder = new Order();
                        director.ClientBuild(CategoryName, CategoryIndex, DestinationName, DestinationIndex, TransportName, TransportIndex, orderNumber, VariableOrder);
                        Orders.Add(VariableOrder);
                        orderNumber++;
                        SaveCollectionToFile("OrdersList.json", Orders); // Запись в xml файл (полная перезапись файла)
                        MessageBox.Show("Успешно! Ваш заказ был передан оператору.");
                    }
                    else MessageBox.Show("Сначала выберите все необходимые параметры."); // если что-то не выбрано
                }));
            }
        }

        #endregion

        #region Getters And Setters

        public string CategoryName
        {
            get
            {
                return this.orderVariableCategory;
            }
            set
            {
                this.orderVariableCategory = value;

            }
        }

        public string DestinationName
        {
            get
            {
                return this.orderVariableDestination;
            }
            set
            {
                this.orderVariableDestination = value;
            }
        }

        public string TransportName
        {
            get
            {
                return this.orderVariableTransportSelection;
            }
            set
            {
                this.orderVariableTransportSelection = value;
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

        public ObservableCollection<string> TransportNames
        {
            get
            {
                return this.transportNames;
            }
            set
            {
                //if (CategoryName == "Арбузы")
                //{
                //    TransportNames.Insert(3, "Реактивный сланец");
                //    OnPropertyChanged("TransportNames");
                //}
                transportNames = value;
            }
        }

        public ObservableCollection<string> CategoryNames { get => categoryNames; set => categoryNames = value; }
        public ObservableCollection<string> DestinationNames { get => destinationNames; set => destinationNames = value; }
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