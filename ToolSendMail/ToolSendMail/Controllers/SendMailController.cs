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
        public async Task<List<EmployeeSalary>> upload(IFormFile file, string ccEmail)
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
                            employeeSalary.Bonus = int.Parse(worksheet.Cells[row, 6].Value.ToString().Trim());
                            employeeSalary.Bonus += int.Parse(worksheet.Cells[row, 7].Value.ToString().Trim());
                            employeeSalary.Bonus += int.Parse(worksheet.Cells[row, 8].Value.ToString().Trim());
                            employeeSalary.Bonus += int.Parse(worksheet.Cells[row, 9].Value.ToString().Trim());
                            employeeSalary.NumberDay = int.Parse(worksheet.Cells[row, 11].Value.ToString().Trim());
                            employeeSalary.Deduction = int.Parse(worksheet.Cells[row, 23].Value.ToString().Trim());
                        }
                        catch { }
                        if (employeeSalary.Email.Contains("@")){
                            listEmployeeSalary.Add(employeeSalary);
                        }
                    }
                }
                //foreach (EmployeeSalary e in listEmployeeSalary)
                //{
                //    ThongBao(ccEmail, e);
                //}

            }
            return listEmployeeSalary;
        }
        void ThongBao(string ccEmail, EmployeeSalary employeeSalary)
        {
            string tb = "<div>Chào " + employeeSalary.Name + " thân ái!" + "</div>" +
                "<div style=\"margin-top: 20px; margin-left: 100px; color: red; font-weight: bold; \">THÔNG TIN BẢNG LƯƠNG</div>" +
                "<div style=\"border-bottom: 1px solid #f0f0f0; display: flex; margin-top: 20px; height: 27px; width: 360px;\">" +
                "   <div style=\" width: 240px; \">Mã nhân viên</div>" +
                "   <div style=\" width: 120px; text-align: right; \">" + employeeSalary.Id + "</div>" +
                "</div>" +
                "<div style=\"border-bottom: 1px solid #f0f0f0; display: flex; margin-top: 10px; height: 27px; width: 360px;\">" +
                "   <div style=\" width: 240px; \">Họ tên</div>" +
                "   <div style=\" width: 120px; text-align: right; \">" + employeeSalary.Name + "</div>" +
                "</div>" +
                "<div style=\"border-bottom: 1px solid #f0f0f0; display: flex; margin-top: 10px; height: 27px; width: 360px;\">" +
                "   <div style=\" width: 240px; \">Chức vụ</div>" +
                "   <div style=\" width: 120px; text-align: right; \">" + employeeSalary.Position + "</div>" +
                "</div>" +
                "<div style=\"border-bottom: 1px solid #f0f0f0; display: flex; margin-top: 10px; height: 27px; width: 360px;\">" +
                "   <div style=\" width: 240px; \">Lương cơ bản</div>" +
                "   <div style=\" width: 120px; text-align: right; \">" + String.Format("{0:n0}", employeeSalary.BasicSalary) + "</div>" +
                "</div>" +
                "<div style=\"border-bottom: 1px solid #f0f0f0;display: flex; margin-top: 10px; height: 27px; width: 360px;\">" +
                "   <div style=\"width: 240px;  \">Tổng thưởng và hỗ trợ</div>" +
                "   <div style=\" width: 120px; text-align: right;\">" + String.Format("{0:n0}", employeeSalary.Bonus) + "</div>" +
                "</div>" +
                "<div style=\"border-bottom: 1px solid #f0f0f0; display: flex; margin-top: 10px; height: 27px; width: 360px;\">" +
                "   <div style=\"width: 240px; \">Tổng chi phí trừ(Bao gồm bảo hiểm)</div>" +
                "   <div style=\" width: 120px; text-align: right;\">" + String.Format("{0:n0}", employeeSalary.Deduction) + "</div>" +
                "</div>" +
                "<div style=\" border-bottom: 1px solid #f0f0f0; display: flex; margin-top: 10px; height: 27px; color: red; width: 360px;\">" +
                "   <div style=\"width: 240px;  \">Tổng lương</div>" +
                "   <div style=\" width: 120px; text-align: right;\">" + String.Format("{0:n0}", (employeeSalary.BasicSalary + employeeSalary.Bonus - employeeSalary.Deduction)) + "</div>" +
                "</div>" +
                "<div style=\"width: 360px; text-align: right; margin-top: 20px;\">Công ty devfast!</div>";
            // tạo một tin nhắn và thêm những thông tin cần thiết như: ai gửi, người nhận, tên tiêu đề, và có đôi lời gì cần nhắn nhủ
            MailMessage mail = new MailMessage("ctydevfast@gmail.com", employeeSalary.Email, "Thông Báo Bảng Lương", tb); //
            mail.IsBodyHtml = true;
            if (ccEmail.Length > 0)
            {
                try
                {
                    MailAddress copy = new MailAddress(ccEmail);
                    mail.CC.Add(copy);
                }
                catch
                {
                    throw;
                }
            }

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
