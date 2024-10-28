using eHnue.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Net;
using System.Runtime.Intrinsics.Arm;
using System.Text;

namespace eHnue.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        public const string ApiBase = "https://sso.hnue.edu.vn";
        public const string token_auth = "";
        public const string home = "http://qlncs.hnue.edu.vn/";
        public const string home_logoff = "http://qlncs.hnue.edu.vn/dang-nhap";
        /// <summary>
        /// field that holds your api token
        /// </summary>
        private static string _AuthToken = "";
        [HttpGet]

        public static async Task<string> Get()
        {


            string token = "";
            string url = string.Empty;
            string BASE_URL_API = "https://ums.hnue.edu.vn";
            url = BASE_URL_API + "/api_v2/staffuser/validate?";
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("token", token);
            HttpContent c = new StringContent(string.Empty, Encoding.UTF8);
            HttpResponseMessage request = await client.PostAsync(url, c);
            return request.Content.ToString();

        }
    }
}
