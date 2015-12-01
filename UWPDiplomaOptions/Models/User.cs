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
    public class User
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public bool LockoutEnabled { get; set; }
        [DataMember]
        public string RoleName { get; set; }
    }

    public class UserManager
    {
        public static async Task GetUsers(ObservableCollection<User> UserList)
        {
            var http = new HttpClient();
            var response = await http.GetAsync("http://uwproject.feifei.ca/api/ApplicationUsers");
            var result = await response.Content.ReadAsStringAsync();

            JsonValue value = JsonValue.Parse(result);
            JsonArray root = value.GetArray();
            for (uint i = 0; i < root.Count; i++)
            {
                string id = root.GetObjectAt(i).GetNamedString("Id");
                string userName = root.GetObjectAt(i).GetNamedString("UserName");
                bool lockout = root.GetObjectAt(i).GetNamedBoolean("LockoutEnabled");
                string role = root.GetObjectAt(i).GetNamedString("RoleName");
                var user = new User
                {
                    Id = id,
                    UserName = userName,
                    LockoutEnabled = lockout,
                    RoleName = role
                };
                UserList.Add(user);
            }
        }

        public static async Task DeleteUser(string idToBeDeleted, ObservableCollection<User> UsersList)
        {
            var http = new HttpClient();
            var response = await http.DeleteAsync("http://uwproject.feifei.ca/api/ApplicationUsers/" + idToBeDeleted);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                JsonValue value = JsonValue.Parse(result);
                User user = JsonConvert.DeserializeObject<User>(value.ToString());
                UsersList.Remove(user);
            }
            else
            {
                var dialog = new Windows.UI.Popups.MessageDialog("Cannot delete record");
                await dialog.ShowAsync();
            }
        }
    }
}
