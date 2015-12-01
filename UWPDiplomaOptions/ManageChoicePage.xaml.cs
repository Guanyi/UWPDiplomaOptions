using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
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
    public sealed partial class ManageChoicePage : Page
    {
        public ObservableCollection<Choice> Choices;
        public ObservableCollection<Option> Options;
        public ObservableCollection<YearTerm> YearTerms;
        string selectionDate;

        public ManageChoicePage()
        {
            Choices = new ObservableCollection<Choice>();
            Options = new ObservableCollection<Option>();
            YearTerms = new ObservableCollection<YearTerm>();
            this.InitializeComponent();
        }

        private async void Page_Loading(FrameworkElement sender, object args)
        {
            await ChoiceManager.GetChoices(Choices);
            await OptionManager.GetOptions(Options);
            await YearTermManager.GetYearTerms(YearTerms);
            LoadComboBoxes();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            string id = button.Tag.ToString();
            await ChoiceManager.DeleteChoice(id, Choices);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            string id = button.Tag.ToString();
            Choice choice = Choices.Where(c => c.ChoiceId == Convert.ToInt16(id)).Select(c => c).FirstOrDefault();
            txtId.Text = id;
            txtStudentId.Text = choice.StudentId;
            txtFName.Text = choice.StudentFirstName;
            txtLName.Text = choice.StudentLastName;
            cbFirstChoice.SelectedValue = choice.FirstChoiceOptionTitle;
            cbSecondChoice.SelectedValue = choice.SecondChoiceOptionTitle;
            cbThirdChoice.SelectedValue = choice.ThirdChoiceOptionTitle;
            cbFourthChoice.SelectedValue = choice.FourthChoiceOptionTitle;
            cbYear.SelectedValue = choice.Year;
            cbTerm.SelectedValue = choice.Term;
        }

        private async void EditChoice_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt16(txtId.Text);
            if (txtId.Text != "" && txtStudentId.Text != "" && txtFName.Text != "" && txtLName.Text != "")
            {
                string studentId = txtStudentId.Text;
                string fName = txtFName.Text;
                string lName = txtLName.Text;
                int firstChoice = Options.Where(o => o.Title == cbFirstChoice.SelectedValue.ToString()).Select(o => o).FirstOrDefault().OptionId;
                int secondChoice = Options.Where(o => o.Title == cbSecondChoice.SelectedValue.ToString()).Select(o => o).FirstOrDefault().OptionId;
                int thirdChoice = Options.Where(o => o.Title == cbThirdChoice.SelectedValue.ToString()).Select(o => o).FirstOrDefault().OptionId;
                int fourthChoice = Options.Where(o => o.Title == cbFourthChoice.SelectedValue.ToString()).Select(o => o).FirstOrDefault().OptionId;

                int yearTerm = YearTerms.Where(y => y.Term == Convert.ToInt16(cbTerm.SelectedValue) && y.Year == Convert.ToInt16(cbYear.SelectedValue)).Select(y => y).FirstOrDefault().YearTermId;
                selectionDate = Choices.Where(c => c.ChoiceId == Convert.ToInt16(id)).Select(c => c).FirstOrDefault().SelectionDate;

                var choice = new Choice() { ChoiceId = id, StudentId = studentId, StudentFirstName = fName, StudentLastName = lName, FirstChoiceOptionTitle = cbFirstChoice.SelectedValue.ToString(), SecondChoiceOptionTitle = cbSecondChoice.SelectedValue.ToString(), ThirdChoiceOptionTitle = cbThirdChoice.SelectedValue.ToString(), FourthChoiceOptionTitle = cbFourthChoice.SelectedValue.ToString(), Year = Convert.ToInt16(cbYear.SelectedValue), Term = Convert.ToInt16(cbTerm.SelectedValue), SelectionDate = selectionDate };
                var obj = new { StudentId = studentId, StudentFirstName = fName, StudentLastName = lName, FirstChoiceOptionId = firstChoice, SecondChoiceOptionId = secondChoice, ThirdChoiceOptionId = thirdChoice, FourthChoiceOptionId = fourthChoice, YearTermId = yearTerm, SelectionDate = selectionDate };

                await ChoiceManager.EditChoice(new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json"), choice, Choices);
            }
        }

        private void LoadComboBoxes()
        {
            cbFirstChoice.Items.Clear();
            cbSecondChoice.Items.Clear();
            cbThirdChoice.Items.Clear();
            cbFourthChoice.Items.Clear();
            cbYear.Items.Clear();
            cbTerm.Items.Clear();

            foreach (Option option in Options)
            {
                cbFirstChoice.Items.Add(option.Title);
                cbSecondChoice.Items.Add(option.Title);
                cbThirdChoice.Items.Add(option.Title);
                cbFourthChoice.Items.Add(option.Title);
            }

            foreach (YearTerm yearTerm in YearTerms)
            {
                cbYear.Items.Add(yearTerm.Year);
                cbTerm.Items.Add(yearTerm.Term);
            }

            cbFirstChoice.SelectedIndex = 0;
            cbSecondChoice.SelectedIndex = 0;
            cbThirdChoice.SelectedIndex = 0;
            cbFourthChoice.SelectedIndex = 0;
            cbYear.SelectedIndex = 0;
            cbTerm.SelectedIndex = 0;
        }
    }
}
