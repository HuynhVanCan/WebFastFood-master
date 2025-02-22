﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
// su dung thu vien using System.Net.Mail; cho goi email
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace VSLT_FastfoodTeam.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email
        public ActionResult LienHe()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LienHe(string receiverEmail, string subject, string nameKhachHang, string message)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var senderEmail = new MailAddress("canhuynhvn@gmail.com", "Thông Tin Liên Hệ Từ Khách Hàng!!!!");
                    var receiveremail = new MailAddress(receiverEmail, "Receiver");

                    var password = "canhuynh123456789";
                    var Sub = subject;
                    var namekh = nameKhachHang;
                    var body = "Tôi tên là " + nameKhachHang + "\n" + message;
                    var smtp = new SmtpClient
                    {
                        // dich vu
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)

                    };
                    using (var mess = new MailMessage(senderEmail, receiveremail)
                    {

                        Subject = subject,
                        Body = body
                    }
                    )
                    {
                        smtp.Send(mess);
                        ViewBag.Error = "Tin nhắn của bạn đã được gửi , cám ơn đã liên hệ!!!";
                    }
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Lỗi Phát Sinh Khi Gửi!!!";
            }
            return View();
        }
    }
}