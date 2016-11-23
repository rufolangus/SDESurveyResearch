using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDEDataResearch
{
    public class Range
    {
        public double max;
        public double min;


        public Range(string size)
        {
            size = size.Replace("\'", "");
            size = size.Replace(" ", "");
            if (size.Length == 1)
            {
                min = 1;
                max = 1;
            }
            else if (size.Contains("Over"))
            {
                min = 10;
                max = 100;
            }
            else
            {
                var values = size.Split('-');
                var ints = values.Select(v => double.Parse(v.Replace(" ", ""), System.Globalization.NumberStyles.AllowThousands));
                max = ints.Max();
                min = ints.Min();
            }
        }

        public override string ToString()
        {
            return min + " - " + max;
        }
    }
}
