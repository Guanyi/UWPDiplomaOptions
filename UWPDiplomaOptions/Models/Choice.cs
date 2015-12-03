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
    public class Choice
    {
        public int ChoiceId { get; set; }
        public string StudentId { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public string FirstChoiceOptionTitle { get; set; }
        public string SecondChoiceOptionTitle { get; set; }
        public string ThirdChoiceOptionTitle { get; set; }
        public string FourthChoiceOptionTitle { get; set; }
        public string SelectionDate { get; set; }
        public int Year { get; set; }
        public int Term  { get; set; }
    }

    public class ChoiceManager
    {
        public static HttpClient http = new HttpClient();
        public static async Task GetChoices(ObservableCollection<Choice> ChoiceList)
        {
            var response = await http.GetAsync("http://uwproject.feifei.ca/api/Choices");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();

                JsonValue value = JsonValue.Parse(result);
                JsonArray root = value.GetArray();
                for (uint i = 0; i < root.Count; i++)
                {
                    var obj = root.GetObjectAt(i);
                    int choiceId = (int)obj.GetNamedNumber("ChoiceId");
                    string studentId = obj.GetNamedString("StudentId");
                    string studentFirstName = obj.GetNamedString("StudentFirstName");
                    string studentLastName = obj.GetNamedString("StudentLastName");
                    string firstChoiceOptionTitle = obj.GetNamedString("FirstChoiceOptionTitle");
                    string secondChoiceOptionTitle = obj.GetNamedString("SecondChoiceOptionTitle");
                    string thirdChoiceOptionTitle = obj.GetNamedString("ThirdChoiceOptionTitle");
                    string fourthChoiceOptionTitle = obj.GetNamedString("FourthChoiceOptionTitle");
                    string selectionDate = obj.GetNamedString("SelectionDate");
                    int year = (int)obj.GetNamedNumber("Year");
                    int term = (int)obj.GetNamedNumber("Term");
                    var choice = new Choice
                    {
                        ChoiceId = choiceId,
                        StudentId = studentId,
                        StudentFirstName = studentFirstName,
                        StudentLastName = studentLastName,
                        FirstChoiceOptionTitle = firstChoiceOptionTitle,
                        SecondChoiceOptionTitle = secondChoiceOptionTitle,
                        ThirdChoiceOptionTitle = thirdChoiceOptionTitle,
                        FourthChoiceOptionTitle = fourthChoiceOptionTitle,
                        SelectionDate = selectionDate,
                        Year = year,
                        Term = term
                    };
                    ChoiceList.Add(choice);
                }
            }
            else
            {
                var dialog = new Windows.UI.Popups.MessageDialog("Cannot retrieve any record");
                await dialog.ShowAsync();
            }
            
        }

        public static async Task AddChoice(StringContent choiceJson)
        {
            var response = await http.PostAsync("http://uwproject.feifei.ca/api/Choices/", choiceJson);

            if (response.IsSuccessStatusCode)
            {
                var dialog = new Windows.UI.Popups.MessageDialog("Saved your Choices!");
                await dialog.ShowAsync();
            }
            else
            {
                var dialog = new Windows.UI.Popups.MessageDialog("Cannot add record");
                await dialog.ShowAsync();
            }
        }


        public static async Task DeleteChoice(string idToBeDeleted, ObservableCollection<Choice> ChoicesList)
        {
            var response = await http.DeleteAsync("http://uwproject.feifei.ca/api/Choices/" + idToBeDeleted);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                JsonValue value = JsonValue.Parse(result);
                Choice choice = JsonConvert.DeserializeObject<Choice>(value.ToString());
                ChoicesList.Remove(choice);
            }
            else
            {
                var dialog = new Windows.UI.Popups.MessageDialog("Cannot delete record");
                await dialog.ShowAsync();
            }
        }

        public static async Task EditChoice(StringContent choiceJsonToBeEdited, Choice updatedChoice, ObservableCollection<Choice> ChoicesList)
        {
            string requestUri = "http://uwproject.feifei.ca/api/Choices/" + updatedChoice.ChoiceId;
            var response = await http.PutAsync(requestUri, choiceJsonToBeEdited);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                Choice currentChoice = ChoicesList.FirstOrDefault(c => c.ChoiceId == updatedChoice.ChoiceId);
                currentChoice = updatedChoice;
            }
            else
            {
                var dialog = new Windows.UI.Popups.MessageDialog("Cannot edit record");
                await dialog.ShowAsync();
            }
        }
    }
}
