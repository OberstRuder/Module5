using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using Newtonsoft.Json;

namespace HW1_requests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SendAsync().GetAwaiter().GetResult();
        }

        static async Task SendAsync()
        {
            //1
            using (var httpClient = new HttpClient())
            {
                var result = await httpClient.GetAsync(@"https://reqres.in/api/users?page=2");
                if (result.IsSuccessStatusCode)
                {
                    var info = await result.Content.ReadAsStringAsync();
                    var infoObj = JsonConvert.DeserializeObject<ResponseTask1>(info);
                    Console.WriteLine($"{(int)result.StatusCode}, {infoObj.Data.Count}");
                }
                else
                {
                    Console.WriteLine(($"{(int)result.StatusCode}, error"));
                }
            }
            //2
            using (var httpClient = new HttpClient())
            {
                var result = await httpClient.GetAsync(@"https://reqres.in/api/users/2");
                if (result.IsSuccessStatusCode)
                {
                    var info = await result.Content.ReadAsStringAsync();
                    var user = JsonConvert.DeserializeObject<ResponseTask2>(info);
                    Console.WriteLine($"{(int)result.StatusCode}, {user.Data.Id}, {user.Data.Email}, {user.Data.First_Name}, {user.Data.Last_Name}");

                }
                else
                {
                    Console.WriteLine(($"{(int)result.StatusCode}, error"));
                }
            }
            //3
            using (var httpClient = new HttpClient())
            {
                var result = await httpClient.GetAsync(@"https://reqres.in/api/users/23");
                if (result.IsSuccessStatusCode)
                {
                    var info = await result.Content.ReadAsStringAsync();
                }
                else
                {
                    Console.WriteLine($"{(int)result.StatusCode}, error");
                }
            }
            //4
            using (var httpClient = new HttpClient())
            {
                var result = await httpClient.GetAsync(@"https://reqres.in/api/unknown");
                if (result.IsSuccessStatusCode)
                {
                    var info = await result.Content.ReadAsStringAsync();
                    var infoObj = JsonConvert.DeserializeObject<ResponseTask4>(info);
                    Console.WriteLine($"{(int)result.StatusCode}, {infoObj.Data.Count}");
                }
                else
                {
                    Console.WriteLine($"{(int)result.StatusCode}, error");
                }
            }
            //5
            using (var httpClient = new HttpClient())
            {
                var result = await httpClient.GetAsync(@"https://reqres.in/api/unknown/2");
                if (result.IsSuccessStatusCode)
                {
                    var info = await result.Content.ReadAsStringAsync();
                    var resource = JsonConvert.DeserializeObject<ResponseTask5>(info);
                    Console.WriteLine($"{(int)result.StatusCode}, {resource.Data.Id}, {resource.Data.Name}, {resource.Data.Year}, {resource.Data.Color}, {resource.Data.Pantone_value}");

                }
                else
                {
                    Console.WriteLine($"{(int)result.StatusCode} , error");
                }
            }
            //6
            using (var httpClient = new HttpClient())
            {
                var result = await httpClient.GetAsync(@"https://reqres.in/api/unknown/23");
                if (result.IsSuccessStatusCode)
                {
                    var info = await result.Content.ReadAsStringAsync();
                }
                else
                {
                    Console.WriteLine($"{(int)result.StatusCode} , error");
                }
            }
            //7
            using (var httpClient = new HttpClient())
            {
                var user = new { Name = "morpheus", Job = "leader" };
                var httpContent = new StringContent(JsonConvert.SerializeObject(user), encoding: System.Text.Encoding.UTF8, "application/json");
                var result = await httpClient.PostAsync(@"https://reqres.in/api/users", httpContent);

                if (result.IsSuccessStatusCode)
                {
                    var response = await result.Content.ReadAsStringAsync();
                    Console.WriteLine($"{(int)result.StatusCode}, {JsonConvert.ToString(response)}");
                }
                else
                {
                    Console.WriteLine((int)result.StatusCode);
                }

            }
            //8
            using (var httpClient = new HttpClient())
            {
                var user = new { Name = "morpheus", Job = "zion resident" };
                var httpContent = new StringContent(JsonConvert.SerializeObject(user), encoding: System.Text.Encoding.UTF8, "application/json");
                var result = await httpClient.PutAsync(@"https://reqres.in/api/users/2", httpContent);

                if (result.IsSuccessStatusCode)
                {
                    var response = await result.Content.ReadAsStringAsync();
                    Console.WriteLine($"{(int)result.StatusCode}, {JsonConvert.ToString(response)}");
                }
                else
                {
                    Console.WriteLine((int)result.StatusCode);
                }
            }
            //9
            using (var httpClient = new HttpClient())
            {
                var user = new { Name = "morpheus", Job = "zion resident" };
                var httpContent = new StringContent(JsonConvert.SerializeObject(user), encoding: System.Text.Encoding.UTF8, "application/json");
                var result = await httpClient.PatchAsync(@"https://reqres.in/api/users/2", httpContent);

                if (result.IsSuccessStatusCode)
                {
                    var response = await result.Content.ReadAsStringAsync();
                    Console.WriteLine($"{(int)result.StatusCode}, {JsonConvert.ToString(response)}");
                }
                else
                {
                    Console.WriteLine((int)result.StatusCode);
                }
            }
            //10
            using (var httpClient = new HttpClient())
            {
                var result = await httpClient.DeleteAsync(@"https://reqres.in/api/users/2");
                Console.WriteLine($"{(int)result.StatusCode}, deleated");
            }
            //11
            using (var httpClient = new HttpClient())
            {
                var register = new { email = "eve.holt@reqres.in", password = "pistol" };
                var httpContent = new StringContent(JsonConvert.SerializeObject(register), encoding: System.Text.Encoding.UTF8, "application/json");
                var result = await httpClient.PostAsync(@"https://reqres.in/api/register", httpContent);

                if (result.IsSuccessStatusCode)
                {
                    var response = await result.Content.ReadAsStringAsync();
                    Console.WriteLine($"{(int)result.StatusCode}, {JsonConvert.ToString(response)}");
                }
                else
                {
                    Console.WriteLine((int)result.StatusCode);
                }
            }
            //12
            using (var httpClient = new HttpClient())
            {
                var register = new { email = "sydney@file"};
                var httpContent = new StringContent(JsonConvert.SerializeObject(register), encoding: System.Text.Encoding.UTF8, "application/json");
                var result = await httpClient.PostAsync(@"https://reqres.in/api/register", httpContent);
                var response = await result.Content.ReadAsStringAsync();
                Console.WriteLine($"{(int)result.StatusCode}, {JsonConvert.ToString(response)}");
            }
            //13
            using (var httpClient = new HttpClient())
            {
                var login = new { email = "eve.holt@reqres.in", password = "cityslicka" };
                var httpContent = new StringContent(JsonConvert.SerializeObject(login), encoding: System.Text.Encoding.UTF8, "application/json");
                var result = await httpClient.PostAsync(@"https://reqres.in/api/login", httpContent);

                if (result.IsSuccessStatusCode)
                {
                    var response = await result.Content.ReadAsStringAsync();
                    Console.WriteLine($"{(int)result.StatusCode}, {JsonConvert.ToString(response)}");
                }
                else
                {
                    Console.WriteLine((int)result.StatusCode);
                }
            }
            //14
            using (var httpClient = new HttpClient())
            {
                var login = new { email = "peter@klaven" };
                var httpContent = new StringContent(JsonConvert.SerializeObject(login), encoding: System.Text.Encoding.UTF8, "application/json");
                var result = await httpClient.PostAsync(@"https://reqres.in/api/login", httpContent);
                var response = await result.Content.ReadAsStringAsync();
                Console.WriteLine($"{(int)result.StatusCode}, {JsonConvert.ToString(response)}");
            }
            //15
            using (var httpClient = new HttpClient())
            {
                var result = await httpClient.GetAsync(@"https://reqres.in/api/users?delay=3");
                if (result.IsSuccessStatusCode)
                {
                    var info = await result.Content.ReadAsStringAsync();
                    var infoObj = JsonConvert.DeserializeObject<ResponseTask1>(info);
                    Console.WriteLine($"{(int)result.StatusCode}, {infoObj.Data.Count}");
                }
                else
                {
                    Console.WriteLine($"{(int)result.StatusCode}, error");
                }
            }
        }
    }
}