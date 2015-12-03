using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace UWPDiplomaOptions.Models
{
    [DataContract]
    public class Option
    {
        [DataMember]
        public int OptionId { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
    }

    public class OptionManager
    {
        public static HttpClient http = new HttpClient();
        public static async Task GetOptions(ObservableCollection<Option> OptionsList)
        {
            var response = await http.GetAsync("http://uwproject.feifei.ca/api/Options");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                JsonValue value = JsonValue.Parse(result);
                JsonArray root = value.GetArray();
                for (uint i = 0; i < root.Count; i++)
                {
                    int optionId = (int)root.GetObjectAt(i).GetNamedNumber("OptionId");
                    string title = root.GetObjectAt(i).GetNamedString("Titles");
                    bool isActive = root.GetObjectAt(i).GetNamedBoolean("IsActive");
                    var option = new Option
                    {
                        OptionId = optionId,
                        Title = title,
                        IsActive = isActive,
                    };
                    OptionsList.Add(option);
                }
            }
            else
            {
                var dialog = new Windows.UI.Popups.MessageDialog("Cannot retrieve any record");
                await dialog.ShowAsync();
            }
        }

        public static async Task AddOption(StringContent optionJson, ObservableCollection<Option> OptionsList)
        {
            //var http = new HttpClient();
            var response = await http.PostAsync("http://uwproject.feifei.ca/api/Options", optionJson);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                JsonValue value = JsonValue.Parse(result);
                Option option = JsonConvert.DeserializeObject<Option>(value.ToString());
                OptionsList.Add(option);
            }
            else
            {
                var dialog = new Windows.UI.Popups.MessageDialog("Cannot add record");
                await dialog.ShowAsync();
            }
        }

        public static async Task EditOption(StringContent optionJsonToBeEdited, Option updatedOption, ObservableCollection<Option> OptionsList)
        {
           // var http = new HttpClient();
            string requestUri = "http://uwproject.feifei.ca/api/Options/" + updatedOption.OptionId;
            var response = await http.PutAsync(requestUri, optionJsonToBeEdited);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                Option currentOption = OptionsList.FirstOrDefault(o => o.OptionId == updatedOption.OptionId);
                currentOption = updatedOption; 
            }
            else
            {
                var dialog = new Windows.UI.Popups.MessageDialog("Cannot edit record");
                await dialog.ShowAsync();
            }
        }

        public static async Task DeleteOption(string idToBeDeleted, ObservableCollection<Option> OptionsList)
        {
            //var http = new HttpClient();
            var response = await http.DeleteAsync("http://uwproject.feifei.ca/api/Options/" + idToBeDeleted);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                JsonValue value = JsonValue.Parse(result);
                Option option = JsonConvert.DeserializeObject<Option>(value.ToString());
                OptionsList.Remove(option);
            }
            else
            {
                var dialog = new Windows.UI.Popups.MessageDialog("Cannot delete record");
                await dialog.ShowAsync();
            }
        }

    }
}
