using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using static ProductsDelliverySystem.OrdersSaveAndLoad;

namespace ProductsDelliverySystem
{
    class SystemAppViewModel : INotifyPropertyChanged
    {
        //public int? PriceCalc(Order SelectedOrder) //OrderComponent orderTransport, OrderComponent orderDestination, OrderComponent orderPlaceOfDeparture)
        //{
        //    int distance = 0;
        //    if (SelectedOrder.orderDestination.Index != SelectedOrder.orderPlaceOfDeparture.Index)
        //    {
        //        if (SelectedOrder.orderDestination.Index == 0 || SelectedOrder.orderPlaceOfDeparture.Index == 0)
        //        {
        //            if (SelectedOrder.orderDestination.Index == 1 || SelectedOrder.orderPlaceOfDeparture.Index == 1) distance = 100;
        //            else if (SelectedOrder.orderDestination.Index == 2 || SelectedOrder.orderPlaceOfDeparture.Index == 2) distance = 200;
        //            else if (SelectedOrder.orderDestination.Index == 3 || SelectedOrder.orderPlaceOfDeparture.Index == 3) distance = 100500;
        //        }
        //        if (SelectedOrder.orderDestination.Index == 1 || SelectedOrder.orderPlaceOfDeparture.Index == 1)
        //        {
        //            if (SelectedOrder.orderDestination.Index == 2 || SelectedOrder.orderPlaceOfDeparture.Index == 2) distance = 50;
        //            else if (SelectedOrder.orderDestination.Index == 3 || SelectedOrder.orderPlaceOfDeparture.Index == 3) distance = 100500;
        //        }
        //        if (SelectedOrder.orderDestination.Index == 2 || SelectedOrder.orderPlaceOfDeparture.Index == 2)
        //        {
        //            if (SelectedOrder.orderDestination.Index == 3 || SelectedOrder.orderPlaceOfDeparture.Index == 3) distance = 100500;
        //        }
        //    }
        //    return price = (distance * (SelectedOrder.orderCategory.Index + 1) / 10) + 500; // Если точка отправления и доставки
        //    // одинаковая - стоймость всегда 500.
        //}



        // Ненужный класс. Все данные были перенесены во ViewModel'и определенных окон.
        // Используется как средство отката в случае поломки.

        #region Переменные и коллекции

        //private Order selectedOrder; // Выбранный заказ
        //private ObservableCollection<Order> orders = new ObservableCollection<Order>(); // Список заказов
        //private ObservableCollection<Order> ordersRDY = new ObservableCollection<Order>(); // список готовых заказов
        //private ObservableCollection<Order> ordersOP = new ObservableCollection<Order>(); // Список заказов для оператора
        //private string orderVariableCategory = ""; // Переменная категории
        //private string orderVariableDestination = ""; // Переменная места назначения
        //private int? orderVariableTransportSelection = null; // Переменная выбранного транспорта
        //private int? orderVariablePlacesOfDepartures = null; // Переменная выбранного места отправления
        //private int ordNumb = 1; // Переменная номера заказа
        //private int checkNumber = 1; // Переменная номера чека
        //private ObservableCollection<string> categorys = new ObservableCollection<string>()
        //{
        //    "Category1", "Category2", "Category3", "Category4" // Категории для заказа
        //};
        //private ObservableCollection<string> destinations = new ObservableCollection<string>()
        //{
        //    "Destination1", "Destination2" // Место назначения для заказа
        //};
        //private ObservableCollection<int> availableTransports = new ObservableCollection<int>()
        //{
        //    1, 2, 3 // Доступный транспорт для заказа (зависимость от категории)
        //};
        //private ObservableCollection<int> placesOfDeparture = new ObservableCollection<int>()
        //{
        //    1, 2, 3 // Места, из которых отправится заказ
        //};
        #endregion

        #region Визуал
        //public string NotifyColor // Изменение цвета кнопки при изменении списка готовых заказов
        //{
        //    get
        //    {
        //        return NotifyColor; // если OrdersRDY.Add(...) = Red
        //        // Нажатие на кнопку = обратно в изначальный цвет
        //    }
        //    set
        //    {
        //        NotifyColor = value;
        //    }
        //}

        #endregion // Не рабочий

        #region Команды VM

        //private Command sendOrder; // Отправить заказ (Добавить его в коллекцию orders)
        //public Command SendOrder
        //{
        //    get
        //    {
        //        return sendOrder ?? (sendOrder = new Command(obj =>
        //        {
        //            if (orderVariableCategory !="" && orderVariableDestination != "" && orderVariableTransportSelection != null)
        //            {
        //                //Orders.Add(new Order(orderVariableCategory, orderVariableDestination, orderVariableTransportSelection, ordNumb));
        //                //SaveCollectionToFile("OrdersList.xml", Orders); // Запись в xml файл (полная перезапись файла)
        //                MessageBox.Show("Успешно! Ваш заказ был передан оператору.");
        //                ordNumb++;
        //            }
        //            else MessageBox.Show("Сначала выберите все необходимые параметры."); // если что-то не выбрано
        //        }));
        //    }
        //}

