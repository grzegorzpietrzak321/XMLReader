using Microsoft.Win32;
using System;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Serialization;
using XMLManager;
//using static XMLReader.FileReader;
//using XMLManager;

namespace XMLReader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mainWindow1.Title = "XML Reader 1.0.0.2";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            listBox1.Items.Clear();
            
            string xmlPath = FileDialog.ReturnPath();

            if (xmlPath != null && xmlPath != "")
            {
                label1.Content = "Wczytany plik: " + xmlPath;
            }
            else
            {
                label1.Content = "Nie wczytano pliku!";
            }

            //.QuoteData.Prices.SellingPrices.Material_List.Material;

            try
            {
                using (FileStream fs = File.OpenRead(xmlPath))// utworzenie strumienia i wczytanie pliku xml
                {
                    ExportData obiekt = (ExportData)new XmlSerializer(typeof(ExportData)).Deserialize(fs); // deserializacja do obiektu klasy Produkty
                    var tmp = obiekt.Header.Project.QuoteData.Prices.SellingPrices.Material_List.Material;
                    string t;
                    decimal tprice = 0;

                    IFormatProvider provider = CultureInfo.InvariantCulture;
                    foreach (var tmpitem in tmp)
                    {
                        if (tmpitem.MATERIAL_OBJECT_TYPE.ToString() != "BackFill")
                        {
                            t = tmpitem.MATERIAL_OBJECT_TYPE.ToString() + "            " + tmpitem.PRICE;
                            tprice += Decimal.Parse(tmpitem.PRICE.ToString(), CultureInfo.InvariantCulture);
                        }
                        else { t = "FILLINGS" + "            " + tmpitem.PRICE; }

                        listBox1.Items.Add(t);
                    }
                    listBox1.Items.Add("MATERIAL            " + tprice);
                    listBox1.Items.Add("KONIEC");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
               string t = listBox1.SelectedValue.ToString().Substring(15).ToString();
                Clipboard.SetText(Decimal.Parse(t, CultureInfo.InvariantCulture).ToString());
            }
            catch { }
        }

        private void Button_Click_Copy(object sender, RoutedEventArgs e)
        {
            listBox2.Items.Clear();
            
            string xmlPath = FileDialog.ReturnPath();
            if (xmlPath != null && xmlPath != "")
            {
                label2.Content = "Wczytany plik: " + xmlPath;
            }
            else
            {
                label2.Content = "Nie wczytano pliku!";
            }

            //.QuoteData.Prices.SellingPrices.Material_List.Material;

            try
            {
                using (FileStream fs = File.OpenRead(xmlPath))// utworzenie strumienia i wczytanie pliku xml
                {
                    ExportData obiekt = (ExportData)new XmlSerializer(typeof(ExportData)).Deserialize(fs); // deserializacja do obiektu klasy Produkty
                    var tmp2 = obiekt.Header.Project.QuoteData.Prices.SellingPrices.Material_List.Material;
                    string t2;
                    decimal tprice2 = 0;

                    IFormatProvider provider = CultureInfo.InvariantCulture;
                    foreach (var tmpitem in tmp2)
                    {
                        if (tmpitem.MATERIAL_OBJECT_TYPE.ToString() != "BackFill")
                        {
                            t2 = tmpitem.MATERIAL_OBJECT_TYPE.ToString() + "            " + tmpitem.PRICE;
                            tprice2 += Decimal.Parse(tmpitem.PRICE.ToString(), CultureInfo.InvariantCulture);
                        }
                        else { t2 = "FILLINGS" + "            " + tmpitem.PRICE; }

                        listBox2.Items.Add(t2);
                    }
                    listBox2.Items.Add("MATERIAL            " + tprice2);
                    listBox2.Items.Add("KONIEC");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Clipboard.SetText(listBox2.SelectedValue.ToString());
            }
            catch { }
        }
    }
}

//TODO 1. dodać automatyczną zmianę wersji po zrobieniu buildu
//TODO 2. dodać numer wersji w tytule aplikacji
//TODO 3. wysypuje aplikację przy próbie wczytania kolejnego pliku gdy coś jest zaznaczone w listboxie

