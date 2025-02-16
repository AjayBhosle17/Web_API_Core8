public interface IHttpCLientService
{

    Task<T> GetAll<T>(string requestUri);
    Task<T> GetById<T>(string requestUri); // Add this for fetching by ID

    Task<T> Post<T>(string requestUri , object content);

    Task Put(string requestUri , object content);

    Task Delete(string requestUri);
}
