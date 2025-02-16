using System.Net.Http.Json;

public class HttpClientService : IHttpCLientService
{
    private readonly HttpClient _client;

    public HttpClientService(IHttpClientFactory httpClientFactory)
    {
        _client = httpClientFactory.CreateClient("HttpClientService"); //  Correct way to get HttpClient
    }

    public async Task<T> GetAll<T>(string requestUri)
    {
       
            var response = await _client.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();   // deserialize    && <T> For Data   which type like List<Category> or Category
      
    }

    public async Task Delete(string requestUri)
    { 
        var response = await _client.DeleteAsync(requestUri);
        response.EnsureSuccessStatusCode();
        await response.Content.ReadAsStringAsync();
    }

    public async Task<T> Post<T>(string requestUri, object content)
    {
        var response = await _client.PostAsJsonAsync(requestUri, content);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<T>();
    }

    public async Task Put(string requestUri, object content)
    {
        var response = await _client.PutAsJsonAsync(requestUri,content);
        response.EnsureSuccessStatusCode();
        await response.Content.ReadAsStringAsync();
    }

    public async Task<T> GetById<T>(string requestUri)
    {
        var response = await _client.GetAsync(requestUri);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<T>();
    }

}
