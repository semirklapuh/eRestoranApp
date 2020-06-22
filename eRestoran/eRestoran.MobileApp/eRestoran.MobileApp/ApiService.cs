using eRestoran.Model;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace eRestoran.MobileApp
{
    public class ApiService
    {
        private string _ruta;
        public static string username;
        public static string pass;

#if DEBUG
        private string apiUrl = "http://localhost:52089/api";
#endif

#if RELEASE
      private string apiUrl = "https://localhost:44360/api/";
#endif

        public ApiService(string ruta)
        {
            _ruta = ruta;
        }

        public async Task<T> Get<T>(object search)
        {
            var url = $"{apiUrl}/{_ruta}";
            try
            {
                if (search != null)
                {
                    url += "?";
                    url += await search.ToQueryString();
                }

                var result = await url.WithBasicAuth(username, pass).GetJsonAsync<T>();
                return result;
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Niste authentificirani", "OK");

                }
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.ServiceUnavailable)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška 503", "Problemi sa serverom!", "OK");

                }
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.NotFound)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška 404", "Resurs ne postoji!", "OK");

                }
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.InternalServerError)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška 500", "Problemi sa serverom!", "OK");

                }
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Forbidden)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška 403", "Nemate pravo pristupa!", "OK");

                }
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.BadRequest)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška 400", "Greška napravljena prema serveru!", "OK");

                }
                throw;
            }

        }
        public async Task<T> GetById<T>(int? id)
        {
            try
            {
                var url = $"{apiUrl}/{_ruta}/{id}";
                var result = await url.WithBasicAuth(username, pass).GetJsonAsync<T>();
                return result;
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Niste authentificirani", "OK");

                }
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.ServiceUnavailable)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška 503", "Problemi sa serverom!", "OK");

                }
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.NotFound)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška 404", "Resurs ne postoji!", "OK");

                }
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.InternalServerError)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška 500", "Problemi sa serverom!", "OK");

                }
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Forbidden)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška 403", "Nemate pravo pristupa!", "OK");

                }
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.BadRequest)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška 400", "Greška napravljena prema serveru!", "OK");

                }
                throw;
            }


        }

        public async Task<T> Insert<T>(object request)
        {
            try
            {
                var url = $"{apiUrl}/{_ruta}";
                return await url.WithBasicAuth(username, pass).PostJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Niste authentificirani", "OK");

                }
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.ServiceUnavailable)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška 503", "Problemi sa serverom!", "OK");

                }
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.NotFound)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška 404", "Resurs ne postoji!", "OK");

                }
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.InternalServerError)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška 500", "Problemi sa serverom!", "OK");

                }
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Forbidden)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška 403", "Nemate pravo pristupa!", "OK");

                }
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.BadRequest)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška 400", "Greška napravljena prema serveru!", "OK");

                }
                throw;
            }

        }





        public async Task<T> Update<T>(int? id, object request)
        {
            try
            {
                var url = $"{apiUrl}/{_ruta}/id?={id}";
                return await url.WithBasicAuth(username, pass).PutJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Niste authentificirani", "OK");

                }
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.ServiceUnavailable)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška 503", "Problemi sa serverom!", "OK");

                }
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.NotFound)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška 404", "Resurs ne postoji!", "OK");

                }
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.InternalServerError)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška 500", "Problemi sa serverom!", "OK");

                }
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Forbidden)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška 403", "Nemate pravo pristupa!", "OK");

                }
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.BadRequest)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška 400", "Greška napravljena prema serveru!", "OK");

                }
                throw;
            }

        }
        public async Task<HttpResponseMessage> Delete(object id)
        {
            try
            {
                var url = $"{apiUrl}/{_ruta}/id?={id}";

                return await url.WithBasicAuth(username, pass).DeleteAsync();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Niste authentificirani", "OK");

                }
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.ServiceUnavailable)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška 503", "Problemi sa serverom!", "OK");

                }
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.NotFound)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška 404", "Resurs ne postoji!", "OK");

                }
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.InternalServerError)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška 500", "Problemi sa serverom!", "OK");

                }
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Forbidden)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška 403", "Nemate pravo pristupa!", "OK");

                }
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.BadRequest)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška 400", "Greška napravljena prema serveru!", "OK");

                }
                throw;
            }

        }
    }

}
