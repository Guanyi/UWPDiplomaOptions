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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPDiplomaOptions
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        public ObservableCollection<User> Users;
        public LoginPage()
        {
            Users = new ObservableCollection<User>();
            this.InitializeComponent();
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var obj = App.Current as App;
            obj.roleToken = "";
            string loginName = StudentNumberBox.Text;
            if (loginName == "" || loginName.Length != 9 || !loginName.StartsWith("A00") || PasswordBox.Password == "")
            {
                var dialog = new Windows.UI.Popups.MessageDialog("Login Name or password not in valid format.");
                await dialog.ShowAsync();
            }
            else
            {
                var loginCredential = new Dictionary<string, string>
                {
                    {"grant_type", "password"},
                    {"username", loginName},
                    {"password", PasswordBox.Password},
                };
                var http = new HttpClient();
                var authorizationHeader = Convert.ToBase64String(Encoding.UTF8.GetBytes("secretKey"));
                http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authorizationHeader);

                LoginProessRing.IsActive = true;
                LoginProessRing.Visibility = Visibility.Visible;

                var response = await http.PostAsync("http://uwproject.feifei.ca/token", new FormUrlEncodedContent(loginCredential));
                LoginProessRing.IsActive = false;
                LoginProessRing.Visibility = Visibility.Collapsed;

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var jObject = JsonObject.Parse(result);
                    string token = jObject.GetNamedString("access_token");

<<<<<<< HEAD
                    obj.AccessToken = token;
                    UserManager.http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", obj.AccessToken);

                    await UserManager.GetUsers(Users);

                    foreach (var userLogin in Users)
                    {
                        if (userLogin.UserName == loginName)
                        {
                            obj.roleToken = userLogin.RoleName;
                        }
                    }

                    if (obj.roleToken == "Student")
                    {
                        Frame.Navigate(typeof(HomePage));
                    }
                    else if (obj.roleToken == "Admin")
                    {
                        Frame.Navigate(typeof(ManageChoicePage));
                    }
=======
                    var obj = App.Current as App;
                    obj.AccessToken = token;

                    Frame.Navigate(typeof(HomePage));
>>>>>>> c9c33172a8f1f2297da6e3e0e17f1fa7c4916895
                }
                else
                {
                    var dialog = new Windows.UI.Popups.MessageDialog("Cannot authorize. Check your login name and password again.");
                    await dialog.ShowAsync();
                }
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RegisterPage));
        }
    }
}
