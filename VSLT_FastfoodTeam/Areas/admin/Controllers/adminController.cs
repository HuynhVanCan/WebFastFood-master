using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VSLT_FastfoodTeam.Models;

namespace VSLT_FastfoodTeam.Areas.admin.Controllers
{
    public class adminController : Controller
    {
        // GET: admin/admin
        MyDataDataContext db = new MyDataDataContext();
        public ActionResult Index()
        {
            //Session kieu nhu view / luu trong 1 khoang 1 thoi gian / la 1 cai bien de view goi no.
            int monday = FirstDateInWeek(DateTime.Now, DayOfWeek.Monday).Day;
            Session["HetHang"] = db.SanPhams.Where(x => x.Soluongton == 0 ).Count();
            Session["SapHetHang"] = db.SanPhams.Where(x => x.Soluongton < 5 && x.Soluongton >0).Count();
            Session["Tongsl"] = db.SanPhams.Select(x => x.MaSP).Count();
            var series = new List<double>();

            double[] temp = new double[7];
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = 0;
            }
            var list = db.thongkeddhs.ToList();
            foreach (var ele in list)
                // dung store procedure
                // goi bang thong ke tu csdl len
            {
                switch (ele.Ngaydat.Value.DayOfWeek)
                {
                    // temp may cot / may dong
                    case DayOfWeek.Monday: temp[0] = (double)ele.số_lần_đặt; break;
                    case DayOfWeek.Tuesday: temp[1] = (double)ele.số_lần_đặt; break;
                    case DayOfWeek.Wednesday: temp[2] = (double)ele.số_lần_đặt; ; break;
                    case DayOfWeek.Thursday: temp[3] = (double)ele.số_lần_đặt; break;
                    case DayOfWeek.Friday: temp[4] = (double)ele.số_lần_đặt; break;
                    case DayOfWeek.Saturday: temp[5] = (double)ele.số_lần_đặt; break;
                    case DayOfWeek.Sunday: temp[6] = (double)ele.số_lần_đặt; break;
                }
            }
            // toa do
            ViewBag.thu2 = temp[0];
            ViewBag.thu3 = temp[1];
            ViewBag.thu4 = temp[2];
            ViewBag.thu5 = temp[3];
            ViewBag.thu6 = temp[4];
            ViewBag.thu7 = temp[5];
            ViewBag.cn = temp[6];
            return View();
        }
        // qua ngay ket thuc, bat dau` lai ngay` thu 2
        public DateTime FirstDateInWeek(DateTime dt, DayOfWeek weekStartDay)
        {
            while (dt.DayOfWeek != weekStartDay)
                dt = dt.AddDays(-1);
            return dt;
        }

    }
}