using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Printo.Intranet.Models
{
    public class BarChartVM
    {
        public BarChartVM()
        {
            labels = new List<string>();
            datasets = new List<BarChartChildVM>();
        }
        public List<string> labels { get; set; }
        public List<BarChartChildVM> datasets { set; get; }
    }

    public class BarChartChildVM
    {
        public BarChartChildVM()
        {
            data = new List<int>();
        }

        public string label { get; set; }
        public string backgroundColor { get; set; }
        public string borderColor { get; set; }
        public int borderWidth { get; set; }
        public string hoverBackgroundColor { get; set; }
        public string hoverBorderColor { get; set; }
        public List<int> data { get; set; }
    }
}
