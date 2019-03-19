using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows;
using System.Text.RegularExpressions;
using Microsoft.Practices.Prism.Commands;

namespace Shipping_Management
{
    class CustomerViewModal : ViewModalBase
    {
        //Customer_details class

        #region Property

        #region Customer Property
        private int customerNo;
        public int CustomerNo
        {
            get { return customerNo; }
            set
            {
                customerNo = value;
                OnPropertyChanged(new PropertyChangedEventArgs("CustomerNo"));
            }
        }
        private string customerName;
        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; OnPropertyChanged(new PropertyChangedEventArgs("CustomerName")); }
        }
        private string zipcode;
        public string Zipcode
        {
            get { return zipcode; }
            set { zipcode = value; OnPropertyChanged(new PropertyChangedEventArgs("Zipcode")); }
        }

        private string city;
        public string City
        {
            get { return city; }
            set { city = value; OnPropertyChanged(new PropertyChangedEventArgs("City")); }
        }
        private string mobileNo;
        public string MobileNo
        {
            get { return mobileNo; }
            set { mobileNo = value; OnPropertyChanged(new PropertyChangedEventArgs("MobileNo")); }
        }
        private string address;
        public string Address
        {
            get { return address; }
            set { address = value; OnPropertyChanged(new PropertyChangedEventArgs("Address")); }

        }

        //private DelegateCommand deleteCommand;
        //private DelegateCommand editCommand;

        //public DelegateCommand DeleteCommand
        //{
        //    get
        //    {
        //        deleteCommand = DeleteCommand ?? new DelegateCommand(DoDelete);
        //        return deleteCommand;
        //    }


        //}
        //public DelegateCommand EditCommand
        //{
        //    get
        //    {
        //        editCommand = EditCommand ?? new DelegateCommand(DoEdit);
        //        return editCommand;
        //    }
        //}
        #region Customer_Details Collections
        private ObservableCollection<Customer_details> customerList;
        public ObservableCollection<Customer_details> CustomerList
        {
            get { return customerList; }
            set { customerList = value; OnPropertyChanged(new PropertyChangedEventArgs("CustomerList")); }
        }
        //  private ObservableCollection<Customer_details> allCustomerList;




        #endregion

        #endregion

        #region Product Property
        private int productNo;
        public int ProductNo
        {
            get { return productNo; }
            set { productNo = value; OnPropertyChanged(new PropertyChangedEventArgs("ProductNo")); }


        }
        private string productName;
        public string ProductName
        {
            get { return productName; }
            set { productName = value; OnPropertyChanged(new PropertyChangedEventArgs("ProductName")); }
        }
        private double height;
        public double Height
        {
            get { return height; }
            set
            {

                height = value; OnPropertyChanged(new PropertyChangedEventArgs("Height"));
            }
        }

        private double weight;
        public double Weight
        {
            get { return weight; }
            set
            {

                weight = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Weight"));
            }
        }

        private double length;
        public double Length
        {
            get { return length; }
            set
            {

                length = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Length"));
            }
        }

        private double sellPrice;
        public double SellPrice
        {
            get { return sellPrice; }
            set
            {
                sellPrice = value; OnPropertyChanged(new PropertyChangedEventArgs("SellPrice"));

            }
        }
        private double buyPrice;
        public double BuyPrice
        {
            get { return buyPrice; }
            set
            {
                buyPrice = value; OnPropertyChanged(new PropertyChangedEventArgs("BuyPrice"));

            }
        }
        private double profit;
        public double Profit
        {
            get { return profit; }
            set
            {
                profit = value;


                OnPropertyChanged(new PropertyChangedEventArgs("Profit"));

            }
        }



        #region Product_Details Collections
        private ObservableCollection<Product_Details> productList;
        public ObservableCollection<Product_Details> ProductList
        {
            get { return productList; }
            set { productList = value; OnPropertyChanged(new PropertyChangedEventArgs("ProductList")); }
        }

        private Product_Details selectedName;

        public Product_Details SelectedName
        {
            get { return selectedName; }
            set
            {
                selectedName = value;
                OnPropertyChanged(new PropertyChangedEventArgs("SelectedName"));

                if (SelectedName != null)
                {
                    Qty = 1;
                    UnitPrice = SelectedName.SellPrice;
                }

            }
        }

        private ObservableCollection<Product_Details> productNameList;
        public ObservableCollection<Product_Details> ProductNameList
        {
            get { return productNameList; }
            set { productNameList = value; OnPropertyChanged(new PropertyChangedEventArgs("ProductNameList")); }
        }

        //for dropdownlist of productname
        private Product_Details selectedProductName;

        public Product_Details SelectedProductName
        {
            get { return selectedProductName; }
            set { selectedProductName = value; OnPropertyChanged(new PropertyChangedEventArgs("SelectedProductName")); }
        }
        #endregion

        #endregion

        #region Order Property
        public ObservableCollection<Product_Details> MainOrderProduct { get; set; }
        private ObservableCollection<Product_Details> orderProduct;

        public ObservableCollection<Product_Details> OrderProduct
        {
            get { return orderProduct; }
            set { orderProduct = value; OnPropertyChanged(new PropertyChangedEventArgs("OrderProduct")); }
        }

        private ObservableCollection<Order_Details> orderList;

        public ObservableCollection<Order_Details> OrderList
        {
            get { return orderList; }
            set { orderList = value; OnPropertyChanged(new PropertyChangedEventArgs("OrderList")); }
        }
        private ObservableCollection<Order_Details> allOrderList;

        private Order_Details selectedOrderList;
        public Order_Details SelectedOrderList
        {
            get { return selectedOrderList; }
            set { selectedOrderList = value; OnPropertyChanged(new PropertyChangedEventArgs("SelectedOrderList")); }
        }
        private Order_Details selectedOrderProductName;

        public Order_Details SelectedOrderProductName
        {
            get { return selectedOrderProductName; }
            set
            {
                selectedOrderProductName = value;
                OnPropertyChanged(new PropertyChangedEventArgs("SelectedOrderProductName"));


            }

        }
        #region for orderId dropdownfill
        private ObservableCollection<Order_Details> order_OrderId;
        public ObservableCollection<Order_Details> Order_OrderId
        {
            get { return order_OrderId; }
            set { order_OrderId = value; OnPropertyChanged(new PropertyChangedEventArgs("Order_OrderId")); }
        }

        private Order_Details selectedOrderId;

        public Order_Details SelectedOrderId
        {
            get { return selectedOrderId; }
            set { selectedOrderId = value; OnPropertyChanged(new PropertyChangedEventArgs("SelectedOrderId")); }
        }
        #endregion
        private int orderId;
        public int OrderId
        {
            get { return orderId; }
            set { orderId = value; OnPropertyChanged(new PropertyChangedEventArgs("OrderId")); }
        }
        private string order_customerName;

        public string Order_CustomerName
        {
            get { return order_customerName; }
            set
            {
                order_customerName = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Order_CustomerName"));

            }
        }
        private int order_customerNo;
        public int Order_CustomerNo
        {
            get { return order_customerNo; }
            set
            {
                order_customerNo = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Order_CustomerNo"));

            }
        }
        private string order_ProductName;

        public string Order_ProductName
        {
            get { return order_ProductName; }
            set
            {
                order_ProductName = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Order_ProductName"));

            }
        }
        private int qty;
        public int Qty
        {
            get { return qty; }
            set
            {
                qty = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Qty"));

                UnitPrice = qty * SelectedName.SellPrice;
            }
        }
        private double unitPrice;
        public double UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; OnPropertyChanged(new PropertyChangedEventArgs("UnitPrice")); }
        }
        private int order_ProductNo;
        public int Order_ProductNo
        {
            get { return order_ProductNo; }
            set { order_ProductNo = value; OnPropertyChanged(new PropertyChangedEventArgs(" Order_ProductNo")); }
        }


        private Shipment_Details shipmentList;

        public Shipment_Details ShipmentList
        {
            get { return shipmentList; }
            set { shipmentList = value; OnPropertyChanged(new PropertyChangedEventArgs("ShipmentList")); }
        }


        #endregion

        #endregion

        #region Constructor
        //constructor
        public CustomerViewModal()
        {

            GetCustomerNumber();
            GetProductNumber();
            if (allOrderList == null)
            {
                allOrderList = new ObservableCollection<Order_Details>();
            }
            GetOrderId();
            this.PropertyChanged += CustomerViewModal_PropertyChanged;
        }

        void CustomerViewModal_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "SelectedOrderList":
                    {
                        if (SelectedOrderList != null)
                        {
                            OrderProduct = new ObservableCollection<Product_Details>(MainOrderProduct.Where(p => p.OrderId == SelectedOrderList.OrderId).ToList());
                        }
                    }
                    break;
            }
            //throw new NotImplementedException();
        }
        #endregion

        #region Methods

        #region Methods FOR savebuttons and addButton
        public void SaveCustomer_Details()
        {
            //we can put validation here
            if (!ValidateCustomer())
            {

                return;
            }
            else
            {
                MessageBox.Show("Customer Detail is added successfully");
            }
            //Add into collection
            Customer_details item = null;
            if (CustomerList != null && CustomerList.Count() > 0)
            {
                item = CustomerList.Where(p => p.CustomerNo == CustomerNo).FirstOrDefault();
            }
            if (CustomerList == null) CustomerList = new ObservableCollection<Customer_details>();
            if (item != null)
            {
                item.CustomerName = this.CustomerName;
                item.Zipcode = this.Zipcode;
                item.City = this.City;
                item.MobileNo = this.MobileNo;
                item.Address = this.Address;
                item.CustomerNo = this.CustomerNo;

                var testCol = CustomerList;
                CustomerList = null;
                CustomerList = testCol;
                CustomerList = CustomerList;
                GetCustomerNumber();

            }

            else
            {
                CustomerList = CustomerList;
                CustomerList.Add(new Customer_details
                         {
                             CustomerName = this.CustomerName,
                             Zipcode = this.Zipcode,
                             City = this.City,

                             Address = this.Address,
                             MobileNo = this.MobileNo,
                             CustomerNo = this.CustomerNo

                         });
                var testCol1 = CustomerList;
                CustomerList = null;
                CustomerList = testCol1;
                GetCustomerNumber();

            }


            // FOR RESET
            ResetControl();

        }
        //reset
        public void ResetControl()
        {
            this.CustomerName = string.Empty;
            this.Zipcode = string.Empty;
            this.City = string.Empty;
            this.Address = string.Empty;
            this.MobileNo = string.Empty;

        }



        public void SaveProduct_Details()
        {
            //we can put validation here
            if (!ValidateProduct())
            {
                return;
            }
            else
            {
                MessageBox.Show("Product Detail is added successfully");
            }
            Product_Details item1 = null;
            if (ProductList != null && ProductList.Count() > 0)
            {
                item1 = ProductList.Where(p => p.ProductNo == ProductNo).FirstOrDefault();
            }
            if (ProductList == null) ProductList = new ObservableCollection<Product_Details>();

            if (item1 != null)
            {
                item1.ProductName = this.ProductName;
                item1.Height = this.Height;
                item1.Weight = this.Weight;
                item1.Length = this.Length;
                item1.SellPrice = this.SellPrice;
                item1.BuyPrice = this.BuyPrice;
                item1.ProductNo = this.ProductNo;
                item1.Profit = item1.SellPrice - item1.BuyPrice;

                var testCol = ProductList;
                ProductList = null;
                ProductList = testCol;
                ProductList = ProductList;
                GetProductNumber();

            }

            else
            {
                ProductList = ProductList;
                ProductList.Add(new Product_Details
                {
                    ProductName = this.ProductName,
                    Height = this.Height,
                    Weight = this.Weight,
                    Length = this.Length,
                    SellPrice = this.SellPrice,
                    BuyPrice = this.BuyPrice,
                    ProductNo = this.ProductNo,
                    Profit = SellPrice - BuyPrice,

                });

                var testCol1 = ProductList;
                ProductList = null;
                ProductList = testCol1;
                GetProductNumber();



            }

            FillDropdown();
            //reset

            this.ProductName = string.Empty;
            this.Height = 0;
            this.Weight = 0;
            this.Length = 0;
            this.SellPrice = 0;
            this.BuyPrice = 0;
        }

        // for add productname,qty,unitprice

        public void Add_ProductDetails()
        {
            if (MainOrderProduct == null)
            {
                MainOrderProduct = new ObservableCollection<Product_Details>();
            }
            if (OrderProduct == null)
            {

                OrderProduct = new ObservableCollection<Product_Details>();
            }
            
            var item = new Product_Details
                {
                    OrderId = this.OrderId,
                    ProductName = SelectedName.ProductName,
                    Quantity = this.Qty,
                    UnitPrice = this.UnitPrice,
                    
                };
            
            OrderProduct.Add(item);

            MainOrderProduct.Add(item);
            var testCol1 = OrderProduct;
            OrderProduct = null;
            OrderProduct = testCol1;
           
            MessageBox.Show("Detail of products with corresponding quantity and price is added");
            this.UnitPrice = 0;
            this.Qty = 0;


        }



        public void SaveOrder_Details()
        {
            if (!ValidateOrder())
            {
                return;
            }

            if (OrderList == null)
            {
                OrderList = new ObservableCollection<Order_Details>();
            }

        
            var item = CustomerList.Where(p => p.CustomerName.ToLower() == Order_CustomerName.ToLower()).FirstOrDefault();


            Order_Details item2 = null;
            if (OrderList != null && OrderList.Count() > 0)
            {
                item2 = OrderList.Where(p => p.OrderId == OrderId).FirstOrDefault();
            }
            if (OrderList == null) OrderList = new ObservableCollection<Order_Details>();

            if (item2 != null)
            {
                item2.Order_CustomerNo = this.Order_CustomerNo;
                item2.Order_CustomerName = this.Order_CustomerName;
                item2.OrderId = this.OrderId;
                //  item2.Order_ProductName = this.SelectedName.ProductName;
                // item2.Qty = this.Qty;
                // item2.UnitPrice = this.UnitPrice;
                // item2.Order_ProductNo = this.SelectedName.ProductNo;
                var testCol = OrderList;
                OrderList = null;
                OrderList = testCol;
                OrderList = OrderList;
                GetOrderId();

            }
            else
            {
                OrderList.Add(new Order_Details
                {
                    Order_CustomerName = this.Order_CustomerName,
                    //  Qty = this.Qty,
                    // UnitPrice = this.UnitPrice,
                    OrderId = this.OrderId,
                    // Order_ProductNo = SelectedName.ProductNo,
                    Order_CustomerNo = item.CustomerNo,
                    // Order_ProductName = SelectedName.ProductName
                });

                var testCol = OrderList;
                OrderList = null;
                OrderList = testCol;

                GetOrderId();


            }



            FillDropdownOrderId();



            //reset
            this.Order_CustomerName = string.Empty;
            this.Order_CustomerNo = 0;
            this.Qty = 0;
            this.UnitPrice = 0;

            //SelectedOrderList = OrderList.FirstOrDefault();
            OrderProduct = new ObservableCollection<Product_Details>();

        }

        public void Shipment_Info()
        {

            ShipmentList = new Shipment_Details();

            //var item = from r in CustomerList
            //           from s in ProductList
            //           from t in OrderList
            //           where ((r.CustomerNo.ToString() == t.Order_CustomerNo.ToString()) && (s.ProductNo.ToString() == t.Order_ProductNo.ToString()) && (t.OrderId.ToString() == SelectedOrderId.OrderId.ToString()))
            //           select t;
            //var item1 = from p in CustomerList
            //            from m in OrderList
            //            where p.CustomerNo == m.Order_CustomerNo && m.OrderId == SelectedOrderId.OrderId
            //            select new { p.CustomerNo, p.CustomerName, p.Address, p.City, p.MobileNo };
            //var item2 = from n in ProductList
            //            from o in OrderList
            //            where n.ProductNo == o.Order_ProductNo && o.OrderId == SelectedOrderId.OrderId
            //            select new { o.Order_ProductNo, o.Qty, o.UnitPrice };
           
            var item = OrderList.Where(p => p.OrderId == SelectedOrderId.OrderId).FirstOrDefault();
           // var item1 = ProductList.Where(p => p.ProductNo == item.Order_ProductNo).FirstOrDefault();
            var item2 = CustomerList.Where(p => p.CustomerNo == item.Order_CustomerNo).FirstOrDefault();

            ShipmentList.print_products = MainOrderProduct.Where(p => p.OrderId == SelectedOrderId.OrderId).ToList();
          //  var totalamnt = from p in OrderProduct group p by p.UnitPrice into g select new { totalamount = g.Sum(p => p.UnitPrice) };
            var item5 = MainOrderProduct.Where(p => p.OrderId == SelectedOrderId.OrderId).Sum(p => p.UnitPrice);
            if (item != null && item2 != null)
            {
                ShipmentList.OrderId = item.OrderId;
                ShipmentList.CustomerName = item.Order_CustomerName;
                ShipmentList.CustomerNo = item.Order_CustomerNo;
                ShipmentList.Address = item2.Address;
                ShipmentList.City = item2.City;
                ShipmentList.MobileNo = item2.MobileNo;
                ShipmentList.TotalAmount = item5;
                //ShipmentList.ProductName = item.Order_ProductName;
                //ShipmentList.Qty = item.Qty;
                //ShipmentList.UnitPrice = item.UnitPrice;                
            }
        }
        #endregion

        #region  Methods for Validation
        private bool ValidateCustomer()
        {

            if (string.IsNullOrEmpty(this.CustomerName) || string.IsNullOrEmpty(this.Zipcode) || string.IsNullOrEmpty(this.City) || string.IsNullOrEmpty(this.Address))
            {
                MessageBox.Show("fill required values");

                return false;
            }
            else if (!Regex.Match(this.CustomerName, "^[a-zA-Z][a-zA-Z]*$").Success)
            {
                MessageBox.Show("Invalid customer name \n First letter should be in capital letter and can't have number", "Message", MessageBoxButton.OK, MessageBoxImage.Error);

                return false;
            }
            else if (!Regex.Match(this.Zipcode, "^[0-9]*$").Success)
            {
                MessageBox.Show("Invalid Zipcode", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (!Regex.Match(this.MobileNo, "^[0-9]*$").Success)
            {
                MessageBox.Show("Invalid Mobile No", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (!Regex.Match(this.City, @"^([a-zA-Z]+|[a-zA-Z]+\s[a-zA-Z]+)$").Success)
            {

                MessageBox.Show("Invalid city", "Message", MessageBoxButton.OK, MessageBoxImage.Error);

                return false;
            }


            else
            {
                if (CustomerList == null) return true;

                //var item = CustomerList.Where(p => p.CustomerName.ToLower() == CustomerName.ToLower()).FirstOrDefault();
                //if (item != null)
                //{
                //    MessageBox.Show("Customer Details Already exists in the list");
                //    return false;
                //}
            }


            return true;
        }



        private bool ValidateProduct()
        {
            if (string.IsNullOrEmpty(this.ProductName))
            {
                MessageBox.Show("Fill required values");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(ProductName))
            {
                MessageBox.Show("white spaces not allowed");
                return false;
            }

            else if (ProductList != null && ProductList.Count > 0)
            {
                //if (ProductList.Any(s => s.ProductName.ToLower() == this.ProductName.ToLower()))
                //{
                //    show error
                //    MessageBox.Show("Detail regarding product already exist in the list");
                //    return false;
                //}
            }
            else
            {
                if (ProductList == null) return true;
                var item1 = ProductList.Where(q => q.ProductName.ToLower() == SelectedName.ProductName.ToLower()).FirstOrDefault();
                if (item1 != null)
                {
                    MessageBox.Show("Product name didn't match");
                    return false;
                }
            }

            return true;
        }
        private bool ValidateOrder()
        {
            if (string.IsNullOrEmpty(this.Order_CustomerName))
            {
                MessageBox.Show("Provide Customer Name");
                return false;
            }

            else
            {
                var item = CustomerList.Where(p => p.CustomerName.ToLower() == Order_CustomerName.ToLower());
                if (item == null)
                {
                    MessageBox.Show("customer name didn't match");
                    return false;
                }
                if (SelectedName == null || string.IsNullOrEmpty(SelectedName.ProductName))
                {

                    return false;
                }

            }
            return true;



        }

        #endregion




        #region METHODS for CustomerNo,ProductNo,OrderId
        private void GetCustomerNumber()
        {
            int startNumber = 10245;

            if (CustomerList != null && CustomerList.Count > 0)
            {
                CustomerNo = startNumber + CustomerList.Count;
            }
            else
            {
                CustomerNo = startNumber;
            }
        }
        private void GetProductNumber()
        {
            int pno = 1;
            if (ProductList != null && ProductList.Count > 0)
            {
                ProductNo = pno + ProductList.Count;
            }
            else
            {
                ProductNo = pno;
            }

        }
        private void GetOrderId()
        {
            int orderId = 1;
            if (OrderList != null && OrderList.Count > 0)
            {
                OrderId = orderId + OrderList.Count;
            }
            else
            {
                OrderId = orderId;
            }
        }
        #endregion
        #region METHODS for Dropdownfill
        private void FillDropdown()
        {
            if (ProductNameList == null)
            {
                ProductNameList = new ObservableCollection<Product_Details>();
            }
            ProductNameList = new ObservableCollection<Product_Details>(ProductList);
            SelectedProductName = ProductNameList.FirstOrDefault();
        }
        private void FillDropdownOrderId()
        {
            if (Order_OrderId == null)
            {
                Order_OrderId = new ObservableCollection<Order_Details>();
            }
            Order_OrderId = new ObservableCollection<Order_Details>(OrderList);
            SelectedOrderId = Order_OrderId.FirstOrDefault();
        }

        #endregion

        #region edit ande methods for different gridview
        public void Editcustomerlist(int customerNo)
        {

            var item = CustomerList.Where(p => p.CustomerNo == customerNo).FirstOrDefault();
            if (item != null)
            {


                CustomerNo = item.CustomerNo;
                CustomerName = item.CustomerName;
                Address = item.Address;
                Zipcode = item.Zipcode;
                City = item.City;
                MobileNo = item.MobileNo;


            }
            else if (item.CustomerNo == customerNo)
            {

                item.CustomerNo = customerNo;
                item.CustomerName = CustomerName;
                item.Address = Address;
                item.Zipcode = Zipcode;
                item.City = City;
                item.MobileNo = MobileNo;
                CustomerList = CustomerList;




            }


        }

        public void Deletecustomerlist(int customerNo)
        {

            var item = CustomerList.Where(p => p.CustomerNo == customerNo).FirstOrDefault();
            if (item != null)
            {
                CustomerList.Remove(item);
                CustomerList = CustomerList;
                OnPropertyChanged(new PropertyChangedEventArgs("CustomerList"));

            }

        }

        public void Editproductlist(int productNo)
        {

            var item1 = ProductList.Where(p => p.ProductNo == productNo).FirstOrDefault();
            if (item1 != null)
            {


                ProductName = item1.ProductName;
                Height = item1.Height;
                Weight = item1.Weight;
                Length = item1.Length;
                SellPrice = item1.SellPrice;
                BuyPrice = item1.BuyPrice;
                ProductNo = item1.ProductNo;
                Profit = item1.SellPrice - item1.BuyPrice;

            }
            else if (item1.ProductNo == productNo)
            {


                item1.ProductName = ProductName;
                item1.Height = Height;
                item1.Weight = Weight;
                item1.Length = Length;
                item1.SellPrice = SellPrice;
                item1.BuyPrice = BuyPrice;
                item1.ProductNo = ProductNo;
                Profit = item1.SellPrice - item1.BuyPrice;
                ProductList = ProductList;

            }


        }
        public void Deleteproductlist(int productNo)
        {

            var item1 = ProductList.Where(p => p.ProductNo == productNo).FirstOrDefault();
            if (item1 != null)
            {

                ProductList.Remove(item1);
                ProductList = ProductList;
                OnPropertyChanged(new PropertyChangedEventArgs("ProductList"));
                FillDropdown();
            }


        }


        public void Editorderlist(int orderId)
        {
            var item = CustomerList.Where(p => p.CustomerNo == customerNo).FirstOrDefault();
            var item2 = OrderList.Where(p => p.OrderId == orderId).FirstOrDefault();
            if (item2 != null)
            {
                OrderId = item2.OrderId;
                Order_CustomerName = item2.Order_CustomerName;
                // Qty = item2.Qty;
                // UnitPrice = item2.UnitPrice;
                OrderId = item2.OrderId;
                Order_CustomerNo = item2.Order_CustomerNo;
                //Order_ProductName = SelectedName.ProductName;


            }

            else if (item2.OrderId == OrderId)
            {


                item2.OrderId = OrderId;
                item2.Order_CustomerName = Order_CustomerName;
                // item2.Qty = Qty;
                // item2.UnitPrice = UnitPrice;
                item2.Order_CustomerNo = Order_CustomerNo;
                OrderList = OrderList;


            }


        }

        public void Deleteorderlist(int orderId)
        {

            var item2 = OrderList.Where(p => p.OrderId == orderId).FirstOrDefault();
            if (item2 != null)
            {

                OrderList.Remove(item2);
                OrderList = OrderList;
                OnPropertyChanged(new PropertyChangedEventArgs("OrderList"));
                FillDropdownOrderId();

            }


        }

        //public void Editproductaddlist(string productName)
        //{

        //    var item3 = OrderProduct.Where(p => p.ProductName == productName).FirstOrDefault();
        //    if (item3 != null)
        //    {
        //        ProductName = item3.ProductName;
        //        Qty = item3.Quantity;
        //        UnitPrice = item3.UnitPrice;


        //    }}










        public void Deleteproductaddlist(string productName)
        {
            var item3 = OrderProduct.Where(p => p.ProductName == productName).FirstOrDefault();
            if (item3 != null)
            {
                OrderProduct.Remove(item3);
                OrderProduct = OrderProduct;
                OnPropertyChanged(new PropertyChangedEventArgs("OrderProduct"));


            }


        }

        #endregion







        #endregion




    }

    #region Customer_Details,Product_Details,Order_Detils class
    public class Customer_details
    {
        public int CustomerNo { get; set; }
        public string CustomerName { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
    }
    //Product_Details class
    public class Product_Details
    {
        public int OrderId { get; set; }
        public int ProductNo { get; set; }
        public string ProductName { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public double Length { get; set; }
        public double SellPrice { get; set; }
        public double BuyPrice { get; set; }
        public double Profit { get; set; }
        //only use for order detail product grid
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double TotalAmount { get; set; }
    }
    public class Order_Details
    {
        public int OrderId { get; set; }
        public string Order_CustomerName { get; set; }
        public int Order_CustomerNo { get; set; }
        public string Order_ProductName { get; set; }
        public int Qty { get; set; }
        public int Order_ProductNo { get; set; }
        public double UnitPrice { set; get; }
    }
    public class Shipment_Details
    {
        public int CustomerNo { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int OrderId { get; set; }
        public string MobileNo { get; set; }
        public string ProductName { get; set; }
        public int Qty { get; set; }
        public double UnitPrice { set; get; }
        public double TotalAmount { set; get; }
        public List<Product_Details> print_products { get; set; }
    }
    #endregion
}
