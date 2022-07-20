using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using ToolSendMail.Models;

namespace ToolSendMail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMailController : ControllerBase
    {
        /// <summary>
        /// Upload File Excel to get Employee Salary
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("upload")]
        public async Task<List<EmployeeSalary>> upload(IFormFile file)
        {
            var listEmployeeSalary = new List<EmployeeSalary>();
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    var rowcount = worksheet.Dimension.Rows;
                    for (int row = 1; row <= rowcount; row++)
                    {
                        EmployeeSalary employeeSalary = new EmployeeSalary();
                        employeeSalary.Email = "email";
                        try
                        {
                            employeeSalary.Id= int.Parse(worksheet.Cells[row, 1].Value.ToString().Trim());
                            employeeSalary.Name = worksheet.Cells[row, 2].Value.ToString().Trim();
                            employeeSalary.Position = worksheet.Cells[row, 3].Value.ToString().Trim();
                            employeeSalary.Email= worksheet.Cells[row, 4].Value.ToString().Trim();
                            employeeSalary.BasicSalary = int.Parse(worksheet.Cells[row, 5].Value.ToString().Trim());
                            employeeSalary.Bonus = 2930000;
                            employeeSalary.NumberDay = int.Parse(worksheet.Cells[row, 11].Value.ToString().Trim());
                            employeeSalary.Deduction = (employeeSalary.BasicSalary) * 105 / 1000;
                        }
                        catch { }
                        if (employeeSalary.Email.Contains("@")){
                            listEmployeeSalary.Add(employeeSalary);
                        }
                    }
                }
                foreach (EmployeeSalary e in listEmployeeSalary)
                {
                    ThongBaoMK(e.Email, e);
                }
                
            }
            return listEmployeeSalary;
        }
        void ThongBaoMK(string email, EmployeeSalary employeeSalary)
        {
            string tb = "<div>Chào " + employeeSalary.Name + " thân ái!" + "</div>" +
                "<div style=\"height: 30px; margin-left: 100px; color: red; font-weight: bold; \">THÔNG TIN BẢNG LƯƠNG</div>" +
                "<div style=\"display: flex;\">" +
                "   <div style=\"width: 280px; border: 1px solid #000; \">Lương cơ bản:</div>" +
                "   <div style=\"border: 1px solid #000; width: 80px; text-align: right;\">" + String.Format("{0:n0}", employeeSalary.BasicSalary) + "</div>" +
                "</div>" +
                "<div style=\"display: flex;\">" +
                "   <div style=\"width: 280px; border: 1px solid #000; \">Tổng thưởng và hỗ trợ:</div>" +
                "   <div style=\"border: 1px solid #000; width: 80px; text-align: right;\">" + String.Format("{0:n0}", employeeSalary.Bonus) + "</div>" +
                "</div>" +
                "<div style=\"display: flex;\">" +
                "   <div style=\"width: 280px; border: 1px solid #000; \">Tổng chi phí trừ(Bao gồm bảo hiểm):</div>" +
                "   <div style=\"border: 1px solid #000; width: 80px; text-align: right;\">" + String.Format("{0:n0}", employeeSalary.Deduction) + "</div>" +
                "</div>" +
                "<div style=\"display: flex; color: red;\">" +
                "   <div style=\"width: 280px; border: 1px solid #000; \">Tổng lương:</div>" +
                "   <div style=\"border: 1px solid #000; width: 80px; text-align: right;\">" + String.Format("{0:n0}", (employeeSalary.BasicSalary + employeeSalary.Bonus - employeeSalary.Deduction)) + "</div>" +
                "</div>" +
                "Công ty devfast!";
            // tạo một tin nhắn và thêm những thông tin cần thiết như: ai gửi, người nhận, tên tiêu đề, và có đôi lời gì cần nhắn nhủ
            MailMessage mail = new MailMessage("ctydevfast@gmail.com", email, "Thông Báo Bảng Lương", tb); //
            mail.IsBodyHtml = true;
            //gửi tin nhắn
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Host = "smtp.gmail.com";
            //ta không dùng cái mặc định đâu, mà sẽ dùng cái của riêng mình
            client.UseDefaultCredentials = false;
            client.Port = 587; //vì sử dụng Gmail nên mình dùng port 587
                               // thêm vào credential vì SMTP server cần nó để biết được email + password của email đó mà bạn đang dùng
            client.Credentials = new System.Net.NetworkCredential("ctydevfast@gmail.com", "lwiwlqojojmjmkba");
            client.EnableSsl = true; //vì ta cần thiết lập kết nối SSL với SMTP server nên cần gán nó bằng true
            client.Send(mail);
        }
    }
}
