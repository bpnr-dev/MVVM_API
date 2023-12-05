using MVVM_API_SampleProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MVVM_API_SampleProject.Services
{
    public class TodoService
    {
        private readonly HttpClient client;

        private readonly JsonSerializerOptions _serializerOptions;
        private readonly string baseUrl = "https://jsonplaceholder.typicode.com";

        public TodoService()
        {
            client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<ObservableCollection<Todo>> GetAllPostsAsync()
        {
            var url = $"{baseUrl}/posts";
            try
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<ObservableCollection<Todo>>(content, _serializerOptions);
                }
                return new ObservableCollection<Todo>();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception("Erro não esperado");
            }
        }
    }
}
