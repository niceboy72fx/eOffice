using eHnue.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace eHnue.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   

    public class GetInfoController : ControllerBase
    {
        [HttpGet]
        public async Task<GiangVienDetailAPI> Get()
        {

            ////
            //HttpContent c = new StringContent(string.Empty, Encoding.UTF8);
            //string url = string.Empty;
            //url = "https://localhost:7165/api/CoreAPI";
            //var client = new HttpClient();
            //client.DefaultRequestHeaders.Add("token", eHnue.Shared.CoreAPI.token_auth);

            //HttpResponseMessage request = await client.GetAsync(url);
            //var obj = request.Content.ReadAsStringAsync().Result;// request.Content.ReadFromJsonAsync<ResponseObj>();
            //var result = JsonConvert.DeserializeObject<GiangVienDetailAPI>(obj);
            ///

            HttpContent c = new StringContent(string.Empty, Encoding.UTF8);
            string url = string.Empty;
            url = eHnue.Shared.CoreAPI.BASE_URL_API + "/api_v2/staffuser/validate?username=";
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("token", eHnue.Shared.CoreAPI.token_auth);

            HttpResponseMessage request = await client.PostAsync(url, c);
            var obj = request.Content.ReadAsStringAsync().Result;// request.Content.ReadFromJsonAsync<ResponseObj>();
            var result = JsonConvert.DeserializeObject<GiangVienDetailAPI>(obj);

            return result;
        }

        [HttpGet("{id}")]
        public static async Task<GiangVienDetailAPI> Get(int id)
        {
            GiangVienDetailAPI list = new GiangVienDetailAPI();
            using (var client = new HttpClient())
            {
                try
                {
                    string url = string.Empty;
                    url = eHnue.Shared.CoreAPI.BASE_URL_API + "/api_v2/staff/getstaff?id=" + id;

                    client.DefaultRequestHeaders.Add("token", eHnue.Shared.CoreAPI.token_auth);

                    HttpResponseMessage request = await client.GetAsync(url);
                    if (request.IsSuccessStatusCode)
                    {
                        var json = await request.Content.ReadAsStringAsync();
                        clsRespon response = JsonConvert.DeserializeObject<clsRespon>(json);
                        if (response.success == "true")
                        {
                            list = JsonConvert.DeserializeObject<GiangVienDetailAPI>(response.data.ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }

            return list;
        }
    }


}
