using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace ProductsDelliverySystem
{
    // Вариант 2
    // Информационная система для доставки товаров.
    // Пользователи размещают заказы в информационной системе. +
    // Далее товары комплектуются и получают статус готовы. +
    // Далее заказы собираются и загружаются на грузовики и доставляются в город назначения. +
    // При этом у каждого грузовика есть фиксированный маршрут, проходящий через разные города назначения.
    // Когда товары отправляются, то оформляются документы: +
    // 1. доверенность на представителя грузополучателя (покупателя); +
    // 2. товарный чек; +
    // 3. путевой лист. +
    // Стоимость формируется одной формуле (на усмотрение студента),
    // которая зависит от расстояния и веса доставки.
    // Например, цена = расстояние/100 в рублях * массу заказа.

    // Разработать прототип такой информационной системы и обеспечить ее возможностью легкого расширения. +
    // Добавить более 2х транспортных средств для доставки товаров. +
    // Например, для доставки товаром самолетом, нельзя перевозить определенные категории товаров.
    // Допустим, есть три категории и можно перевозить только 1,2. +
    // Предусмотреть интерфейс для оператора комплектующего заказы +
    // и отправляющего их определенным транспортом. +
    // Товар имеет соотношение 1 к 1 с категорией, то есть товар не может быть в двух категориях одновременно. +
    // Предусмотреть сохранение заказа в файл. +

    public partial class MainWindow : Window
    {
        public MainWindow() // decorator / strategy // фассат / одиночка
        {
            InitializeComponent();
            Title = "Меню";
            PasswordBox.Password = "12345678"; // Введение пароля (чтобы не вводить вручную для отладки)
            Background = new SolidColorBrush(Colors.MediumPurple);
        }
        private int? password = 12345678; // Пароль
        int? text; // некая переменная, в которую будет передаваться введеный текст

        #region Взаимодействие с PasswordBox
        private void TextBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (!Char.IsDigit((char)KeyInterop.VirtualKeyFromKey(e.Key)) & e.Key != Key.Back | e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Password != "")
            {
                text = Convert.ToInt32(PasswordBox.Password);
                ButtonStartAsOP.IsEnabled = text == password;
                if (text >= 100000000)
                {
                    MessageBox.Show("Пароль слишком длинный");
                    PasswordBox.Password = "";
                }
            }
        }

        #endregion

        #region Открытие окон

        private void startAsClient(object sender, RoutedEventArgs e)
        {
            WindowClient WindowClient = new WindowClient();
            WindowClient.DataContext = new ClientViewModel();
            WindowClient.Show();
            WindowClient.Owner = this; // При закрытии меню закрываются остальные окна
            WindowClient.Background = this.Background;
        }

        private void startAsOperator(object sender, RoutedEventArgs e)
        {
            WindowOperator WindowOperator = new WindowOperator();
            WindowOperator.DataContext = new OperatorViewModel();
            WindowOperator.Show();
            WindowOperator.Owner = this;
            WindowOperator.Background = this.Background;
        }
        #endregion

        #region Темы приложения(цвет)
        private void Theme_Blue(object sender, RoutedEventArgs e)
        {
            this.Background = new SolidColorBrush(Colors.Blue);
        }
        private void Theme_Pink(object sender, RoutedEventArgs e)
        {
            ImageBrush myBrush = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "https://sun9-79.userapi.com/impg/w5QJSV3Llx1EErK5kA9b53PT6e77N10bf9NqXg/dg4j7KGwL9o.jpg?size=604x565&quality=96&sign=baa5f93119d6c6459d8dc36b3329be5c&type=album"))
            };
            this.Background = myBrush;
            // this.Background = new SolidColorBrush(Colors.Pink);
        }
        private void Theme_Default(object sender, RoutedEventArgs e)
        {
            this.Background = new SolidColorBrush(Colors.White);
        }
        #endregion
    }
}