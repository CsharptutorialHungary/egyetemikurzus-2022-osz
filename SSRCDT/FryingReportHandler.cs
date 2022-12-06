using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSRCDT
{
    public class FryingReportHandler
    {
        public List<Meat> FriesReport { get; set; }
        public FryingReportHandler()
        {
            FriesReport = new List<Meat>();
        }

        public void AddToDailyReport(Meat meat)
        {
            FriesReport.Add(meat);
        }
    }
}
