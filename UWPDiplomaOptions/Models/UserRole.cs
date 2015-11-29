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
        public static async Task GetUserRoles(ObservableCollection<UserRole> UserRoleList)
        {
            var http = new HttpClient();
            var response = await http.GetAsync("http://uwproject.feifei.ca/api/ApplicationRoles");
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
    }
}
