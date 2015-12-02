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
    public sealed partial class ManageUserRolePage : Page
    {
        public ObservableCollection<UserRole> UserRoles;
        public ManageUserRolePage()
        {
            UserRoles = new ObservableCollection<UserRole>();
            this.InitializeComponent();
        }

        private async void AddUserRole_Click(object sender, RoutedEventArgs e)
        {
            if (UserRoleNameWillBeAdded.Text != "")
            {
                string name = UserRoleNameWillBeAdded.Text;
                var obj = new { Name = name };
                await UserRoleManager.AddUserRole(new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json"), UserRoles);
            }
        }

        private async void EditUserRole_Click(object sender, RoutedEventArgs e)
        {
            if (UserRoleIdWillBeEdited.Text != "" && UserRoleNameWillBeEdited.Text != "")
            {
                string id = UserRoleIdWillBeEdited.Text;
                string name = UserRoleNameWillBeEdited.Text;
                var userRole = new UserRole() { Id = id.ToString(), Name = name};
                await UserRoleManager.EditUserRole(new StringContent(JsonConvert.SerializeObject(userRole), Encoding.UTF8, "application/json"), userRole, UserRoles);
            }
        }

        private async void DeleteUserRole_Click(object sender, RoutedEventArgs e)
        {
            if (UserRoleIdWillBeDeleted.Text != "")
            {
                string id = UserRoleIdWillBeDeleted.Text;
                await UserRoleManager.DeleteUserRole(id, UserRoles);
            }
        }

        private async void Page_Loading(FrameworkElement sender, object args)
        {
            UserRoleLoadingProessRing.IsActive = true;
            UserRoleLoadingProessRing.Visibility = Visibility.Visible;
            var obj = App.Current as App;
            //AccessToken = obj.AccessToken;
            UserRoleManager.http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", obj.AccessToken);
            await UserRoleManager.GetUserRoles(UserRoles);
            UserRoleLoadingProessRing.IsActive = false;
            UserRoleLoadingProessRing.Visibility = Visibility.Collapsed;
        }
    }
}
