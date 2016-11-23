using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SDEDataResearch
{
    class SurveyItems
    {
        public SurveyItem[] Items { get { return items; } }
        private SurveyItem[] items;

        public SurveyItems(string file)
        {
            items = JsonConvert.DeserializeObject<SurveyItem[]>(file);
            foreach (var item in items)
                item.RemoveSpacesFromAll();
        }

        public SurveyItem[] GetItemsByDate(DateTime date)
        {
            return items.Where(i => i.timeStamp == date).ToArray();
        }

        public SurveyItem[] GetItemsBySalaryRange(Range range)
        {
            return items.Where(i => i.SalaryRange == range).ToArray();
        }

        public SurveyItem[] GetItemsTeamRange(Range range)
        {
            return items.Where(i => i.TeamSize == range).ToArray();
        }

        public SurveyItem[] GetItemsByMaxSalary(double MaxRange)
        {
            return items.Where(i => i.SalaryRange.max == MaxRange).ToArray();
        }

        public SurveyItem[] GetItemsByMinSalary(double minrange)
        {
            return items.Where(i => i.SalaryRange.max == minrange).ToArray();
        }

        public SurveyItem[] GetItemsByMinTeamSize(double minSize)
        {
            return items.Where(i => i.TeamSize.min == minSize).ToArray();
        }

        public SurveyItem[] GetItemsByMaxTeamSize(double maxRange)
        {
            return items.Where(i => i.TeamSize.max == maxRange).ToArray();
        }

        public SurveyItem[] GetItemsByWorkLocation(string location)
        {
            return items.Where(i => i.employeeWorkLocation == location).ToArray();
        }

        public SurveyItem[] GetItemsByEmployeeLocation(string location)
        {
            return items.Where(i => i.employeeLocation == location).ToArray();
        }

        public SurveyItem[] GetItemsByEmployeerLocation(string location)
        {
            return items.Where(i => i.employerLocation == location).ToArray();
        }

        public SurveyItem[] GetItemsByWorKSector(string workSector)
        {
            return items.Where(i => i.WorkSectors.Any(m => m == workSector)).ToArray();
        }

        public SurveyItem[] GetItemsByLanguage(string language)
        {
            return items.Where(i => i.ProgrammingLanguages.Any(m => m == language)).ToArray();
        }

        public SurveyItem[] GetItemsByEducation(string education)
        {
            return items.Where(i => i.education == education).ToArray();
        }

        public SurveyItem[] GetItemsByProfessionalCertificate(string certificate)
        {
            return items.Where(i => i.ProfessionalCertificates.Any(p => p == certificate)).ToArray();
        }

        public SurveyItem[] GetItemsByMethodology(string methodology)
        {
            return items.Where(i => i.Methodologies.Any(m => m == methodology)).ToArray();
        }

        public SurveyItem[] GetItemsByIDE(string ide)
        {
            return items.Where(i => i.IDES.Any(p => p == ide)).ToArray();
        }

        public SurveyItem[] GetItemsByFrameWork(string framework)
        {
            return items.Where(i => i.FrameWorks.Any(p => p == framework)).ToArray();
        }

        public SurveyItem[] GetItemsByPosition(string position)
        {
            return items.Where(i => i.Position == position).ToArray();
        }

        public SurveyItem[] GetItemsByEmployementType(string type)
        {
            return items.Where(i => i.employmentType == type).ToArray();
        }

        public SurveyItem[] GetItemsBySector(string sector)
        {
            return items.Where(i => i.WorkSectors.Any(p => p == sector)).ToArray();
        }

        public string[] GetAllWorkSectors()
        {
            var list = new List<string>();

            foreach(var item in items)
                foreach (var strng in item.WorkSectors)
                    if (!list.Contains(strng))
                        list.Add(strng);
            
            return list.ToArray();
        }

        public string[] GetAllFrameworks()
        {
            var list = new List<string>();

            foreach (var item in items)
                foreach (var strng in item.FrameWorks)
                    if (!list.Contains(strng))
                        list.Add(strng);
            return list.ToArray();
        }

        public string[] GetAllProgrammingLanguages()
        {
            var list = new List<string>();

            foreach (var item in items)
                foreach (var strng in item.ProgrammingLanguages)
                    if (!list.Contains(strng))
                        list.Add(strng);

            return list.ToArray();
        }

        public string[] GetAllProfessionalCertificates()
        {
            var list = new List<string>();

            foreach (var item in items)
                foreach (var strng in item.ProfessionalCertificates)
                    if (!list.Contains(strng))
                        list.Add(strng);

            return list.ToArray();
        }

        public string[] GetAllMethodologies()
        {
            var list = new List<string>();

            foreach (var item in items)
                foreach (var strng in item.Methodologies)
                    if (!list.Contains(strng))
                        list.Add(strng);

            return list.ToArray();
        }

        public string [] GetAllIDES()
        {
            var list = new List<string>();

            foreach (var item in items)
                foreach (var strng in item.IDES)
                    if (!list.Contains(strng))
                        list.Add(strng);

            return list.ToArray();
        }
    }
}
