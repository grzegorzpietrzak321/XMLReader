using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XMLManager
{

    [XmlRoot(ElementName = "ExportData", Namespace = "", IsNullable = false)]
    public class ExportData
    {
        private Headers _headerField;

        [XmlElement("Header")]
        public Headers Header
        {
            get
            { return this._headerField; }
            set
            { this._headerField = value; }
        }



        public class Headers
        {
            private Projects _projectField;

            [XmlElement("ProviderList")]
            public ProviderList ProviderList { get; set; }

            [XmlElement("Beams")]
            public Beams Beams { get; set; }

            [XmlElement("AccessoriesPack")]
            public AccessoriesPack AccessoriesPack { get; set; }

            [XmlElement("HardwarePack")]
            public HardwarePack HardwarePack { get; set; }

            [XmlElement("AeratorPack")]
            public AeratorPack AeratorPack { get; set; }

            [XmlElement("GasketPack")]
            public GasketPack GasketPack { get; set; }

            [XmlElement("BackFillPack")]
            public BackFillPack BackFillPack { get; set; }

            [XmlElement("Project")]
            public Projects Project
            {
                get { return this._projectField; }
                set { this._projectField = value; }
            }
        }


        public class ProviderList
        {

        }

        public class Beams
        {

        }

        public class AccessoriesPack
        {

        }

        public class HardwarePack
        {

        }

        public class AeratorPack
        {

        }

        public class GasketPack
        {

        }

        public class BackFillPack
        {

        }

        [Serializable]
        public class Projects
        {
            private QuoteDatas _quoteDataField;

            [XmlElement("QUOTEDATA")]
            public QuoteDatas QuoteData
            {
                get { return this._quoteDataField; }
                set { this._quoteDataField = value; }
            }
        }

        public class QuoteDatas
        {
            private Priceses _pricesValue;
            [XmlElement("PRICES")]
            public Priceses Prices
            {
                get { return this._pricesValue; }
                set { this._pricesValue = value; }
            }
        }

        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public class Priceses
        {
            [XmlElement("SELLINGPRICES")]
            public SellingPrices SellingPrices { get; set; }
        }

        public class SellingPrices
        {
            [XmlElement("MATERIAL_LIST")]
            public Material_List Material_List { get; set; }
        }
        public class Material_List
        {
            [XmlElement("MATERIAL")]
            public Material[] Material { get; set; }
        }

        public class Material
        {
            private string _material_object_typeField;
            private string _priceField;

            [System.Xml.Serialization.XmlElementAttribute("MATERIAL_OBJECT_TYPE")]
            public string MATERIAL_OBJECT_TYPE
            {
                get { return this._material_object_typeField; }
                set { this._material_object_typeField = value; }

            }

            [System.Xml.Serialization.XmlElementAttribute("PRICE")]
            public string PRICE
            {
                get { return this._priceField; }
                set { this._priceField = value; }
            }
        }
    }
}





