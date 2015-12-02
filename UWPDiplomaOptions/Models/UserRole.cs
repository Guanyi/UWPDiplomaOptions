using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace UWPDiplomaOptions.Models
{
    [DataContract]
    public class UserRole
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Name { get; set; }
    }

    public class UserRoleManager
    {
        public static HttpClient http = new HttpClient();
        public static async Task GetUserRoles(ObservableCollection<UserRole> UserRoleList)
        {
            var response = await http.GetAsync("http://uwproject.feifei.ca/api/ApplicationRoles");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();

                JsonValue value = JsonValue.Parse(result);
                JsonArray root = value.GetArray();
                for (uint i = 0; i < root.Count; i++)
                {
                    string id = root.GetObjectAt(i).GetNamedString("Id");
                    string name = root.GetObjectAt(i).GetNamedString("Name");
                    var userRole = new UserRole
                    {
                        Id = id,
                        Name = name
                    };
                    UserRoleList.Add(userRole);
                }
            }
            else
            {
                var dialog = new Windows.UI.Popups.MessageDialog("Cannot retrieve any record");
                await dialog.ShowAsync();
            }
        }

        public static async Task AddUserRole(StringContent userRoleJson, ObservableCollection<UserRole> UserRoleList)
        {
            var response = await http.PostAsync("http://uwproject.feifei.ca/api/ApplicationRoles", userRoleJson);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                JsonValue value = JsonValue.Parse(result);
                UserRole userRole = JsonConvert.DeserializeObject<UserRole>(value.ToString());
                UserRoleList.Add(userRole);
            }
            else
            {
                var dialog = new Windows.UI.Popups.MessageDialog("Cannot add record");
                await dialog.ShowAsync();
            }
        }

        public static async Task EditUserRole(StringContent optionJsonToBeEdited, UserRole updatedUserRole, ObservableCollection<UserRole> UserRoleList)
        {
            string requestUri = "http://uwproject.feifei.ca/api/ApplicationRoles/" + updatedUserRole.Id;
            var response = await http.PutAsync(requestUri, optionJsonToBeEdited);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                UserRole currentUserRole = UserRoleList.FirstOrDefault(o => o.Id == updatedUserRole.Id);
                currentUserRole = updatedUserRole;
            }
            else
            {
                var dialog = new Windows.UI.Popups.MessageDialog("Cannot edit record");
                await dialog.ShowAsync();
            }
        }

        public static async Task DeleteUserRole(string idToBeDeleted, ObservableCollection<UserRole> UserRoleList)
        {
            var response = await http.DeleteAsync("http://uwproject.feifei.ca/api/ApplicationRoles/" + idToBeDeleted);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                JsonValue value = JsonValue.Parse(result);
                UserRole userRole = JsonConvert.DeserializeObject<UserRole>(value.ToString());
                UserRoleList.Remove(userRole);
            }
            else
            {
                var dialog = new Windows.UI.Popups.MessageDialog("Cannot delete record");
                await dialog.ShowAsync();
            }
        }
    }
}
