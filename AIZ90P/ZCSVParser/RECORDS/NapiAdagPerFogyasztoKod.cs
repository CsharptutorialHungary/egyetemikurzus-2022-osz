using System;
using System.Xml.Serialization;

namespace ZCSVParser.RECORDS
{
    public sealed record class NapiAdagPerFogyasztoKod
    {
        [XmlElement(DataType = "date")]
        public DateTime Datum { get; init; }
        public string FogyasztoKod { get; init; }

        public int Adag { get; init; }

        public NapiAdagPerFogyasztoKod(DateTime datum, string fogyasztoKod, int adag = 0)
        {
            Datum = datum;
            FogyasztoKod = fogyasztoKod;
            Adag = adag;
        }

        public NapiAdagPerFogyasztoKod()
        {
            Datum = DateTime.MinValue;
            FogyasztoKod = null;
            Adag = 0;
        }
    }
}
