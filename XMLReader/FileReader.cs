using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XMLReader
{
    //static class FileReader
    //{
    //    static public FileStream OpenFile(string _path, <T> test)
    //    {
    //        using (FileStream fs = File.OpenRead(_path))// utworzenie strumienia i wczytanie pliku xml
    //        {
    //            ExportData obiekt = (ExportData)new XmlSerializer(typeof(ExportData)).Deserialize(fs); // deserializacja do obiektu klasy Produkty
    //            var tmp2 = obiekt.Header.Project.QuoteData.Prices.SellingPrices.Material_List.Material;
    //            string t2;
    //            decimal tprice2 = 0;

    //            IFormatProvider provider = CultureInfo.InvariantCulture;
    //            foreach (var tmpitem in tmp2)
    //            {
    //                if (tmpitem.MATERIAL_OBJECT_TYPE.ToString() != "BackFill")
    //                {
    //                    t2 = tmpitem.MATERIAL_OBJECT_TYPE.ToString() + "            " + tmpitem.PRICE;
    //                    tprice2 += Decimal.Parse(tmpitem.PRICE.ToString(), CultureInfo.InvariantCulture);
    //                }
    //                else { t2 = "FILLINGS" + "            " + tmpitem.PRICE; }

    //                listBox2.Items.Add(t2);
    //            }
    //            listBox2.Items.Add("MATERIAL            " + tprice2);
    //            listBox2.Items.Add("KONIEC");
    //        }

    //        return _fileStream;
    //    }

    //    public class Generyczna<T> where T : class
    //    {
    //        private T obiekt;

    //        public  T Czytaj(T parametr, string _path)
    //        {
    //            using (FileStream fs = File.OpenRead(_path))
    //            {
    //                return obiekt = (T)new XmlSerializer(typeof(T)).Deserialize(fs);
    //            }

    //        }
    //    }
    //}
}