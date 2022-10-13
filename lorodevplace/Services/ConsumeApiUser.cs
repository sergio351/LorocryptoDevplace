using lorodevplace.Models;
using lorodevplace.Services.Interfaces;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace lorodevplace.Services
{
    public class ConsumeApiUser : IConsumeApiUser
    {
        private readonly string URLbase = "https://localhost:7095/api";
        private HttpClient _httpclient;

        // AUTH

        #region Login
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
        #endregion

        #region Register
        public async Task<UserRegisterDto> Register(UserRegisterDto user)
        {
            try
            {
                _httpclient = new HttpClient();
                _httpclient.BaseAddress = new Uri($"{URLbase}/Auth/Register");
                string contentType = "application/json";

                _httpclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));
                HttpResponseMessage response;
                var _method = new HttpMethod("POST");
                string myObjectAsJSON = JsonConvert.SerializeObject(user);

                HttpContent _body = new StringContent(myObjectAsJSON);
                _body.Headers.ContentType = new MediaTypeHeaderValue(contentType);
                var uri = _httpclient.BaseAddress;
                response = await _httpclient.PostAsync(uri, _body);
                UserRegisterDto resultado = null;
                if (response.IsSuccessStatusCode)
                {
                    string responseContentstring = await _body.ReadAsStringAsync();
                    resultado = JsonConvert.DeserializeObject<UserRegisterDto>(responseContentstring);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        // USER
        // Falta hacer update - delete - getbyid
    }
}
