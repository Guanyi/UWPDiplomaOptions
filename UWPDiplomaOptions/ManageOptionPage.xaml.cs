using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
            //await OptionManager.GetOptions(Options);
        }

        private void AddOption_Click(object sender, RoutedEventArgs e)
        {
            string active =((string)Active.SelectionBoxItem == "Yes") ? "true":  "fasle";
            string title = OptionTitle.Text;
        }
    }
}
