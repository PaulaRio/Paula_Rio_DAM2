using Pokemon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pokemon.Utils
{
    public static class HttpJsonClient<T>
    {
        
        public static async Task<T?> GetMyApi(string path)
           {
             try
             {
                using HttpClient httpClient = new HttpClient();
                {
                HttpResponseMessage datos = await httpClient.GetAsync($"{Constantes.BASE_URL}{path}");
                string dataget = await datos.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(dataget);
                }
             }
             catch (Exception ex)
             {
                Console.WriteLine(ex.Message);
             }
            return default;
           }
        public static async Task<T?> GetPokeApi(string url)
        {
            try
            {
                using HttpClient httpClient = new HttpClient();
                {
                    HttpResponseMessage datos = await httpClient.GetAsync(url);
                    string dataget = await datos.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<T>(dataget);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return default;
        }
        public static async Task<T?> Post<T>(string path, T data)
        {
            try
            {
                using HttpClient httpClient = new HttpClient();
                
                string jsonData = JsonSerializer.Serialize(data);

                
                using StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                
                HttpResponseMessage response = await httpClient.PostAsync($"{Constantes.BASE_URL}{path}", content);

                if (response.IsSuccessStatusCode)
                {
                    
                    string responseContent = await response.Content.ReadAsStringAsync();
                    
                    return JsonSerializer.Deserialize<T>(responseContent);
                }
               
                return default;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la solicitud POST: {ex.Message}");
            }

            return default;
        }


    }
}
