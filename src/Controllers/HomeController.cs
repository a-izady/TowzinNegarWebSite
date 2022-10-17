using Kendo.Mvc.Examples.Models;
using System.Web.Mvc;
using WebMarkupMin.AspNet4.Mvc;
//درج نیم فاصله در ویندوز
//اگر در ویندوز از صفحه کلید فارسی رایج استفاده می کنید، می‌توانید در همه محیط‌های نرم افزاری، نیم فاصله را با گرفتن کلیدهای ترکیبی Ctrl+Shift+2 تایپ کنید.
namespace Kendo.Mvc.Examples.Controllers
{

    public class HomeController : IzadyController
    {
        public ActionResult ChangeLanguage(string lang)
        {
            new LanguageMang().SetLanguage(lang);
            return RedirectToAction("Index", "Home"/*,new { lang = lang}*/);
        }
        [MinifyHtmlAttribute]
        [Demo]
        public ActionResult Index()
        {
           ViewBag.BannerBool = true;
            return View();
        }
        [MinifyHtmlAttribute]
        [Demo]
        public ActionResult CustomerList()
        {
            return View();
        }
        [MinifyHtmlAttribute]
        [Demo]
        public ActionResult توزین_نگار()
        {
            return View();
        }
        [MinifyHtmlAttribute]
        [Demo]
        public ActionResult دانلود_رایگان_نرم_افزار_باسکول()
        {
            return View();
        }
        [MinifyHtmlAttribute]
        [Demo]
        public ActionResult IndicatorA23P()
        {
            return View();
        }
        [MinifyHtmlAttribute]
        [Demo]
        public ActionResult نشاندهنده_باسکول()
        {
            return View();
        }
        [MinifyHtmlAttribute]
        [Demo]
        public ActionResult لودسل()
        {
            return View();
        }
        [MinifyHtmlAttribute]
        [Demo]
        public ActionResult ContactUs()
        {
            return View();
        }
        [MinifyHtmlAttribute]
        [Demo]
        public ActionResult WebAutomation()
        {
            return View();
        }
        [MinifyHtmlAttribute]
        [Demo]
        public ActionResult SiteDesign()
        {
            return View();
        }
        [MinifyHtmlAttribute]
        [Demo]
        public ActionResult sms()
        {
            return View();
        }
        [MinifyHtmlAttribute]
        [Demo]
        public ActionResult rs232Terminal()
        {
            return View();
        }
        //[MinifyHtmlAttribute]
        //[Demo]
        //public ActionResult حسابداری_هلو_باسکول()
        //{
        //    return View();
        //}
        [MinifyHtmlAttribute]
        [Demo]
        public ActionResult جانکشن_باکس_لودسل()
        {
            return View();
        }
        [MinifyHtmlAttribute]
        [Demo]
        public ActionResult باسکول_جاده_ای()
        {
            return View();
        }
        //[MinifyHtmlAttribute]
        //[Demo]
        //public ActionResult کالیبراسیون_باسکول()
        //{
        //    return View();
        //}
        [MinifyHtmlAttribute]
        [Demo]
        public ActionResult نمایشگر_ثانویه_باسکول()
        {
            return View();
        }
        [MinifyHtmlAttribute]
        [Demo]        
        public ActionResult مبدل_یو_اس_بی_به_سریال_امگا()
        {
            return View();
        }
        [MinifyHtmlAttribute]
        [Demo]
        public ActionResult بارنامه_بتن()
        {
            return View();
        }
        [MinifyHtmlAttribute]
        [Demo]
        public ActionResult keliХК3118Т1()
        {
            return View();
        }
        [MinifyHtmlAttribute]
        [Demo]
        public ActionResult نرم_افزار_باسکول_کفی_باسکولت()
        {
            return View();
        }
        [MinifyHtmlAttribute]
        [Demo]
        public ActionResult گزارش_گیری_تحت_وب()
        {
            return View();
        }
        [MinifyHtmlAttribute]
        [Demo]
        public ActionResult آموزش()
        {
            return View();
        }
        [MinifyHtmlAttribute]
        [Demo]
        public ActionResult توزین_لیبل_پرینتر()
        {
            return View();
        }
    }
}
