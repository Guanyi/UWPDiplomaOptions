using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using UWPDiplomaOptions.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPDiplomaOptions
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {

        public ObservableCollection<Option> Options;
        public YearTerm defaultYearTerm;


        public HomePage()
        {
            Options = new ObservableCollection<Option>();
            DataContext = Options;
            this.InitializeComponent();
        }

        private async void Page_Loading(FrameworkElement sender, object args)
        {
            var obj = App.Current as App;
            StudentNumberBox.Text = obj.studentNumber;

            OptionManager.http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", obj.AccessToken);
            await OptionManager.GetActiveOptions(Options);
            YearTermManager.http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", obj.AccessToken);
            defaultYearTerm = await YearTermManager.DefaultYearTerm(defaultYearTerm);
        }


        private async void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Windows.UI.Popups.MessageDialog("");
            if (StudentNumberBox.Text != "" || FirstNameBox.Text != "" || LastNameBox.Text != "")
            {
                if (Choice1ComboBox.SelectedValue != Choice2ComboBox.SelectedValue
                    || Choice1ComboBox.SelectedValue != Choice3ComboBox.SelectedValue
                    || Choice1ComboBox.SelectedValue != Choice4ComboBox.SelectedValue
                    || Choice2ComboBox.SelectedValue != Choice3ComboBox.SelectedValue
                    || Choice2ComboBox.SelectedValue != Choice4ComboBox.SelectedValue
                    || Choice3ComboBox.SelectedValue != Choice4ComboBox.SelectedValue)
                {
                    string studentId = StudentNumberBox.Text;
                    string fName = FirstNameBox.Text;
                    string lName = LastNameBox.Text;
                    int firstChoice = (int)Choice1ComboBox.SelectedValue;
                    int secondChoice = (int)Choice2ComboBox.SelectedValue;
                    int thirdChoice = (int)Choice3ComboBox.SelectedValue;
                    int fourthChoice = (int)Choice4ComboBox.SelectedValue;

                    int YearTermId = defaultYearTerm.YearTermId;
                    var obj = new { StudentId = studentId, StudentFirstName = fName, StudentLastName = lName, FirstChoiceOptionId = firstChoice, SecondChoiceOptionId = secondChoice, ThirdChoiceOptionId = thirdChoice, FourthChoiceOptionId = fourthChoice, YearTermId = YearTermId, SelectionDate = DateTime.Now.ToString() };
                    var obj2 = App.Current as App;
                    ChoiceManager.http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", obj2.AccessToken);
                    await ChoiceManager.AddChoice(new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json"));
                }
                else
                {
                    dialog = new Windows.UI.Popups.MessageDialog("Your choices must be unique.");
                    await dialog.ShowAsync();
                }
            }
            else
            {
                dialog = new Windows.UI.Popups.MessageDialog("Do not leave any of the fields empty.");
                await dialog.ShowAsync();
            }
        }
    }
}

