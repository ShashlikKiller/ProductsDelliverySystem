using System.Windows;

namespace ProductsDelliverySystem
{
    public partial class WindowReadyOrders : Window
    {
        public WindowReadyOrders()
        {
            InitializeComponent();
            Title = "Список готовых к отправке заказов:";
        }

        private void buttonLoad_Click(object sender, RoutedEventArgs e)
        {
            buttonLoad.Visibility = Visibility.Hidden;
        }
    }
}