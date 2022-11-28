using ProductsDelliverySystem.Backend.OrderComponents;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProductsDelliverySystem
{
    [Serializable]
    public class Order : INotifyPropertyChanged
    {
        private OrderComponent orderCategory;
        private OrderComponent orderDestination;
        private OrderComponent orderTransport;
        private OrderComponent orderPlaceOfDeparture;
        private bool readytosend;
        private int orderNumber;
        private int? price;

        public Order()
        {
            // Заглушка для Serialize
        }

        /// <summary>
        /// Конструктор заказа со всеми переменными
        /// </summary>
        /// <param name="category"> Категория товара </param>
        /// <param name="destination"> Место назначения </param>
        /// <param name="transportSelection"> Выбранный транспорт для доставки </param>
        /// <param name="orderNumber"> Номер </param>
        /// <param name="readytosend"> Готовность (да/нет) </param>
        /// <param name="price"> Стоимость </param>
        public Order(OrderComponent orderCategory, OrderComponent orderDestination, OrderComponent orderTransport, int orderNumber, bool readytosend = false, int? price = null, OrderComponent orderPlaceOfDeparture = null)
        {
            this.orderCategory = orderCategory;
            this.readytosend = readytosend;
            this.orderDestination = orderDestination;
            this.orderTransport = orderTransport;
            this.orderNumber = orderNumber;
            this.price = price;
            this.orderPlaceOfDeparture = orderPlaceOfDeparture;
        }

        #region Getters and Setters

        public OrderComponent OrderPlaceOfDeparture
        {
            get
            {
                return orderPlaceOfDeparture;
            }
            set
            {
                orderPlaceOfDeparture = value;
            }
        }

        public int? Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }

        public int OrderNumber
        {
            get
            {
                return orderNumber;
            }
            set
            {
                orderNumber = value;
            }
        }

        public bool ReadyToSend
        {
            get
            {
                return this.readytosend;
            }
            set
            {
                this.readytosend = value;
                //OnPropertyChanged("ReadyToSend");
            }
        }

        public OrderComponent OrderCategory { get => orderCategory; set => orderCategory = value; }
        public OrderComponent OrderDestination { get => orderDestination; set => orderDestination = value; }
        public OrderComponent OrderTransport { get => orderTransport; set => orderTransport = value; }
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
