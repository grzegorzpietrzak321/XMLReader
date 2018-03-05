using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Serialization;
using XMLManager;

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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            listBox1.Items.Clear();


            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                File.ReadAllText(openFileDialog.FileName);
            string path = openFileDialog.FileName.ToString();

            label1.Content = "Wczytany plik: " + path;

            FileStream fs = File.OpenRead(path); // utworzenie strumienia i wczytanie pliku xml
            ExportData obiekt = (ExportData)new XmlSerializer(typeof(ExportData)).Deserialize(fs); // deserializacja do obiektu klasy Produkty

            var tmp = obiekt.Header.Project.QuoteData.Prices.SellingPrices.Material_List.Material;

            foreach (var tmpitem in tmp)
            {

                listBox1.Items.Add(tmpitem.MATERIAL_OBJECT_TYPE.ToString() + "            " + tmpitem.PRICE);
            }
            listBox1.Items.Add("KONIEC");
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Clipboard.SetText(listBox1.SelectedValue.ToString());
        }
    }
}

//TODO 1. dodać automatyczną zmianę wersji po zrobieniu buildu
//TODO 2. dodać numer wersji w tytule aplikacji
//TODO 3. wysypuje aplikację przy próbie wczytania kolejnego pliku gdy coś jest zaznaczone w listboxie

