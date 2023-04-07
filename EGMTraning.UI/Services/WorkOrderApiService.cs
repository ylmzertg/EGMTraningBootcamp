using EGMTraning.Common.Dtos;
using EGMTraning.UI.Helpers;
using System.Net;
using System.Net.Http.Headers;

namespace EGMTraning.UI.Services
{
    public class WorkOrderApiService
    {
        private readonly HttpClient _httpClient;

        public WorkOrderApiService(HttpClient httpClient)
        {
            _httpClient=httpClient;
        }


        public async Task<List<WorkOrderDto>> GetAllWorkOrderAsync()
        {
            var helper = new TokenHelper(_httpClient);
            var auth = await helper.AuthenticateAsync();
            //  _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", auth.Token);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", auth.Token);

            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<WorkOrderDto>>>("/api/WorkOrder/GetWorkOrderList");
            if (response.StatusCode == (int) HttpStatusCode.OK)
                return response.Data;
            else
                return new List<WorkOrderDto>();
        }

    }
}
