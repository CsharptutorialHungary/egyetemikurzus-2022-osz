using System;
using System.Xml.Serialization;

namespace ZCSVParser.RECORDS
{
    public sealed record class NapiAdag
    {
        [XmlElement(DataType = "date")]
        public DateTime Datum { get; init; }
        public int Adag { get; init; }

        public NapiAdag(DateTime datum, int adag = 0)
        {
            Datum = datum;
            Adag = adag;
        }

        public NapiAdag()
        {
            Datum = DateTime.MinValue;
            Adag = 0;
        }
    }
}
