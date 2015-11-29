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
        public int? FirstChoiceOptionId { get; set; }
        //public Option Option1 { get; set; }
        public int? SecondChoiceOptionId { get; set; }
        //public Option Option2 { get; set; }
        public int? ThirdChoiceOptionId { get; set; }
        //public Option Option3 { get; set; }
        public int? FourthChoiceOptionId { get; set; }
        //public Option Option4 { get; set; }
        public DateTime SelectionDate { get; set; }
        public int YearTermId { get; set; }
        public YearTerm YearTerm { get; set; }
    }

    public class ChoiceManager
    {
        public static async Task GetChoices(ObservableCollection<Choice> YearTermsList)
        {
            var http = new HttpClient();
            var response = await http.GetAsync("http://uwproject.feifei.ca/api/Choices");
            var result = await response.Content.ReadAsStringAsync();

            JsonValue value = JsonValue.Parse(result);
            JsonArray root = value.GetArray();
            //for (uint i = 0; i < root.Count; i++)
            //{
            //    int choiceId = (int)root.GetObjectAt(i).GetNamedNumber("ChoiceId");
            //    string studentId = root.GetObjectAt(i).GetNamedString("StudentId");
            //    string studentFirstName = root.GetObjectAt(i).GetNamedString("StudentFirstName");
            //    string studentLastName = root.GetObjectAt(i).GetNamedString("StudentLastName");
            //    int firstChoiceOptionId = (int)root.GetObjectAt(i).GetNamedNumber("FirstChoiceOptionId");
            //    //string option = root.GetObjectAt(i).GetNamedString("")
            //    //int secondChoiceOptionId = (int)root.GetObjectAt(i).GetNamedNumber("SecondChoiceOptionId");

            //    int thirdChoiceOptionId = (int)root.GetObjectAt(i).GetNamedNumber("ThirdChoiceOptionId");

            //    int fourthChoiceOptionId = (int)root.GetObjectAt(i).GetNamedNumber("FourthChoiceOptionId");
            //    DateTime selecttionDate = (DateTime)root.GetObjectAt(i).GetNamedObject("SelectionDate");


            //    int term = (int)root.GetObjectAt(i).GetNamedNumber("Term");
            //    bool isDefault = root.GetObjectAt(i).GetNamedBoolean("IsDefault");
            //    string description = root.GetObjectAt(i).GetNamedString("Description");
            //    var yearTerm = new YearTerm
            //    {
            //        YearTermId = yearTermId,
            //        Year = year,
            //        Term = term,
            //        IsDefault = isDefault,
            //    };
            //    YearTermsList.Add(yearTerm);
            //}
        }
    }
}
