using System;

namespace ZCSVParser.DATATYPES
{
    public sealed record class RendelesInput
    {
        public DateTime Datum { get; init; }
        public string FogyasztoKod { get; init; }
        public string FogyasztoTipusKod { get; init; }
        public string EtkezesTipusKod { get; init; }
        public string EtkezesFajtaKod { get; init; }
        public int f_adag { get; init; }

        public RendelesInput(DateTime datum, string fogyasztoKod, string fogyasztoTipusKod, string etkezesTipusKod, string etkezesFajtaKod, int f_adag)
        {
            Datum = datum;
            FogyasztoKod = fogyasztoKod;
            FogyasztoTipusKod = fogyasztoTipusKod;
            EtkezesTipusKod = etkezesTipusKod;
            EtkezesFajtaKod = etkezesFajtaKod;
            this.f_adag = f_adag;
        }
    }
}
