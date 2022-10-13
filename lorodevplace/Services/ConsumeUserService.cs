using lorodevplace.Models;
using lorodevplace.Services.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace lorodevplace.Services
{
    public class ConsumeUserService : IConsumeUserService
    {
        private readonly string URLbase = "https://localhost:7095/api";
        private HttpClient _httpclient;


        public async Task<UserLoginDto> Login(UserLoginDto a)
        {
            try
            {
                _httpclient = new HttpClient();
                _httpclient.BaseAddress = new Uri($"{URLbase}/Auth/Login");
                string contentType = "application/json";

                _httpclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));
                HttpResponseMessage response;
                var _method = new HttpMethod("POST");
                string myObjectAsJSON = JsonConvert.SerializeObject(a);

                HttpContent _body = new StringContent(myObjectAsJSON);
                _body.Headers.ContentType = new MediaTypeHeaderValue(contentType);
                var uri = _httpclient.BaseAddress;
                response = await _httpclient.PostAsync(uri, _body);
                UserLoginDto resultado = null;
                if (response.IsSuccessStatusCode)
                {
                    string responseContentstring = await _body.ReadAsStringAsync();
                    resultado = JsonConvert.DeserializeObject<UserLoginDto>(responseContentstring);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }




    }
}