        //private Command refreshOrders; // Загрузить заказы в листбокс окна оператора
        //public Command RefreshOrders
        //{
        //    get
        //    {
        //        return refreshOrders ?? (refreshOrders = new Command(obj =>
        //        {
        //            OrdersOP = LoadCollectionFromFile<Order>("OrdersList.xml"); // Загрузка из xml файла
        //            OnPropertyChanged("OrdersOP"); // Уведомление об изменении листа (при полной замене нет уведомлений)
        //            }));
        //    }
        //}

        //// Ненужная
        //private Command loadReadyOrders; // загрузить заказы готовые к отправке
        //public Command LoadReadyOrders
        //{
        //    get
        //    {
        //        return loadReadyOrders ?? (loadReadyOrders = new Command(obj =>
        //        {
        //            OrdersRDY = LoadCollectionFromFile<Order>("ReadyOrdersList.xml"); // Загрузка из xml файла
        //            OnPropertyChanged("OrdersRDY"); // Уведомление об изменении листа (при полной замене нет уведомлений)
        //        }));
        //        }
        //}
        //private Command makeThisOrderReady; // команда для чекбокса(изменить бул readytosend)
        //public Command MakeThisOrderReady
        //{
        //    get
        //    {
        //        // Сделать это всё через сохранение SelectedOrder в xml
        //        return makeThisOrderReady ?? (makeThisOrderReady = new Command(obj =>
        //        {
        //            if (orderVariablePlacesOfDepartures != null && SelectedOrder != null)
        //            {
        //                //SelectedOrder.ReadyToSend = true;
        //                //SelectedOrder.PlaceOfDeparture = orderVariablePlacesOfDepartures;
        //                //OrdersRDY.Add(SelectedOrder);
        //                //OrdersOP.RemoveAt(OrdersOP.IndexOf(SelectedOrder));
        //                //OnPropertyChanged("OrdersRDY");
        //                //SaveToXml("ReadyOrdersList.xml", OrdersRDY); // сохранение готового ЗАКАЗА в файл
        //                MessageBox.Show("Данный заказ получил статус готового к отправлению.");
        //            }
        //            else MessageBox.Show("Сначала выберите место отправления заказа.");
        //        }
        //        ));
        //    }
        //}
        //private Command makeChecks;
        //public Command MakeChecks
        //{
        //    get
        //    {
        //        return makeChecks ?? (makeChecks = new Command(obj =>
        //        {
        //        MakeChecksForOrder("CheckList.txt", SelectedOrder, checkNumber);
        //        checkNumber++;
        //        MessageBox.Show("Все документы были сохранены в файл: CheckList.txt");
        //        }));
        //    }
        //}

        #endregion

        #region Getters And Setters

        //public int? OrderVariablePlacesOfDepartures
        //{
        //    get
        //    {
        //        return this.orderVariablePlacesOfDepartures;
        //    }
        //    set
        //    {
        //        this.orderVariablePlacesOfDepartures = value;

        //    }
        //}

        //public string OrderVariableCategory
        //{
        //    get
        //    {
        //        return this.orderVariableCategory;
        //    }
        //    set
        //    {
        //        this.orderVariableCategory = value;

        //    }
        //}

        //public string OrderVariableDestination
        //{
        //    get
        //    {
        //        return this.orderVariableDestination;
        //    }
        //    set
        //    {
        //        this.orderVariableDestination = value;
        //    }
        //}

        //public int? OrderVariableTransportSelection
        //{
        //    get
        //    {
        //        return this.orderVariableTransportSelection;
        //    }
        //    set
        //    {
        //        this.orderVariableTransportSelection = value;
        //    }
        //}

        //public Order SelectedOrder
        //{
        //    get
        //    {
        //        return this.selectedOrder;
        //    }

        //    set
        //    {
        //        this.selectedOrder = value;
        //        OnPropertyChanged("SelectedOrder");
        //    }
        //}

        //public ObservableCollection<Order> Orders
        //{
        //    get
        //    {
        //        return this.orders;
        //    }
        //    set
        //    {
        //        orders = value;
        //    }
        //}

        //public ObservableCollection<Order> OrdersOP
        //{
        //    get
        //    {
        //        return this.ordersOP;
        //    }
        //    set
        //    {
        //        ordersOP = value;
        //    }
        //}

        //public ObservableCollection<Order> OrdersRDY
        //{
        //    get
        //    {
        //        return this.ordersRDY;
        //    }
        //    set
        //    {
        //        ordersRDY = value;
        //    }
        //}

        //public ObservableCollection<string> Categorys
        //{
        //    get
        //    {
        //        return categorys;
        //    }
        //}

        //public ObservableCollection<string> Destinations
        //{
        //    get
        //    {
        //        return destinations;
        //    }
        //}

        //public ObservableCollection<int> AvailableTransports
        //{
        //    get
        //    {
        //        return availableTransports;
        //    }
        //    set
        //    {
        //        availableTransports = value;
        //    }
        //}

        //public ObservableCollection<int> PlacesOfDeparture
        //{
        //    get
        //    {
        //        return placesOfDeparture;
        //    }
        //    set
        //    {
        //        placesOfDeparture = value;
        //    }
        //}
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