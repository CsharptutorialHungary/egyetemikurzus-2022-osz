using System;
using System.Xml.Serialization;

namespace ZCSVParser.RECORDS
{
    public sealed record class NapiAdagPerEtkezesFajta
    {
        [XmlElement(DataType = "date")]
        public DateTime Datum { get; init; }
        public string EtkezesFajta { get; init; }
        public int Adag { get; init; }

        public NapiAdagPerEtkezesFajta(DateTime datum, string etkezesFajta, int adag = 0)
        {
            Datum = datum;
            EtkezesFajta = etkezesFajta;
            Adag = adag;
        }

        public NapiAdagPerEtkezesFajta()
        {
            Datum = DateTime.MinValue;
            EtkezesFajta = null;
            Adag = 0;
        }
    }
}
