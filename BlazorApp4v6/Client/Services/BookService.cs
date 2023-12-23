using BlazorApp4v6.Shared.Models;
using System.Net.Http.Json;

namespace BlazorApp4v6.Client.Services
{

    public class BookService : IBookService
    {
        private readonly HttpClient _http;
        public BookService(HttpClient http)
        {
            _http = http;
        }
        public async Task<bool> AddBook(BookUI bookDTO)
        {
            var result = await _http.PostAsJsonAsync("api/book", bookDTO);
            if (result.IsSuccessStatusCode)
            {
                // Optional: Handle the successful response (e.g., parse response content or handle the added book).
                return true;
            }
            else
            {
                // Handle the case where the request was not successful (e.g., log an error or throw an exception).
                //throw new Exception("Failed to add the book.");
                return false;
            }
        }

        public async Task<bool> DeleteBook(int Id)
        {
            var result = await _http.DeleteAsync($"api/book?id={Id}");

            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<BookUI>> GetAllBooks()
        {
            var result = await _http.GetFromJsonAsync<List<BookUI>>("/api/book");
            if (result != null)
                return result;
            throw new Exception("NotFound");
        }

        public async Task<BookUI> GetBookId(int? Id)
        {
            var result = await _http.GetFromJsonAsync<BookUI>($"api/book/{Id}");
            if (result != null)
                return result;
            throw new Exception("NotFound");
        }

        public async Task<bool> UpdateBook(BookUI bookDTO)
        {
            var result = await _http.PutAsJsonAsync($"api/book?id={bookDTO.Id}", bookDTO);
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
