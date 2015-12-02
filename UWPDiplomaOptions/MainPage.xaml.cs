using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPDiplomaOptions
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public int show_visibility;
        public MainPage()
        {
            var obj = App.Current as App;
            obj.roleToken = "";
            this.InitializeComponent();
            MainFrame.Navigate(typeof(LoginPage));
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            var obj = App.Current as App;

            if (obj.roleToken == "")
            {
                MainFrame.Navigate(typeof(LoginPage));
            }
            else if (obj.roleToken == "Admin")
            {
                Reload_Visibility();
                MainFrame.Navigate(typeof(ManageChoicePage));
            }
            else if (obj.roleToken == "Student")
            {
                Reload_Visibility();
                MainFrame.Navigate(typeof(HomePage));
            }
        }

        private void LogOffButton_Click(object sender, RoutedEventArgs e)
        {
            var obj = App.Current as App;
            obj.roleToken = "";
            Reload_Visibility();
            MainFrame.Navigate(typeof(LoginPage));
        }

        private void ManageOptionButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(ManageOptionPage));
        }

        private void ManageYearTermButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(ManageYearTermPage));
        }

        private void ManageUserRoleButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(ManageUserRolePage));
        }

        private void ManageChoiceButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(ManageChoicePage));
        }

        private void ManageUserButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(ManageUserPage));
        }

        private void Page_Loading(FrameworkElement sender, object args)
        {
            Reload_Visibility();
        }

        private void Reload_Visibility()
        {
            var obj = App.Current as App;
 
            if (show_visibility == 1)
            {
                HomeButton.Visibility = Visibility.Collapsed;
                ManageChoiceButton.Visibility = Visibility.Collapsed;
                ManageOptionButton.Visibility = Visibility.Collapsed;
                ManageYearTermButton.Visibility = Visibility.Collapsed;
                ManageUserRoleButton.Visibility = Visibility.Collapsed;
                ManageUserButton.Visibility = Visibility.Collapsed;
                LogOffButton.Visibility = Visibility.Collapsed;
                show_visibility = 0;
                NavButton.Content = "Show Navigation";
            }
            else if (obj.roleToken == "Student")
            {
                NavButton.Content = "Hide Navigation";
                show_visibility = 1;
                HomeButton.Visibility = Visibility.Visible;
                LogOffButton.Visibility = Visibility.Visible;
            }
            else if (obj.roleToken == "Admin")
            {
                NavButton.Content = "Hide Navigation";
                show_visibility = 1;
                HomeButton.Visibility = Visibility.Visible;
                ManageChoiceButton.Visibility = Visibility.Visible;
                ManageOptionButton.Visibility = Visibility.Visible;
                ManageYearTermButton.Visibility = Visibility.Visible;
                ManageUserRoleButton.Visibility = Visibility.Visible;
                ManageUserButton.Visibility = Visibility.Visible;
                LogOffButton.Visibility = Visibility.Visible;
            }
            else if (obj.roleToken == "")
            {
                HomeButton.Visibility = Visibility.Collapsed;
                ManageChoiceButton.Visibility = Visibility.Collapsed;
                ManageOptionButton.Visibility = Visibility.Collapsed;
                ManageYearTermButton.Visibility = Visibility.Collapsed;
                ManageUserRoleButton.Visibility = Visibility.Collapsed;
                ManageUserButton.Visibility = Visibility.Collapsed;
                LogOffButton.Visibility = Visibility.Collapsed;
            }
        }

        private void NavButton_Click(object sender, RoutedEventArgs e)
        {
            Reload_Visibility();
        }
    }
}
