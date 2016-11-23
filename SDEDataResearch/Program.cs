using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace SDEDataResearch
{
    class Program
    {
        private static SurveyItems surveyItems;
        static void Main(string[] args)
        {
            var file = System.IO.File.ReadAllText(@"C:\Users\blurryRobot\Desktop\rawdata.json");
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


    [Serializable]
    public class SurveyItem
    {
        [JsonProperty("Timestamp")]
        public DateTime timeStamp;
        [JsonProperty("Type of Employment")]
        public string employmentType;
        [JsonProperty("Position")]
        public string Position;
        [JsonProperty("How big is your Team")]
        public string teamSize;
        [JsonProperty("Employer Location (Where are your offices?)")]
        public string employerLocation;
        [JsonProperty("Employee Location (Where do you Live?)")]
        public string employeeLocation;
        [JsonProperty("Employee Location (Where do you work from?)")]
        public string employeeWorkLocation;
        [JsonProperty("Sector you serve (check all that apply)")]
        private string workSector;
        [JsonProperty("Methodologies (choose all that apply)")]
        private string methodologies;
        [JsonProperty("Formal Education")]
        public string education;
        [JsonProperty("Professional Certifications (check all that apply)")]
        private string professionalCertificates;
        [JsonProperty("Programming Languages")]
        private string programmingLanguages;
        [JsonProperty("Frameworks, Libraries or ...(choose all that apply)")]
        private string frameWorks;
        [JsonProperty("IDE (check all that apply)")]
        private string IDE;
        [JsonProperty("Annual Salary Gross Income (USD)")]
        public string anualSalary;
        [JsonProperty("Comments (optional)")]
        public string comments;
        
        public Range SalaryRange { get { return new Range(anualSalary); } }
        public Range TeamSize { get { return new Range(teamSize); } }
        public string [] IDES { get { return IDE.Split(',').Length <= 0 ? new string[] { IDE } : IDE.Split(','); } }
        public string [] FrameWorks { get { return frameWorks.Split(',').Length <= 0 ? new string[] { frameWorks } : frameWorks.Split(','); } }
        public string [] ProgrammingLanguages { get { return programmingLanguages.Split(',').Length <= 0 ? new string[] { programmingLanguages } : programmingLanguages.Split(','); } }
        public string [] ProfessionalCertificates { get { return professionalCertificates.Split(',').Length <= 0 ? new string[] { professionalCertificates } : professionalCertificates.Split(','); } }
        public string[] Methodologies { get { return methodologies.Split(',').Length <= 0 ? new string[] { methodologies } : methodologies.Split(','); } }
        public string[] WorkSectors { get { return workSector.Split(',').Length <= 0 ? new string[] { workSector } : workSector.Split(','); } }

        public void RemoveSpacesFromAll()
        {
            IDE = RemoveSpaces(IDE);
            frameWorks = RemoveSpaces(frameWorks);
            programmingLanguages = RemoveSpaces(programmingLanguages);
            professionalCertificates = RemoveSpaces(professionalCertificates);
            methodologies = RemoveSpaces(methodologies);
            workSector = RemoveSpaces(workSector);
        }

        string RemoveSpaces(string value)
        {
            var result = value.Replace(" ", "");
            return result;
        }

        public override string ToString()
        {
           var result = "TimeStamp: " + timeStamp.ToString() + " EmployeeType: " + employmentType + " Employer Location: " + employerLocation
                + " Employee Location: " + employeeLocation + " Employee Work Location: " + employeeWorkLocation + " Work Sector: " + workSector +
                " Methodologies: " + methodologies + " Education: " + education + " Certificates: " + professionalCertificates + " Programming Languages: "
                + programmingLanguages + " FrameWorks: " + frameWorks + " IDE: " + IDE + " Salary: " + anualSalary + " Comments:" + comments;
            return result;
        }
    }
    
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
