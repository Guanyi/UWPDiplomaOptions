using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization.Json;
using System.Text;
using UWPDiplomaOptions.Models;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPDiplomaOptions
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ManageOptionPage : Page
    {
        public ObservableCollection<Option> Options;
        public string AccessToken { get; set; }
        public ManageOptionPage()
        {
            Options = new ObservableCollection<Option>();
            this.InitializeComponent();
        }

        private async void AddOption_Click(object sender, RoutedEventArgs e)
        {
            if (OptionTitleWillBeAdded.Text != "")
            {
                bool active = ((string)OptionActiveWillBeAdded.SelectionBoxItem == "Yes") ? true : false;
                string title = OptionTitleWillBeAdded.Text;
                var obj = new { Title = title, IsActive = active };
                await OptionManager.AddOption(new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json"), Options);
            }
        }

        private async void DeleteOption_Click(object sender, RoutedEventArgs e)
        {
            if(OptionIdWillBeDeleted.Text != "")
            {
                string id = OptionIdWillBeDeleted.Text;
                await OptionManager.DeleteOption(id, Options);
            }
        }

        private async void EditOption_Click(object sender, RoutedEventArgs e)
        {
            int id;
            if (OptionIdWillBeEdited.Text != "" && OptionTitleWillBeEdited.Text != "" && Int32.TryParse(OptionIdWillBeEdited.Text, out id))
            {
                string title = OptionTitleWillBeEdited.Text;
                bool active = ((string)OptionActiveWillBeEdited.SelectionBoxItem == "Yes") ? true : false;
                var obj = new Option() { OptionId = id, Title = title, IsActive = active };
                await OptionManager.EditOption(new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json"), obj, Options);
            }
        }

        private async void Page_Loading(FrameworkElement sender, object accessToken)
        {
            OptionLoadingProessRing.IsActive = true;
            OptionLoadingProessRing.Visibility = Visibility.Visible;

            var obj = App.Current as App;
            AccessToken = obj.AccessToken;
            OptionManager.http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", obj.AccessToken);
            await OptionManager.GetOptions(Options);

            OptionLoadingProessRing.IsActive = false;
            OptionLoadingProessRing.Visibility = Visibility.Collapsed;
        }
    }
}
