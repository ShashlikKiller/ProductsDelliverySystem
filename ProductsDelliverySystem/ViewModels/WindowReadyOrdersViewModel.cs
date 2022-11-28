using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using static ProductsDelliverySystem.OrdersSaveAndLoad;

namespace ProductsDelliverySystem
{
    class WindowReadyOrdersViewModel : INotifyPropertyChanged
    {
        #region Переменные и коллекции
        private Order selectedOrder; // Выбранный заказ
        private ObservableCollection<Order> orders = new ObservableCollection<Order>(); // Список заказов
        private int checkNumber = 1; // Переменная номера чека
        #endregion

        #region Команды

        private Command loadReadyOrders; // загрузить заказы готовые к отправке

        public Command LoadReadyOrders
        {
            get
            {
                return loadReadyOrders ?? (loadReadyOrders = new Command(obj =>
                {
                    Orders = LoadCollectionFromFile<Order>("ReadyOrdersList.json"); // Загрузка из xml файла
                    OnPropertyChanged("Orders"); // Уведомление об изменении листа (при полной замене нет уведомлений)
                }));
            }
        }

        private Command makeChecks;
        public Command MakeChecks
        {
            get
            {
                return makeChecks ?? (makeChecks = new Command(obj =>
                {
                    if (SelectedOrder != null)
                    {
                        MakeChecksForOrder("CheckList.txt", SelectedOrder, checkNumber);
                        SaveCurrentOrderToFile("OrderForCheck.json", SelectedOrder);
                        Orders.RemoveAt(Orders.IndexOf(SelectedOrder));
                        checkNumber++;
                        MessageBox.Show("Все документы были сохранены в файл: CheckList.txt");
                    }
                    else MessageBox.Show("Выберите заказ, для которого хотите получить выписку.");
                }));
            }
        }

        #endregion

        #region Getters And Setters

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
