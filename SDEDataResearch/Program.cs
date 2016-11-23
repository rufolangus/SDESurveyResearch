using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDEDataResearch
{
    class Program
    {
        private static SurveyItems surveyItems;
        static void Main(string[] args)
        {
            var file = System.IO.File.ReadAllText(@".\rawdata.json");
            surveyItems = new SurveyItems(file);
            /*
            Print("FrameWorks");
            Print(surveyItems.GetAllFrameworks(), true);
            Print("IDES");
            Print(surveyItems.GetAllIDES());
            Print("Methodologies");
            Print(surveyItems.GetAllMethodologies(),true);
            Print("Professional Certificates");
            Print(surveyItems.GetAllProfessionalCertificates(),true);
            Print("Work Sectors");
            Print(surveyItems.GetAllWorkSectors());
            Print("Programming Languages");
            Print(surveyItems.GetAllProgrammingLanguages(),true);
            */
            var highestPaid = surveyItems.Items.Where(i => i.SalaryRange.max == surveyItems.Items.Max(x => x.SalaryRange.max)).ToArray();
            var lowestPaid = surveyItems.Items.Where(i => i.SalaryRange.min == surveyItems.Items.Min(x => x.SalaryRange.min)).ToArray();
            var both = new List<SurveyItem>();
            both.AddRange(highestPaid);
            both.AddRange(lowestPaid);
            var mid = surveyItems.Items.Where(i => !both.Contains(i)).ToArray();
            Print("HIGHEST PAID");
            PrintDetails(highestPaid, true);
            Print("");
            /*
            Print("MID PAID");
            PrintDetails(mid, true);
            Print("");
            */
            Print("LOWEST PAID");
            PrintDetails(lowestPaid,true);
            var averageMax = surveyItems.Items.Average(i => i.SalaryRange.max);
            var averageMin = surveyItems.Items.Average(i => i.SalaryRange.min);
            Print("");
            Print("AVERAGE SALARY RANGE");
            Print("Overall Average: " + averageMin + " - " + averageMax);
            var puertoRico = surveyItems.Items.Where(i => i.employeeLocation == "Puerto Rico").ToArray();
            var prAverageMax = puertoRico.Average(i => i.SalaryRange.max);
            var prAverageMin = puertoRico.Average(i => i.SalaryRange.min);
            Print("PR Average: " + prAverageMin + " - " + prAverageMax);

            var notPuertoRico = surveyItems.Items.Where(i => i.employeeLocation != "Puerto Rico").ToArray();

            var notPrAverageMax = notPuertoRico.Average(i => i.SalaryRange.max);
            var notPrAverageMin = notPuertoRico.Average(i => i.SalaryRange.min);
            Print("Not PR Average: " + notPrAverageMin + " - " + notPrAverageMax);

            Console.ReadLine();
        }

        static void Print(SurveyItem[] items, bool printCount = false)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (printCount)
                    Print(items[i], i + 1);
                else
                    Print(items[i]);
            }
        }

        static void Print(SurveyItem item, int number = -1)
        {
            var output = number < 0 ? item.ToString() : "#" + number + " " + item.ToString();
            Console.WriteLine(output);
        }

        static void Print(string[] items, bool printCount = false)
        {
                for(int i = 0; i < items.Length; i++)
                {
                    if (printCount)
                        Print(items[i], i + 1);
                    else
                        Print(items[i]);
                }
        }

        static void Print(string msg, int number = -1)
        {
            msg = number < 0 ? msg : "#" + number + " " + msg;
            Console.WriteLine(msg);
        }

        static void PrintDetails(SurveyItem[] items, bool printCount = false)
        {
            for(int i = 0; i < items.Length; i++)
            {
                var item = items[i];
                if (printCount)
                    PrintDetails(item, i);
                else
                    PrintDetails(item);
            }
        }

        static void PrintDetails(SurveyItem item, int number = -1)
        {
            if(!(number < 0))
            Print("ITEM #" + (number + 1));
            Print("Industries: ");
            Print(item.WorkSectors, true);
            Print("Employment Type: " + item.employmentType);
            Print("Location: " + item.employeeWorkLocation);
            Print("Employee Location: " + item.employeeLocation);
            Print("Education: " + item.education);
            Print("Salary: " + item.SalaryRange.ToString());
            Print("Languages: ");
            Print(item.ProgrammingLanguages, true);
            Print("FrameWorks:");
            Print(item.FrameWorks, true);
            Print("");
            Print("Team Size: " + item.TeamSize.ToString());
        }
    }    
}
