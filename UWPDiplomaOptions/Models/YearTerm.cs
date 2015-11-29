using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace UWPDiplomaOptions.Models
{
    public class YearTerm
    {
        public int YearTermId { get; set; }
        public int Year { get; set; }
        public int Term { get; set; }
        public bool IsDefault { get; set; }
        public string Description { get { return $"{Year}/{Term}"; } }
        //public List<Choice> Choices { get; set; }
    }

    public class YearTermManager
    {
        public static async Task GetYearTerms(ObservableCollection<YearTerm> YearTermsList)
        {
            var http = new HttpClient();
            var response = await http.GetAsync("http://uwproject.feifei.ca/api/YearTerms");
            var result = await response.Content.ReadAsStringAsync();

            JsonValue value = JsonValue.Parse(result);
            JsonArray root = value.GetArray();
            for (uint i = 0; i < root.Count; i++)
            {
                int yearTermId = (int)root.GetObjectAt(i).GetNamedNumber("YearTermId");
                int year = (int)root.GetObjectAt(i).GetNamedNumber("Year");
                int term = (int)root.GetObjectAt(i).GetNamedNumber("Term");
                bool isDefault = root.GetObjectAt(i).GetNamedBoolean("IsDefault");
                string description = root.GetObjectAt(i).GetNamedString("Description");
                var yearTerm = new YearTerm
                {
                    YearTermId = yearTermId,
                    Year = year,
                    Term = term,
                    IsDefault = isDefault,
                };
                YearTermsList.Add(yearTerm);
            }
        }
    }
}
