using MVVM_API_SampleProject.Models;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace MVVM_API_SampleProject.Services;

public class PostService
{
    private readonly HttpClient client;

    private readonly JsonSerializerOptions _serializerOptions;
    private readonly string baseUrl = "https://jsonplaceholder.typicode.com";

    public PostService()
    {
        client = new HttpClient();
        _serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public async Task<ObservableCollection<Post>> GetAllPostsAsync()
    {
        var url = $"{baseUrl}/posts";
        try
        {
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ObservableCollection<Post>>(content, _serializerOptions);
            }
            return new ObservableCollection<Post>();

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw new Exception("Erro não esperado");
        }
    }
}
