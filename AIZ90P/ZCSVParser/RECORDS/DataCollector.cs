﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZCSVParser.DATATYPES;

namespace ZCSVParser.RECORDS
{
    public static class DataCollector
    {
        public static List<NapiAdag> CollectDataForNapiAdag(List<RendelesInput> InputData)
        {
            List<NapiAdag> data = InputData.GroupBy(x => x.Datum).Select(c1 => new NapiAdag(c1.Key, c1.Sum(c => c.f_adag))).ToList<NapiAdag>();
            return data;
        }

        public static List<NapiAdagPerEtkezesFajta> CollectDataForNapiAdagPerEtkezesFajta(List<RendelesInput> InputData)
        {
            List<NapiAdagPerEtkezesFajta> data = InputData.GroupBy(x => new { x.Datum, x.EtkezesFajtaKod }).Select(c1 => new NapiAdagPerEtkezesFajta(c1.Key.Datum, c1.Key.EtkezesFajtaKod, c1.Sum(c => c.f_adag))).ToList<NapiAdagPerEtkezesFajta>();
            return data;
        }

        public static List<NapiAdagPerFogyasztoKod> CollectDataForNapiAdagPerFogyasztoKod(List<RendelesInput> InputData)
        {
            List<NapiAdagPerFogyasztoKod> data = InputData.GroupBy(x => new { x.Datum, x.FogyasztoKod }).Select(c1 => new NapiAdagPerFogyasztoKod(c1.Key.Datum, c1.Key.FogyasztoKod, c1.Sum(c => c.f_adag))).ToList<NapiAdagPerFogyasztoKod>();
            return data;
        }
    }
}
