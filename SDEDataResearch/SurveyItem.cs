using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace SDEDataResearch
{
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
        public string[] IDES { get { return IDE.Split(',').Length <= 0 ? new string[] { IDE } : IDE.Split(','); } }
        public string[] FrameWorks { get { return frameWorks.Split(',').Length <= 0 ? new string[] { frameWorks } : frameWorks.Split(','); } }
        public string[] ProgrammingLanguages { get { return programmingLanguages.Split(',').Length <= 0 ? new string[] { programmingLanguages } : programmingLanguages.Split(','); } }
        public string[] ProfessionalCertificates { get { return professionalCertificates.Split(',').Length <= 0 ? new string[] { professionalCertificates } : professionalCertificates.Split(','); } }
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
}
