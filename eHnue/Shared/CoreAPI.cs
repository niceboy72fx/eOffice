using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
//using CoreAPI.Entity;
using System.Net.Http.Headers;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Text.Json;
using System.Runtime.Intrinsics.Arm;
using Newtonsoft.Json;

namespace eHnue.Shared
{

    public class CoreAPI
    {
        public const string BASE_URL_API = "https://ums.hnue.edu.vn";
        public const string BASE_URL = "https://qlnt.hnue.edu.vn"; // base url lay data trả lại cho bên core


        public const string appToken = "GWtfLA550PXjEhnakdllmP1gJwLKiHwqvqSCr4vli4FU3vdW9rW6HGj1eMWYyvXtdrxYOksqr9DrJhmXTzK1v0jpHbiehWxxhW0M7FHY8qOHC1r6k8F8kf7nIHRxBOIV637413981455256312";

        public const string home = "http://qlncs.hnue.edu.vn/";
        public const string home_logoff = "http://qlncs.hnue.edu.vn/dang-nhap";

        public const string ApiBase = "https://sso.hnue.edu.vn";
        public const string token_auth = "vYlFowfUqJ2jc2BVCas0QixbBa1uK4ehekwn7cpdAsmiYPVcFOXKzBuMlJEO5uKvoVF1FXYjuP0i6ODvEZp5hUsczjCyXbiPh04CKdWr0xakLLPWFTJfFPOUmmCgVjMS637409529212396028";


        /// <summary>
        /// field that holds your api token
        /// </summary>
        private static string _AuthToken = "";

        /// <summary>
        /// This property sets you Api token.
        /// </summary>
        public static string AuthToken
        {
            get { return _AuthToken; }
            set { _AuthToken = value; }
        }

        /// <summary>
        /// Repressents if the token is set.
        /// </summary>
        private static bool TokenIsSet => AuthToken.Any();

    }
    public class Position
    {
        public int id { get; set; }
        public string Name { get; set; }
    }
    public class Department
    {
        //"Id": 26,
        //    "Name": "Trung tâm Công nghệ Thông tin",
        //    "Address": "Tầng 5, nhà Hiệu Bộ, Trường ĐHSP Hà Nội",
        //    "Tel": "04 37547238 503",
        //    "Email": "tt.cntt@hnue.edu.vn",
        //    "Code": "D2290320",
        //    "SyncCode": null
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public string Code { get; set; }
        public string SyncCode { get; set; }
    }
    public class TaiKhoan
    {

    }
    public class clsRespon
    {
        public string success { get; set; }
        public object data { get; set; }
        public string message { get; set; }
        public int total { get; set; }
    }
    public class GiangVienViewModel
    {
        public int Id { get; set; }
        public int STT { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string NoiSinh { get; set; }
        public string HoKhau { get; set; }
        public string ThongTinLienLac { get; set; }
        public string ChucDanh { get; set; }
        public string HocHamHocVi { get; set; }
        public string KHoa { get; set; }
        public string TenNganHang { get; set; }
        public string SoTaiKhoan { get; set; }

        public bool IsRetired { get; set; }
    }
    public class GiangVienAPI
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TitleId { get; set; }
        public string Code { get; set; }
        public int DegreeId { get; set; }
        public int DepartmentId { get; set; }
        public string Department { get; set; }
        public string Gender { get; set; }
        public int TeachingInId { get; set; }
        public List<int> PositionIds { get; set; }

    }
    public class GiangVienDetailAPI
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public int TitleId { get; set; }
        public string Code { get; set; }
        public int DegreeId { get; set; }
        public int DepartmentId { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public int TeachingInId { get; set; }
        public bool IsMoved { get; set; }
        public bool IsRetired { get; set; }
        public bool IsProbation { get; set; }
    }
    public class AccountInfo
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

    }
    public class OrganizationInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public string Code { get; set; }
        public string SyncCode { get; set; }
    }
    public class ThongTinCanBoAPI
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public int TitleId { get; set; } //ID Chức danh
        public string Code { get; set; }
        public int DegreeId { get; set; } //ID Học hàm, học vị
        public int DepartmentId { get; set; } //ID Đơn vị
        public string Gender { get; set; }
        public int TeachingInId { get; set; }
        public bool IsMoved { get; set; }
        public bool IsRetired { get; set; }
        public bool IsProbation { get; set; }
        public int[] PositionIds { get; set; }
        public string Email { get; set; }
    }
}
