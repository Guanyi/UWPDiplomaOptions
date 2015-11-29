using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
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
        public static async Task GetOptions(ObservableCollection<Option> OptionsList)
        {
            var http = new HttpClient();
            var response = await http.GetAsync("http://uwproject.feifei.ca/api/Options");
            var result = await response.Content.ReadAsStringAsync();

            JsonValue value = JsonValue.Parse(result);
            JsonArray root = value.GetArray();
            for (uint i = 0; i < root.Count; i++)
            {
                int optionId = (int)root.GetObjectAt(i).GetNamedNumber("OptionId");
                string title = root.GetObjectAt(i).GetNamedString("Title");
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
    }
}
