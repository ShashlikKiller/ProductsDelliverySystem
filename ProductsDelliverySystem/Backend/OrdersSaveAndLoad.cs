using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
//using System.Text.Json - ДИРЕКТИВЫ НЕТУ, поэтому сохранение через xml

namespace ProductsDelliverySystem
{
    class OrdersSaveAndLoad : INotifyPropertyChanged
    {
        #region Сохранение экземпляра листа в файл
        /// <summary>
        /// Сохранение ОДНОГО экземпляра листа в файл
        /// </summary>
        /// <typeparam name="T"> Класс из которого состоит коллекция </typeparam>
        /// <param name="FileName"> Название файла в который будет сохранятся </param>
        /// <param name="SerializableObject"> Нужная коллекция из которой будет браться экземпляр </param>
        public static void SaveCurrentOrderToFile<T>(string FileName, T SerializableObject)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextWriter textWriter = new StreamWriter(FileName))
            {
                serializer.Serialize(textWriter, SerializableObject);
            }
        }
        #endregion

        #region Загрузка элемента листа из файла
        /// <summary>
        /// Загрузка одного элемента коллекции из файла
        /// </summary>
        /// <typeparam name="T"> Название класса объекта </typeparam>
        /// <param name="FileName"> Название файла </param>
        /// <returns></returns>
        public static T LoadFromXml<T>(string FileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextReader textReader = new StreamReader(FileName))
            {
                return (T)serializer.Deserialize(textReader);
            }
        }
        #endregion

        #region Сохранение листа в файл (полностью)

        /// <summary>
        /// Полное сохранение листа в файл (перезапись, если файл не пуст!)
        /// </summary>
        /// <typeparam name="T"> Класс объекта </typeparam>
        /// <param name="FileName"> Название файла, в который будет сохранятся объект </param>
        /// <param name="SerializableObjects"> Название объекта, который сохранится в файл </param>
        public static void SaveCollectionToFile<T>(String FileName, ObservableCollection<T> SerializableObjects) // => json
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<T>));
            using (TextWriter textWriter = new StreamWriter(FileName))
            {
                serializer.Serialize(textWriter, SerializableObjects);
            }
        }
        #endregion

        #region Загрузка листа из файла (полностью)
        /// <summary>
        /// Загрузка листа из файла (полностью)
        /// </summary>
        /// <typeparam name="T"> Класс, из которого состоит ObservableCollection </typeparam>
        /// <param name="FileName"> Название файла, из которого будет происходить загрузка </param>
        /// <returns> </returns>
        public static ObservableCollection<T> LoadCollectionFromFile<T>(string FileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<T>));
            using (TextReader textReader = new StreamReader(FileName))
            {
                return (ObservableCollection<T>)serializer.Deserialize(textReader);
            }
        }
        #endregion

        /// <summary>
        /// Когда товары отправляются, то оформляются документы:
        /// 1. доверенность на представителя грузополучателя(покупателя);
        /// 2. товарный чек;
        /// 3. путевой лист.
        /// </summary>
        /// <param name="FileName"> Название файла, в который сохранятся документы </param>
        /// <param name="SelectedOrder"> Выбранный заказ, для которого нужны документы </param>
        public static void MakeChecksForOrder(string FileName, Order SelectedOrder, int checkNumber)
        {
            //System.IO.File.AppendAllText(path, text); - ANALOG
            if (SelectedOrder != null) // Проверка на существование выбранного заказа
            {
                using (StreamWriter file = new StreamWriter(FileName))
                {
                    file.Write("Доверенность на представителя бла бла бла ФИО оператора; " + "\n");
                    file.Write("Товарный чек №" + checkNumber + "\n" +
                    "Цена = " + SelectedOrder.Price + "\n" +
                    "Номер заказа = " + SelectedOrder.OrderNumber + "\n" +
                    "Место назначения = " + SelectedOrder.OrderDestination.Name + "\n" +
                    "Место отправления = " + SelectedOrder.OrderPlaceOfDeparture.Name + "\n" +
                    "Категория товара: " + SelectedOrder.OrderCategory.Name + "\n" +
                    "Вид транспорта: " + SelectedOrder.OrderTransport.Name);
                    file.Close(); // Закрытие файла (сохранение)
                }
            }
        }

        #region Альтернативные методы сериализации
        /// <summary>
        /// Сохранение заказов в файл
        /// </summary>
        //public static void Serialize(string pathOrFileName, object objToSerialise)
        //{
        //    using (Stream stream = File.Open(pathOrFileName, FileMode.Create))
        //    {
        //        try
        //        {
        //            _bin.Serialize(stream, objToSerialise);
        //        }
        //        catch (SerializationException e)
        //        {
        //            Console.WriteLine("Failed to serialize. Reason: " + e.Message);
        //            throw;
        //        }
        //    }
        //}


        // <param name = "orders" > Название коллекции заказов</param>
        // <param name = "file" > Название потенциального файла для сохранения </param>
        //public static void Serialize(ObservableCollection<Order> orders, string file)
        //{
        //    XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<Order>));
        //    string xml;
        //    using (StringWriter stringWriter = new StringWriter())
        //    {
        //        xmlSerializer.Serialize(stringWriter, orders);
        //        xml = stringWriter.ToString();
        //    }
        //    File.WriteAllText(file, xml, Encoding.Default);
        //}


        /// <summary>
        /// Открытие заказов из файла
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pathOrFileName"></param>
        /// <returns></returns>
        //public static T Deserialize<T>(string pathOrFileName)
        //{
        //    T items;

        //    using (Stream stream = File.Open(pathOrFileName, FileMode.Open))
        //    {
        //        try
        //        {
        //            items = (T)_bin.Deserialize(stream);
        //        }
        //        catch (SerializationException e)
        //        {
        //            Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
        //            throw;
        //        }
        //    }
        //    return items;
        //}

        /// <summary>
        /// Открытие списка заказов из файла
        /// </summary>
        /// <param name="file"> Название файла, из которого будет происходить загрузка </param>
        /// <returns></returns>
        //public static ObservableCollection<Order> Deserialize(string file)
        //{
        //    XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<Order>));
        //    ObservableCollection<Order> orders;
        //    using (StreamReader sr = new StreamReader(file))
        //    {
        //        orders = (ObservableCollection<Order>)xmlSerializer.Deserialize(sr);
        //    }
        //    return orders;
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