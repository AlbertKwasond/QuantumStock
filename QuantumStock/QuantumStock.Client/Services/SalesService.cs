using QuantumStock.Shared.Response;
using System.Net.Http.Json;

namespace QuantumStock.Client.Services
{
    public class SalesService
    {
        private readonly HttpClient _httpClient;

        public SalesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<SalesListResponse> GetSalesList(DateTime searchFromDate, DateTime searchToDate)
        {
            return await _httpClient.GetFromJsonAsync<SalesListResponse>($"api/SalesLists/{searchFromDate:yyyy-MM-dd},{searchToDate:yyyy-MM-dd}");
        }
    }
}