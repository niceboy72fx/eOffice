using eHnue.Shared;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eHnue.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffAPIController : ControllerBase
    {
        // GET: api/<StaffAPIController>
        private string token = "vYlFowfUqJ2jc2BVCas0QixbBa1uK4ehekwn7cpdAsmiYPVcFOXKzBuMlJEO5uKvoVF1FXYjuP0i6ODvEZp5hUsczjCyXbiPh04CKdWr0xakLLPWFTJfFPOUmmCgVjMS637409529212396028";
        string BASE_URL_API = "https://ums.hnue.edu.vn";
        
        [HttpGet]
        public async Task<ResponseObj> Get()
        {
            HttpContent c = new StringContent(string.Empty, Encoding.UTF8);
            string url = string.Empty;
            url = BASE_URL_API + "/api_v2/staffuser/validate?username=";
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("token", token);

            HttpResponseMessage request = await client.PostAsync(url, c);
            var obj = request.Content.ReadAsStringAsync().Result;// request.Content.ReadFromJsonAsync<ResponseObj>();
            var result = JsonConvert.DeserializeObject<ResponseObj>(obj);

            return result;
        }

        // GET api/<CoreAPIController>/5
        [HttpGet("{id}")]
        //public string Get(int id)
        public async Task<StaffAPI_View> Get(int id)
        {
            HttpContent c = new StringContent(string.Empty, Encoding.UTF8);
            string url = string.Empty;
            url = BASE_URL_API + "/api_v2/staff/getstaff?id="+id;
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("token", token);

            HttpResponseMessage request = await client.GetAsync(url);
            var obj = request.Content.ReadAsStringAsync().Result;// request.Content.ReadFromJsonAsync<ResponseObj>();
            var result = JsonConvert.DeserializeObject<StaffAPI_View>(obj);

            return result;
        }

        // POST api/<StaffAPIController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StaffAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StaffAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
