using System.Windows;

namespace ProductsDelliverySystem
{
    /// <summary>
    /// Логика взаимодействия для WindowOperator.xaml
    /// </summary>
    public partial class WindowOperator : Window
    {
        public WindowOperator()
        {
            InitializeComponent();
            Title = "Операторская часть";
        }

        private void ButtonRefreshOrders_Click_1(object sender, RoutedEventArgs e)
        {
            ButtonRefreshOrders.Visibility = Visibility.Hidden;
        }
    }
}
