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
    public sealed partial class ManageYearTermPage : Page
    {
        public ObservableCollection<YearTerm> YearTerms;
        public ManageYearTermPage()
        {
            YearTerms = new ObservableCollection<YearTerm>();
            this.InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var obj = App.Current as App;
            //AccessToken = obj.AccessToken;
            YearTermManager.http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", obj.AccessToken);
            await YearTermManager.GetYearTerms(YearTerms);
        }

        private async void AddYearTerm_Click(object sender, RoutedEventArgs e)
        {
            string year = (string)YearWillBeAdded.SelectionBoxItem;
            string term = (string)TermWillBeAdded.SelectionBoxItem;
            bool isDefault = ((string)YearTermIsDefaultWillBeAdded.SelectionBoxItem == "Yes") ? true : false;
            var obj = new { Year = year, Term = term, IsDefault = isDefault };
            await YearTermManager.AddYearTerm(new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json"), YearTerms);
            Frame.Navigate(typeof(ManageYearTermPage));
        }

        private async void EditYearTerm_Click(object sender, RoutedEventArgs e)
        {
            int id;
            if (YearTermIdWillBeEdited.Text != "" && Int32.TryParse(YearTermIdWillBeEdited.Text, out id))
            {
                int year = Int32.Parse( (string)YearWillBeEdited.SelectionBoxItem );
                int term = Int32.Parse( (string)TermWillBeEdited.SelectionBoxItem );
                bool isDefault = ((string)YearTermIsDefaultWillBeEdited.SelectionBoxItem == "Yes") ? true : false;
                var obj = new YearTerm() { YearTermId = id, Year = year, Term = term, IsDefault = isDefault };
                await YearTermManager.EditYearTerm(new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json"), obj, YearTerms);
                Frame.Navigate(typeof(ManageYearTermPage));
            }
        }

        private async void DeleteYearTerm_Click(object sender, RoutedEventArgs e)
        {
            int id;
            if (YearTermIdWillBeDeleted.Text != "" && Int32.TryParse(YearTermIdWillBeDeleted.Text, out id))
            {
                await YearTermManager.DeleteYearTerm(id.ToString(), YearTerms);
                Frame.Navigate(typeof(ManageYearTermPage));
            }
 
        }
    }
}
