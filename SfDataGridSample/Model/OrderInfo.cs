using System.ComponentModel;

namespace SfDataGridSample.Model
{
    public class OrderInfo : INotifyPropertyChanged
    {
        private string? orderID;
        private string? customerID;
        private string? customer;
        private string? shipCity;
        private string? shipCountry;

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public string? OrderID
        {
            get { return orderID; }
            set
            {
                if (orderID != value)
                {
                    orderID = value;
                    OnPropertyChanged(nameof(OrderID));
                }
            }
        }

        public string? CustomerID
        {
            get { return customerID; }
            set
            {
                if (customerID != value)
                {
                    customerID = value;
                    OnPropertyChanged(nameof(CustomerID));
                }
            }
        }

        public string? ShipCountry
        {
            get { return shipCountry; }
            set
            {
                if (shipCountry != value)
                {
                    shipCountry = value;
                    OnPropertyChanged(nameof(ShipCountry));
                }
            }
        }

        public string? Customer
        {
            get { return customer; }
            set
            {
                if (customer != value)
                {
                    customer = value;
                    OnPropertyChanged(nameof(Customer));
                }
            }
        }

        public string? ShipCity
        {
            get { return shipCity; }
            set
            {
                if (shipCity != value)
                {
                    shipCity = value;
                    OnPropertyChanged(nameof(ShipCity));
                }
            }
        }

        public OrderInfo(string orderId, string customerId, string country, string customer, string shipCity)
        {
            this.OrderID = orderId;
            this.CustomerID = customerId;
            this.Customer = customer;
            this.ShipCountry = country;
            this.ShipCity = shipCity;
        }
    }
}
