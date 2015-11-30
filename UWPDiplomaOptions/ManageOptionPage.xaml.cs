using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
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
        public ManageOptionPage()
        {
            Options = new ObservableCollection<Option>();
            this.InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await OptionManager.GetOptions(Options);
        }

        private async void AddOption_Click(object sender, RoutedEventArgs e)
        {
            bool active =((string)Active.SelectionBoxItem == "Yes") ? true:  false;
            string title = OptionTitle.Text;
            var obj = new { Title = title, IsActive = active };
            await OptionManager.AddOption(new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json"), Options);
        }

        private void DeleteOption_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void DeleteCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            sender.GetHashCode();
        }
    }
}
