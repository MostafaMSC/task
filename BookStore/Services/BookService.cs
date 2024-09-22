using BookStore.Modules;

namespace BookStore.Services
{
    public class BookService
    {
        private readonly HttpClient _httpClient;

        public BookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7161/");
        }

        public async Task<HttpResponseMessage> AddBook(Books book)
        {
            try
            {
                // Ensure the API URL matches the controller route
                var response = await _httpClient.PostAsJsonAsync("api/Books", book);
                response.EnsureSuccessStatusCode(); // This will throw if the response status is not successful
                return response;
            }
            catch (HttpRequestException ex)
            {
                // Log or handle the exception
                Console.WriteLine($"Request error: {ex.Message}");
                throw;
            }
        }


    }
}

