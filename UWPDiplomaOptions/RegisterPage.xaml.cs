using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using UWPDiplomaOptions.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Collections.ObjectModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPDiplomaOptions
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegisterPage : Page
    {
        public ObservableCollection<User> UserList;
        public RegisterPage()
        {
            UserList = new ObservableCollection<User>();
            this.InitializeComponent();
        }

        private async void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            int invalid = 0;
            if (!Regex.IsMatch(StudentNumberBox.Text, @"^[A-a][0][0][0-9]{6}$"))
            {
                invalid = 1;
            }
            if (invalid != 1)
            {
                if(StudentNumberBox.Text != "" && EmailBox.Text != "" && PasswordBox.Password != "" && ConfirmPasswordBox.Password != "")
                {
                    var obj = new { UserName = StudentNumberBox.Text, Email = EmailBox.Text, Password = PasswordBox.Password, ConfirmPassword = ConfirmPasswordBox.Password };
                    await UserManager.AddUser(new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json"), UserList);
                    Frame.Navigate(typeof(LoginPage));
                }
            }
        }

        private async void Page_Loading(FrameworkElement sender, object args)
        {
            await UserManager.GetUsers(UserList);
        }
    }
}
