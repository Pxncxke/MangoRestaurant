﻿using Mango.Web.Models;
using Mango.Web.Services.IServices;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Mango.Web.Services
{
    public class BaseService : IBaseService
    {
        public ResponseDto responseModel { get; set; }
        public IHttpClientFactory httpClientFactory { get; set; }

        public BaseService(IHttpClientFactory httpClient)
        {
            this.responseModel = new ResponseDto();
            this.httpClientFactory = httpClient;
        }


        public void Dispose()
        {
           GC.SuppressFinalize(true);
        }

        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = httpClientFactory.CreateClient("MangoAPI");
                HttpRequestMessage message = new();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);
                client.DefaultRequestHeaders.Clear();
                if(apiRequest.Data is not null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data), Encoding.UTF8, "application/json");
                }

                if (!String.IsNullOrEmpty(apiRequest.AccesToken))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiRequest.AccesToken);
                }

                HttpResponseMessage apiResponse = null;

                message.Method = apiRequest.Apitype switch
                {
                    SD.ApiType.POST => HttpMethod.Post,
                    SD.ApiType.PUT => HttpMethod.Put,
                    SD.ApiType.DELETE => HttpMethod.Delete,
                    _ => HttpMethod.Get,
                };


                apiResponse = await client.SendAsync(message);

                var apiContent = await apiResponse.Content.ReadAsStringAsync();

                var apiResponseDto = JsonConvert.DeserializeObject<T>(apiContent);

                return apiResponseDto;
                //switch (apiRequest.Apitype)
                //{
                //    case SD.ApiType.POST:
                //        message.Method = HttpMethod.Post;
                //        break;
                //    case SD.ApiType.PUT:
                //        message.Method = HttpMethod.Put;
                //        break;
                //    case SD.ApiType.DELETE:
                //        message.Method = HttpMethod.Delete;
                //        break;

                //    default:
                //        message.Method = HttpMethod.Get;
                //        break;

                //}


            }
            catch(Exception ex)
            {
                var dto = new ResponseDto
                {
                    DisplayMessage = "Error",
                    ErrorMessages = new List<string> { Convert.ToString(ex.Message) },
                    IsSuccess = false
                };
                var res = JsonConvert.SerializeObject(dto);
                var apiResponseDto = JsonConvert.DeserializeObject<T>(res);
                return apiResponseDto;
            }
        }
    }
}
