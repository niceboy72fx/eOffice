using CsvHelper;
using eHnue.Shared.Models;
using Newtonsoft.Json;
using NPOI.HPSF;
using NPOI.SS.Formula.Eval;
using NPOI.Util;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Words.NET;

namespace eHnue.Shared
{
    public class CommonConstant{
        public CommonConstant()
        {

        }
        public static string token { get; set; } = "vYlFowfUqJ2jc2BVCas0QixbBa1uK4ehekwn7cpdAsmiYPVcFOXKzBuMlJEO5uKvoVF1FXYjuP0i6ODvEZp5hUsczjCyXbiPh04CKdWr0xakLLPWFTJfFPOUmmCgVjMS637409529212396028";
        public static string url { get; set; } = string.Empty;
        public static  string BASE_URL_API { get; set; } = "https://ums.hnue.edu.vn";
        public static async Task<Position> GetPosition(int id)
        {
            HttpContent c = new StringContent(string.Empty, Encoding.UTF8);

            url = BASE_URL_API + "/api_v2/staff/getPositions";
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("token", token);
            HttpResponseMessage request = await client.GetAsync(url);
            var obj = request.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<APIResponse<Position>>(obj);
            return result.data.ToList().Where(m=>m.id == id).FirstOrDefault();
        }
        public static async Task<Department> getDivisions(int id)
        {
            HttpContent c = new StringContent(string.Empty, Encoding.UTF8);
            url = BASE_URL_API + "/api_v2/organize/getdivisions";
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("token", token);
            HttpResponseMessage request = await client.GetAsync(url);
            var obj = request.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<APIResponse<Department>>(obj);
            return result.data.ToList().Where(m=>m.Id == id).FirstOrDefault();

        }
        public static async Task<Department> getFaculties(int id)
        {
            HttpContent c = new StringContent(string.Empty, Encoding.UTF8);
            url = BASE_URL_API + "/api_v2/organize/getfaculties";
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("token", token);
            HttpResponseMessage request = await client.GetAsync(url);
            var obj = request.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<APIResponse<Department>>(obj);
            return result.data.ToList().Where(m => m.Id == id).FirstOrDefault();

        }
        public static async Task<GiangVien_DetailAPI> GetStaffInfo(int staffid)
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

        public static void PrintOne(string pathTemplate, string pathDist, Dictionary<string, string> dict)
        {   
            //pathTemplate = "D:\\template.docx";
            //pathDist = "D:\\out.docx";
            try
            {
                using (DocX template = DocX.Load(pathTemplate))
                {
                    //docuement.InsertDocument(template);

                    foreach (string keyVar in dict.Keys)
                    {
                        template.ReplaceText(String.Format("<<{0}>>", keyVar), dict[keyVar]);
                    }
                    template.SaveAs(pathDist);
                    //return File(template); // File(template, MimeType, "QuyetDinh.docx");
                }
                

                //using (DocX docuement = DocX.Create(pathDist))
                //{
                //    using (DocX template = DocX.Load(pathTemplate))
                //    {
                //        docuement.InsertDocument(template);
                        
                //        foreach (string keyVar in dict.Keys)
                //        {
                //            docuement.ReplaceText(String.Format("<<{0}>>", keyVar), dict[keyVar]);                            
                //        }

                //    }
                //    docuement.Save();
                //}
            }
            catch (Exception ex)
            {
                //MessageBox.Show(String.Format("{0}", ex.Message), "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            finally
            {

            }

        }


        public static void WriteFile(string pathTemplate, string pathCsv, string pathDist)
        {
            string[] header = { "MSV", "HoTen", "NgaySinh" };


            List<string[]> csv = new List<string[]>();
            csv.Add(new string[3] { "101", "101","101" });
            csv.Add(new string[3] { "102", "102", "102" });
            csv.Add(new string[3] { "103", "103", "103" });
            csv.Add(new string[3] { "104", "104", "104" });

            pathTemplate = "D:\\template.docx";
            pathDist = "D:\\out.docx";
            try
            {
                
                using (DocX docuement = DocX.Create(pathDist))
                {
                    using (DocX template = DocX.Load(pathTemplate))
                    {   
                        for (var l =0; l < csv.Count; l++)                        
                        {  
                                
                            docuement.InsertDocument(template);
                            for (var i = 0; i < header.Length; i++)
                            {
                                docuement.ReplaceText(String.Format("<<{0}>>", header[i]), csv[l][i]);
                            }
                                
                            docuement.InsertSectionPageBreak();
                        }

                        

                    }
                    docuement.Save();
                    if (docuement.Text.Contains("<<") || docuement.Text.Contains(">>"))
                    {
                        //MessageBox.Show("There is some << / >> not merged.");
                    }
                    

                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(String.Format("{0}", ex.Message), "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            finally
            {
                
            }

        }
    }
    

    public class APIResponse<T>
    {
        public string success { get; set; }
        public T[] data { get; set; }
        public string message { get; set; }
        public int total { get; set; }
    }
    public class APIResponseStaff<T>
    {
        public string success { get; set; }
        public T data { get; set; }
        public string message { get; set; }
        public int total { get; set; }
    }
    public class GiangVien_ViewModel
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
    public class GiangVien_DetailAPI
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public int TitleId { get; set; }        
        public int DegreeId { get; set; }        
        public bool IsMoved { get; set; }
        public bool IsRetired { get; set; }
        public bool IsProbation { get; set; }
        public int DepartmentId { get; set; }        
        public int TeachingInId { get; set; }
        public string Email { get; set; }
        public int[] PositionIds { get; set; }

    }

}
