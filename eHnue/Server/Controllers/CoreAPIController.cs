//using eHnue.Client.Pages.Country;
using eHnue.Client.Pages;
using eHnue.Server.AppDbContext;
using eHnue.Shared;
using eHnue.Shared.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eHnue.Server.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CoreAPIController : ControllerBase
    {

        string token = CommonConstant.token; //"vYlFowfUqJ2jc2BVCas0QixbBa1uK4ehekwn7cpdAsmiYPVcFOXKzBuMlJEO5uKvoVF1FXYjuP0i6ODvEZp5hUsczjCyXbiPh04CKdWr0xakLLPWFTJfFPOUmmCgVjMS637409529212396028";
        string url = CommonConstant.url;
        string BASE_URL_API = CommonConstant.BASE_URL_API;// "https://ums.hnue.edu.vn";
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;

        public CoreAPIController(IConfiguration configuration, ApplicationDbContext context)
        {
            _configuration = configuration;
            this._context = context;
        }
        // GET: api/<CoreAPIController>
        [HttpGet]
        //public IEnumerable<string> Get()
        public async Task<HttpResponseMessage> Get()
        {
            HttpContent c = new StringContent(string.Empty, Encoding.UTF8);

            url = BASE_URL_API + "/api_v2/staffuser/validate?username=nghibuivan@hnue.edu.vn&password=000252";
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("token", token);
            HttpResponseMessage request = await client.PostAsync(url, c);
            return request;
        }

        // GET api/<CoreAPIController>/5
        [HttpGet("GetPosition")]
        public async Task<List<Position>> GetPosition()
        {
            HttpContent c = new StringContent(string.Empty, Encoding.UTF8);

            url = BASE_URL_API + "/api_v2/staff/getPositions";
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("token", token);
            HttpResponseMessage request = await client.GetAsync(url);
            var obj = request.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<APIResponse<Position>>(obj);
            return result.data.ToList();
        }

        [HttpGet("GetDepartment")]
        public async Task<List<Department>> GetDepartment()
        {
            //"Id": 9,
            //"Name": "Khoa Công tác xã hội",
            //"Address": "Tầng 3 nhà D3 – Đại học Sư Phạm Hà Nội, 136 Xuân Thủy – Cầu Giấy – Hà Nội",
            //"Tel": "04.85876443",
            //"Email": "k.ctxh@hnue.edu.vn",
            //"Code": "D2290570",
            //"SyncCode": "SOWK"
            //"Id": 26,
            //"Name": "Trung tâm Công nghệ Thông tin",
            //"Address": "Tầng 5, nhà Hiệu Bộ, Trường ĐHSP Hà Nội",
            //"Tel": "04 37547238 503",
            //"Email": "tt.cntt@hnue.edu.vn",
            //"Code": "D2290320",
            //"SyncCode": null
            HttpContent c = new StringContent(string.Empty, Encoding.UTF8);
            url = BASE_URL_API + "/api_v2/organize/getfaculties";
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("token", token);

            HttpResponseMessage request = await client.GetAsync(url);
            var obj = request.Content.ReadAsStringAsync().Result;
            var result1 = JsonConvert.DeserializeObject<APIResponse<Department>>(obj);

            url = BASE_URL_API + "/api_v2/organize/getdivisions";
            request = await client.GetAsync(url);
            obj = request.Content.ReadAsStringAsync().Result;
            var result2 = JsonConvert.DeserializeObject<APIResponse<Department>>(obj);

            return result1.data.ToList().Concat(result2.data.ToList()).ToList();

        }

        [HttpGet("GetDepartment/{id}")]
        public async Task<APIResponse<Department>> GetDepartment(int id)
        {
            HttpContent c = new StringContent(string.Empty, Encoding.UTF8);
            url = BASE_URL_API + "/api_v2/staff/getstave?departmentid=" + id;
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("token", token);
            HttpResponseMessage request = await client.GetAsync(url);
            var obj = request.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<APIResponse<Department>>(obj);
            return result;

        }


        [HttpGet("GetStaff/{departid}")]
        public async Task<List<ThongTinCanBoAPI>> GetStaff(int departid)
        {
            HttpContent c = new StringContent(string.Empty, Encoding.UTF8);
            url = BASE_URL_API + "/api_v2/staff/getstave?departmentid=" + departid;
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("token", token);
            HttpResponseMessage request = await client.GetAsync(url);
            var obj = request.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<APIResponse<ThongTinCanBoAPI>>(obj);

            return result.data.ToList();

        }

        [HttpGet("GetStaffInfo/{staffID}")]
        public async Task<GiangVien_DetailAPI> GetStaffInfo(int staffid)
        {
            try
            {
                HttpContent c = new StringContent(string.Empty, Encoding.UTF8);
                url = BASE_URL_API + "/api_v2/staff/getstaff?id=" + staffid;
                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("token", token);
                HttpResponseMessage request = await client.GetAsync(url);
                var obj = request.Content.ReadAsStringAsync().Result;
                //var result1 = JsonConvert.DeserializeObject<APIResponse<GiangVien_DetailAPI>>(obj);
                var result = JsonConvert.DeserializeObject<APIResponseStaff<GiangVien_DetailAPI>>(obj);

                return result.data;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }


        // POST api/<CoreAPIController>
        [HttpPost("CoreAPILogin")]
        public async Task<IActionResult> CoreAPILogin([FromBody] LoginDTO usr)
        {
            HttpContent c = new StringContent(string.Empty, Encoding.UTF8);
            string token = "vYlFowfUqJ2jc2BVCas0QixbBa1uK4ehekwn7cpdAsmiYPVcFOXKzBuMlJEO5uKvoVF1FXYjuP0i6ODvEZp5hUsczjCyXbiPh04CKdWr0xakLLPWFTJfFPOUmmCgVjMS637409529212396028";
            string url = string.Empty;
            string BASE_URL_API = "https://ums.hnue.edu.vn";
            url = BASE_URL_API + "/api_v2/staffuser/validate?username=" + usr.username + "&password=" + usr.password;
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("token", token);

            HttpResponseMessage request = await client.PostAsync(url, c);
            var obj = request.Content.ReadAsStringAsync().Result;// request.Content.ReadFromJsonAsync<ResponseObj>();
            var result = JsonConvert.DeserializeObject<ResponseObj>(obj);
            ////

            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Name, usr.username));
            if (result.data == null)
            {
                return Ok(new LoginResult { Successful = false, Error = result.message});
            }
            ///Get UserRole
            var staffId = result.data.StaffId;
            List<UserRole> uRoles = _context.UserRoles.Where(m => m.StaffId == staffId).ToList();
            bool NoRole = true;
            foreach (UserRole item in uRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, item.RoleName));
                NoRole = false;
            }
            ////

            if (NoRole)
            {
                claims.Add(new Claim(ClaimTypes.Role, "GV"));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(Convert.ToInt32(_configuration["JwtExpiryInDays"]));

            var auToken = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtAudience"],
                claims,
                expires: expiry,
                signingCredentials: creds
            );


            //await storage.SetAsync("greeting", "Hello, World!");
            return Ok(new LoginResult { Successful = true, Token = new JwtSecurityTokenHandler().WriteToken(auToken), StaffId = result.data.StaffId });


            //return result;
        }

        // PUT api/<CoreAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CoreAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
