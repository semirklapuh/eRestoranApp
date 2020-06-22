using Flurl.Http;
using System.Threading.Tasks;
using eResto
using System.Net.Http;
using System.Windows.Forms;

namespace eRestoran.WinUI
{
    class APIService
    {
        private string _ruta;
        public static string username;
        public static string pass;
        public APIService(string ruta)
        {
            _ruta = ruta;
        }

        public async Task<T> Get<T>(object search)
        {

            var url = $"{Properties.Settings.Default.APIUrl}/{_ruta}";

            if (search != null)
            {
                url += "?";
                url += await search.ToQueryString();
            }

            var result = await url.WithBasicAuth(username, pass).GetJsonAsync<T>();
            return result;
        }
}
