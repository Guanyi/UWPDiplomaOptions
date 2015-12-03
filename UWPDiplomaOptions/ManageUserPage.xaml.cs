using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
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
    public sealed partial class ManageUserPage : Page
    {
        public ObservableCollection<User> Users;

        public ManageUserPage()
        {
            Users = new ObservableCollection<User>();
            this.InitializeComponent();
        }

        private async void Page_Loading(FrameworkElement sender, object args)
        {
            var obj = App.Current as App;
            //AccessToken = obj.AccessToken;
            UserManager.http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", obj.AccessToken);
            await UserManager.GetUsers(Users);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            string id = button.Tag.ToString();
            await UserManager.DeleteUser(id, Users);
            Frame.Navigate(typeof(ManageUserPage));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
