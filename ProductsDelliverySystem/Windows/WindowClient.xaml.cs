using System.Windows;

namespace ProductsDelliverySystem
{
    public partial class WindowClient : Window
    {
        public WindowClient()
        {
            InitializeComponent();
            Title = "Клиентская часть";
        }
        private void OpenReadyOrdersWindow(object sender, RoutedEventArgs e)
        {
            WindowReadyOrders WindowReadyOrders = new WindowReadyOrders();
            WindowReadyOrders.DataContext = new WindowReadyOrdersViewModel();
            WindowReadyOrders.Show();
            WindowReadyOrders.Owner = this; // При закрытии меню закрываются остальные окна
            WindowReadyOrders.Background = Background;
        }
    }
}