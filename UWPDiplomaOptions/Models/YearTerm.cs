using Newtonsoft.Json;
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
        public static HttpClient http = new HttpClient();
        public static async Task GetYearTerms(ObservableCollection<YearTerm> YearTermsList)
        {
            var response = await http.GetAsync("http://uwproject.feifei.ca/api/YearTerms");
            if (response.IsSuccessStatusCode)
            {
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
            else
            {
                var dialog = new Windows.UI.Popups.MessageDialog("Cannot retrieve any record");
                await dialog.ShowAsync();
            }
        }

        public static async Task AddYearTerm(StringContent yearTermJson, ObservableCollection<YearTerm> YearTermList)
        {
            var response = await http.PostAsync("http://uwproject.feifei.ca/api/YearTerms", yearTermJson);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                JsonValue value = JsonValue.Parse(result);
                YearTerm yearTerm = JsonConvert.DeserializeObject<YearTerm>(value.ToString());
                YearTermList.Add(yearTerm);
            }
            else
            {
                var dialog = new Windows.UI.Popups.MessageDialog("Cannot add record");
                await dialog.ShowAsync();
            }

        }

        public static async Task EditYearTerm(StringContent YearTermJsonToBeEdited, YearTerm updatedYearTerm, ObservableCollection<YearTerm> YearTermList)
        {
            string requestUri = "http://uwproject.feifei.ca/api/YearTerms/" + updatedYearTerm.YearTermId;
            var response = await http.PutAsync(requestUri, YearTermJsonToBeEdited);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                YearTerm currentYearTerm = YearTermList.FirstOrDefault(o => o.YearTermId == updatedYearTerm.YearTermId);
                currentYearTerm = updatedYearTerm;
            }
            else
            {
                var dialog = new Windows.UI.Popups.MessageDialog("Cannot edit record");
                await dialog.ShowAsync();
            }
        }

        public static async Task DeleteYearTerm(string YearTermIdToBeDeleted, ObservableCollection<YearTerm> YearTermList)
        {
            var response = await http.DeleteAsync("http://uwproject.feifei.ca/api/YearTerms/" + YearTermIdToBeDeleted);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                JsonValue value = JsonValue.Parse(result);
                YearTerm yearTerm = JsonConvert.DeserializeObject<YearTerm>(value.ToString());
                YearTermList.Remove(yearTerm);
            }
            else
            {
                var dialog = new Windows.UI.Popups.MessageDialog("Cannot delete record");
                await dialog.ShowAsync();
            }
        }
    }
}
