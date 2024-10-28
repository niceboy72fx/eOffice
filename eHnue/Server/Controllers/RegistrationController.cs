using eHnue.Server.AppDbContext;
using eHnue.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eHnue.Shared;
using System.Text;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

using System.Linq.Expressions;
using System.Linq;
using Org.BouncyCastle.Ocsp;
using eHnue.Shared;
using NPOI.HPSF;

namespace eHnue.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class RegistrationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment env;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RegistrationController(ApplicationDbContext context, IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
        {
            this._context = context;
            this.env = env;
            _httpContextAccessor = httpContextAccessor;
        }


        [HttpGet("Print/{id}")]
        public async Task<IActionResult> Print(int id)
        {
            var reg = await _context.Registrations.FirstOrDefaultAsync(a => a.Id == id);
            var country = await _context.Countries.FindAsync(reg.ToCountryId);
            var purpose = await _context.Purposes.FindAsync(reg.PurposeId);
            var staff = CommonConstant.GetStaffInfo(reg.StaffId);
            var dept = CommonConstant.getDivisions(reg.DepartmentID);
            var facult = CommonConstant.getFaculties(reg.DepartmentID);
            var post = CommonConstant.GetPosition(staff.Result.PositionIds[0]);
            var title = "";
            if (staff.Result.Gender.Trim().ToUpper() == "NAM" )
            {
                title = "Ông";
            }else
            {
                title = "Bà";
            }
            var donvi = "";
            if (dept.Result != null)
            {
                donvi = dept.Result.Name;
            }else
            {
                donvi = facult.Result.Name;
            }
            string FilePath = Directory.GetCurrentDirectory() + "\\Templates\\NghiPhep.docx";
            
            
            
            var folderName = Path.Combine("StaticFiles", "QuyetDinh");
            var dbPath = Path.Combine(folderName, $"QuyetDinh_{reg.Id}.docx");

            Dictionary<string, string> dict = new Dictionary<string, string>()
            {
                { "DanhXung", title},
                {"HoTen", reg.Name },
                {"NgaySinh", staff.Result.Birthday.ToString("dd/mm/yyyy") },
                {"ChucVu", post.Result.Name },
                {"DonVi", donvi },
                {"MucDich", purpose==null?"":purpose.PurposeName },
                {"NuocDen",country.CountryName  },                
                {"TuNgay",reg.FromDate.ToString("dd/mm/yyyy") },
                {"DenNgay",reg.ToDate.ToString("dd/mm/yyyy") }
            };

            CommonConstant.PrintOne(FilePath, dbPath, dict);

            //CommonConstant.WriteFile(FilePath, "D:/out.docx","D:/out.docx");
            return Ok(dbPath);
        }
            [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {


                var devs = await _context.Registrations.ToListAsync();
                return Ok(devs);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return NoContent();
            }

        }
        // GET api/<RegisterController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var reg = await _context.Registrations.FirstOrDefaultAsync(a => a.Id == id);
            return Ok(reg);
        }


        [Route("GetByStaff")]
        [HttpGet("GetByStaff/{staffid}")]
        public async Task<IActionResult> GetByStaff(int staffid)
        {
            var reg = await _context.Registrations.Where(a => a.StaffId == staffid).ToListAsync();// .FirstOrDefaultAsync(a => a.StaffId == staffid);

            return Ok(reg);
        }


        [Route("GetByIds")]
        [HttpGet("GetByIds/{Ids}")]
        public async Task<IActionResult> GetByIds(string Ids)
        {
            List<int> TagIds = Ids.Split(',').Select(int.Parse).ToList();
            var reg = await _context.Registrations.Where(m => TagIds.Contains(m.Id)).ToListAsync();

            return Ok(reg);
        }

        // POST api/<RegisterController>
        [Route("AddRegistration")]
        [HttpPost("AddRegistration")]
        public async Task<IActionResult> AddRegistration(Registration registration)
        {
            //return await _countryService.AddCountry(registration);
            //Get Staff Information
            string token = CommonConstant.token;
            string url = CommonConstant.url;
            string BASE_URL_API = CommonConstant.BASE_URL_API;

            HttpContent c = new StringContent(string.Empty, Encoding.UTF8);
            url = BASE_URL_API + "/api_v2/staff/getstaff?id=" + registration.StaffId;
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("token", token);
            HttpResponseMessage request = await client.GetAsync(url);
            var obj = request.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<APIResponseStaff<GiangVien_DetailAPI>>(obj);
            registration.DepartmentID = result.data.DepartmentId;
            registration.Name = result.data.Name;
            //registration.Email = result.data.Email;

            //
            _context.Add(registration);
            await _context.SaveChangesAsync();
            return Ok(registration.Id);
        }

        [Route("GetApproveList")]
        [HttpGet("GetApproveList/{staffId}")]
        public async Task<IActionResult> GetApproveList(int staffId)
        {
            try
            {
                //HttpContent c = new StringContent(string.Empty, Encoding.UTF8);
                //string url = string.Empty;
                //url = "http://" + this.HttpContext.Request.Host.Value + "/api/CoreAPI/GetStaffInfo/" + staffId.ToString();
                ////HttpContext context = this.HttpContext;

                //var client = new HttpClient();
                ////client.DefaultRequestHeaders.Add("token", eHnue.Shared.CoreAPI.token_auth);

                //HttpResponseMessage request = await client.GetAsync(url);
                //var obj = request.Content.ReadAsStringAsync().Result;// request.Content.ReadFromJsonAsync<ResponseObj>();
                //var result = JsonConvert.DeserializeObject<ThongTinCanBoAPI>(obj);

                HttpContent c = new StringContent(string.Empty, Encoding.UTF8);
                string url = eHnue.Shared.CoreAPI.BASE_URL_API + "/api_v2/staff/getstaff?id=" + staffId;
                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("token", eHnue.Shared.CoreAPI.token_auth);
                HttpResponseMessage request = await client.GetAsync(url);
                var obj = request.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<ThongTinCanBoAPI>(obj);


                var devs = await _context.Registrations.ToListAsync();
                return Ok(devs);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return NoContent();
            }

        }
        [Route("PostApproveList")]
        [HttpPost("PostApproveList")]
        public async Task<IActionResult> PostApproveList([FromBody] int staffId)
        {
            try
            {
                HttpContent c = new StringContent(string.Empty, Encoding.UTF8);
                string url = string.Empty;
                url = "https://" + this.HttpContext.Request.Host.Value + "/api/CoreAPI/GetStaffInfo/" + staffId.ToString();
                //HttpContext context = this.HttpContext;

                var client = new HttpClient();
                //client.DefaultRequestHeaders.Add("token", eHnue.Shared.CoreAPI.token_auth);

                HttpResponseMessage request = await client.GetAsync(url);
                var obj = request.Content.ReadAsStringAsync().Result;// request.Content.ReadFromJsonAsync<ResponseObj>();
                var staffObj = JsonConvert.DeserializeObject<GiangVien_DetailAPI>(obj);
                int departmentID = staffObj.DepartmentId;
                int[] positionIds = staffObj.PositionIds;
                List<int> a = new List<int>(positionIds);
                List<Registration_View> devs = null;
                List<Registration_View> ret = null;
                var assigns = _context.AssignRoles.Where(m => m.AssigneeDeptId == departmentID).Where(m => a.Contains(m.AssigneePosId)).ToList();

                foreach (var assign in assigns)
                {
                    int AssignForDepartId = assign.AssignForDepartId;
                    int statusBefor = assign.StatusBeforeAssign;
                    int statusAfter = assign.StatusAfterAssign;
                    //bool isPrivate = assign.IsPrivated; //chưa áp dụng
                    //var s = from p in _context.Registrations.Where(m => m.DepartmentID == AssignForDepartId && m.ApprovedStatus == statusBefor && m.IsPrivate == isPrivate).ToList()


                    //string condition= string.Empty;

                    var s = from p in _context.Registrations.Where(m => m.ApprovedStatus == statusBefor).ToList()
                            select new Registration_View
                            {
                                Id = p.Id,
                                StaffId = p.StaffId,
                                Name = p.Name,
                                StaffType = p.StaffType,
                                DepartmentID = p.DepartmentID,
                                PurposeId = p.PurposeId,
                                ToCountryId = p.ToCountryId,
                                Cities = p.Cities,
                                FromDate = p.FromDate,
                                ToDate = p.ToDate,
                                ExpenseId = p.ExpenseId,
                                Commitment = p.Commitment,
                                IsPartyMember = p.IsPartyMember,
                                MobiPhone = p.MobiPhone,
                                OutboundPhone = p.OutboundPhone,
                                Email = p.Email,
                                Description = p.Description,
                                RegistrationType = p.RegistrationType,
                                Status = p.Status,
                                ApprovedStatus = p.ApprovedStatus,
                                StatusAfterApprove = statusAfter
                            };
                    if (devs == null)
                    {

                        devs = s.ToList();
                    }
                    else
                    {
                        var s2 = devs.Union(s.ToList());
                        devs = s2.ToList();
                    }

                    if (AssignForDepartId != -1)
                    {
                        devs = devs.Where(m => m.DepartmentID == AssignForDepartId).ToList();
                    }

                }
                return Ok(devs);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return NoContent();
            }

        }

        [HttpPut]
        public async Task<bool> Put(Registration registration)
        {
            _context.Entry(registration).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        // DELETE api/<RegisterController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var dev = new Registration { Id = id };
            _context.Remove(dev);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
