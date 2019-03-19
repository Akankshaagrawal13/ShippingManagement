using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

using Microsoft.Win32;
using System.Drawing;

using System.IO;
using ZXing;
using BarcodeReader = ZXing.Presentation.BarcodeReader;
using BarcodeWriter = ZXing.Presentation.BarcodeWriter;
using BarcodeWriterGeometry = ZXing.Presentation.BarcodeWriterGeometry;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;

using System.Threading;


namespace Shipping_Management
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new CustomerViewModal();






        }
        #region save and add btn_click

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ((this.DataContext) as CustomerViewModal).SaveCustomer_Details();

        }



        private void PRODUCT_BTNSAVE_CLICK(object sender, RoutedEventArgs e)
        {
            ((this.DataContext) as CustomerViewModal).SaveProduct_Details();

        }



        private void Add_ProductDetails(object sender, RoutedEventArgs e)
        {
            ((this.DataContext) as CustomerViewModal).Add_ProductDetails();
        }

        private void Save_Order_Details(object sender, RoutedEventArgs e)
        {
            ((this.DataContext) as CustomerViewModal).SaveOrder_Details();
        }
        #endregion
        #region commented region
        //private void OnKeyDownHandler(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == Key.Return)
        //    {
        //        var viewModel = ((this.DataContext) as CustomerViewModal);
        //        if (viewModel != null)
        //        {
        //            var item = viewModel.CustomerList.Where(p => p.CustomerName.ToLower() == viewModel.Order_CustomerName.ToLower()).FirstOrDefault();
        //            if (item != null)
        //            {


        //                viewModel.Order_CustomerNo = item.CustomerNo;
        //            }
        //        }


        //    }
        //}
        //private void Save_Order_Details(object sender, CancelEventArgs e)
        //{

        //    var viewModel = ((this.DataContext) as CustomerViewModal);
        //    if (viewModel != null)
        //    {
        //        var item = viewModel.CustomerList.Where(p => p.CustomerName.ToLower() == viewModel.Order_CustomerName.ToLower()).FirstOrDefault();
        //        if (item != null)
        //        {


        //            viewModel.Order_CustomerNo = item.CustomerNo;
        //        }
        //    }


        //}

        #endregion
        #region lost_focus event for customerno generation
        private void TextBox_LostFocus_1(object sender, RoutedEventArgs e)
        {
            var viewModel = ((this.DataContext) as CustomerViewModal);
            if (viewModel != null && !string.IsNullOrEmpty(viewModel.Order_CustomerName))
            {
                var item = viewModel.CustomerList.Where(p => p.CustomerName.ToLower() == viewModel.Order_CustomerName.ToLower()).FirstOrDefault();
                if (item != null)
                {
                    viewModel.Order_CustomerNo = item.CustomerNo;
                }
                else
                {
                    viewModel.Order_CustomerNo = 0;
                }
            }
            else
            {
                viewModel.Order_CustomerNo = 0;
            }

        }
        #endregion



        #region edit and delete methods
        private void edit_btn_Click1(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            var customerNo = (int)btn.Tag;

            var viewModel = ((this.DataContext) as CustomerViewModal);
            if (viewModel != null)
            {
                var item = viewModel.CustomerList.Where(p => p.CustomerNo == customerNo).FirstOrDefault();
                if (item != null)
                {


                    viewModel.Order_CustomerNo = item.CustomerNo;
                    viewModel.Editcustomerlist(item.CustomerNo);
                }
                else if (item.CustomerNo == customerNo)
                {
                    item.CustomerNo = viewModel.Order_CustomerNo;
                    viewModel.Editcustomerlist(item.CustomerNo);


                }
            }



        }

        private void delete_btn_Click_1(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            var customerNo = (int)btn.Tag;

            var viewModel = ((this.DataContext) as CustomerViewModal);
            if (viewModel != null)
            {
                var item = viewModel.CustomerList.Where(p => p.CustomerNo == customerNo).FirstOrDefault();
                if (item != null)
                {



                    viewModel.Deletecustomerlist(item.CustomerNo);
                }
            }


        }

        private void EditProduct_btn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            var productNo = (int)btn.Tag;

            var viewModel = ((this.DataContext) as CustomerViewModal);
            if (viewModel != null)
            {
                var item1 = viewModel.ProductList.Where(p => p.ProductNo == productNo).FirstOrDefault();
                if (item1 != null)
                {


                    viewModel.Order_ProductName = item1.ProductName;
                    viewModel.Editproductlist(item1.ProductNo);
                }
            }
        }

        private void Del_Product_btn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            var productNo = (int)btn.Tag;

            var viewModel = ((this.DataContext) as CustomerViewModal);
            if (viewModel != null)
            {
                var item1 = viewModel.ProductList.Where(p => p.ProductNo == productNo).FirstOrDefault();
                if (item1 != null)
                {



                    viewModel.Deleteproductlist(item1.ProductNo);
                }
            }

        }




        private void Edit_Order_btn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            var orderId = (int)btn.Tag;

            var viewModel = ((this.DataContext) as CustomerViewModal);
            if (viewModel != null)
            {
                var item2 = viewModel.OrderList.Where(p => p.OrderId == orderId).FirstOrDefault();
                if (item2 != null)
                {


                    viewModel.OrderId = item2.OrderId;
                    viewModel.Editorderlist(item2.OrderId);
                }
            }
        }

        private void Del_Order_btn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            var orderId = (int)btn.Tag;

            var viewModel = ((this.DataContext) as CustomerViewModal);
            if (viewModel != null)
            {
                var item2 = viewModel.OrderList.Where(p => p.OrderId == orderId).FirstOrDefault();
                if (item2 != null)
                {



                    viewModel.Deleteorderlist(item2.OrderId);
                }
            }
        }



        //private void Edit_productadd_btn_Click(object sender, RoutedEventArgs e)
        //{
        //    Button btn = sender as Button;
        //    var productName = (string) btn.Tag;

        //    var viewModel = ((this.DataContext) as CustomerViewModal);
        //    if (viewModel != null)
        //    {
        //        var item3 = viewModel.OrderProduct.Where(p => p.ProductName.ToLower() == productName.ToLower()).FirstOrDefault();
        //        if (item3 != null)
        //        {


        //            viewModel.ProductName = item3.ProductName;
        //            viewModel.Editproductaddlist(item3.ProductName);
        //        }
        //    }

        //}

        private void Del_productadd_btn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            var productName = (string)btn.Tag;

            var viewModel = ((this.DataContext) as CustomerViewModal);
            if (viewModel != null)
            {
                var item3 = viewModel.OrderProduct.Where(p => p.ProductName.ToLower() == productName.ToLower()).FirstOrDefault();
                if (item3 != null)
                {



                    viewModel.Deleteproductaddlist(item3.ProductName);
                }
            }

        }



        #endregion





        #region unnecessarycommentedzone
        //private void Shipment_btn_click(object sender, RoutedEventArgs e)
        //{

        //         string htmlFileNameWithPath = "C:/Users/akagarwal1/Documents/Visual Studio 2012/Projects/Shipping Management/Shipping Management/shipment.html";
        //         public static System.Text.StringBuilder ReadHtmlFile(string htmlFileNameWithPath)
        //         {
        //            System.Text.StringBuilder storeContent = new System.Text.StringBuilder();

        //           try
        //           {
        //                  using (StreamReader htmlReader = new StreamReader(htmlFileNameWithPath))
        //                  {
        //                        string lineStr;
        //                       while ((lineStr = htmlReader.ReadLine()) != null)
        //                       {
        //                                storeContent.Append(lineStr);
        //                       }
        //                  }


        //           }
        //        catch (IOException objError)
        //        {
        //            throw objError;
        //        }

        //        return storeContent;
        //    }


        //private void Shipment_btn_click(object sender, RoutedEventArgs e)
        // {

        //    string file_name =  "C:/Users/akagarwal1/Documents/Visual Studio 2012/Projects/Shipping Management/Shipping Management/shipment.html";
        //     try
        //     {
        //         StreamReader myfile = new StreamReader(file_name);
        //         string mystring = myfile.ReadToEnd();
        //         Console.WriteLine(mystring);
        //         Console.ReadLine();

        //     }
        //     catch(IOException ex)
        //     {
        //         Console.WriteLine(ex);

        //     }


        //} 
        #endregion

        private void Shipment_btn_click(object sender, RoutedEventArgs e)
        {

            String File_name = "Barcode\\shipment.html";

            var format = MultiFormatWriter.SupportedWriters;
            imageBarcodeEncoder.Visibility = Visibility.Visible;


            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.CODE_128,
                Renderer = new ZXing.Rendering.WriteableBitmapRenderer(),
                Options = new ZXing.Common.EncodingOptions
                {
                    Height = (int)imageBarcodeEncoder.Height,
                    Width = (int)imageBarcodeEncoder.Width,
                    Margin = 0
                }
            };

            var image = writer.Write(Combo_BarcodeContentEncoder.SelectedItem.ToString());

            imageBarcodeEncoder.Source = image;
            imageBarcodeEncoder.Visibility = Visibility.Visible;

            using (var fileStream = new FileStream("Barcode\\ShipmentBarcode.png", FileMode.Create))
            {
                BitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(image));
                encoder.Save(fileStream);
            }

            try
            {

                if (System.IO.File.Exists(File_name) == true)
                {

                    System.IO.StreamReader objReader = new System.IO.StreamReader(File_name);
                    string mystring = objReader.ReadToEnd();
                    ((this.DataContext) as CustomerViewModal).Shipment_Info();

                    mystring = mystring.Replace("{CustomerNo}", ((this.DataContext) as CustomerViewModal).ShipmentList.CustomerNo.ToString());
                    mystring = mystring.Replace("{CustomerName}", ((this.DataContext) as CustomerViewModal).ShipmentList.CustomerName.ToString());
                    mystring = mystring.Replace("{Address}", ((this.DataContext) as CustomerViewModal).ShipmentList.Address.ToString());
                    mystring = mystring.Replace("{City}", ((this.DataContext) as CustomerViewModal).ShipmentList.City.ToString());
                    mystring = mystring.Replace("{OrderId}", ((this.DataContext) as CustomerViewModal).ShipmentList.OrderId.ToString());
                    mystring = mystring.Replace("{MobileNo}", ((this.DataContext) as CustomerViewModal).ShipmentList.MobileNo.ToString());
                    mystring = mystring.Replace("{TotalAmount}", ((this.DataContext) as CustomerViewModal).ShipmentList.TotalAmount.ToString());
                    string maintitle = "<tr><table>";
                    string maintitle2 = "</table></tr>";
                    string Column = "<th><td><b>ProductName</b></td><td><b>Quantity</b></td><td><b>UnitPrice</b></td></th>";
                    string maintable1 = "<table class=shipmentinfo>";
                    string maintable2 = "</table>";                    
                    string column = " ";
                    foreach (var item in ((this.DataContext) as CustomerViewModal).ShipmentList.print_products)
                    {
                         column += "<tr><td>" + item.ProductName + "</td><td>" + item.Quantity + "</td><td>" + item.UnitPrice + "</td></tr>";
                    }

                    string finaltabel = maintitle + Column + maintitle2 + maintable1 + column + maintable2;
                    mystring = mystring.Replace("{ProductList}", finaltabel);

                    objReader.Close();
                    Guid newFileName = Guid.NewGuid();
                    File.WriteAllText("Barcode\\" + newFileName.ToString() + ".html", mystring);
                    if (File.Exists("Barcode\\" + newFileName.ToString() + ".html"))
                    {
                        System.Diagnostics.Process.Start("Barcode\\" + newFileName.ToString() + ".html");
                    }
                    ;
                    // MessageBox.Show("READED SUCCESSFULLY");
                }
            }

            catch (IOException ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("File Not Exist");

            }


        }

        //private void pdf_btn(object sender, RoutedEventArgs e)
        //{


        //    //// instantiate a html to pdf converter object
        //    //HtmlToPdf converter = new HtmlToPdf();

        //    //// create a new pdf document converting an url
        //    //PdfDocument doc = converter.ConvertUrl(shipment.html);

        //    //// save pdf document
        //    //doc.Save(Response, false, "Sample.pdf");

        //    //// close pdf document
        //    //doc.Close();

        //    //Create a pdf document.
        //    //PdfDocument doc = new PdfDocument();
        //    //String url = "shipment.html";
        //    //doc.LoadFromHTML(url, false, true, true);
        //    ////Save pdf file.
        //    //doc("sample.pdf");
        //    //doc.Close();
        //    ////Launching the Pdf file.
        //    //System.Diagnostics.Process.Start("sample.pdf");
        //    PdfDocument doc = new PdfDocument();

        //    String url = "Barcode\\shipment.html";

        //    Thread thread = new Thread(() =>

        //  { doc.LoadFromHTML(url, false, true, true); });

        //    thread.SetApartmentState(ApartmentState.STA);

        //    thread.Start();

        //    thread.Join();

        //    //Save pdf file.
        //    doc.SaveToFile("sample.pdf");

        //    doc.Close();

        //    //Launching the Pdf file.
        //    System.Diagnostics.Process.Start("sample.pdf");
        //  //  DocumentModel.Load("Barcode\\shipment.html").Save("Document.pdf");
        //}

        ////private void print_btn(object sender, RoutedEventArgs e)
        ////{
        ////    WebBrowser.print();
        //}






    }




}









