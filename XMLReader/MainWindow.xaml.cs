using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Controls;
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
            mainWindow1.Title = "XML Reader 1.0.0.2";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            listBox1.Items.Clear();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML Files (*.xml;*.XML)|*.xml;*.XML";
            if (openFileDialog.ShowDialog() == true)
                File.ReadAllText(openFileDialog.FileName);
            string path = openFileDialog.FileName.ToString();

            if (path != null && path != "")
            {
                label1.Content = "Wczytany plik: " + path;
            }
            else
            {
                label1.Content = "Nie wczytano pliku!";
                    }

            try
            {
                FileStream fs = File.OpenRead(path); // utworzenie strumienia i wczytanie pliku xml
                ExportData obiekt = (ExportData)new XmlSerializer(typeof(ExportData)).Deserialize(fs); // deserializacja do obiektu klasy Produkty

                var tmp = obiekt.Header.Project.QuoteData.Prices.SellingPrices.Material_List.Material;

                foreach (var tmpitem in tmp)
                {

                    listBox1.Items.Add(tmpitem.MATERIAL_OBJECT_TYPE.ToString() + "            " + tmpitem.PRICE);
                }
                listBox1.Items.Add("KONIEC");
            }
            catch
            {

            }
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Clipboard.SetText(listBox1.SelectedValue.ToString());
            }
            catch
            {

            }
        }
    }
}

//TODO 1. dodać automatyczną zmianę wersji po zrobieniu buildu
//TODO 2. dodać numer wersji w tytule aplikacji
//TODO 3. wysypuje aplikację przy próbie wczytania kolejnego pliku gdy coś jest zaznaczone w listboxie

