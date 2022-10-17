using Kendo.Mvc.Examples.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using IOFile = System.IO.File;

namespace Kendo.Mvc.Examples.Controllers
{
    public abstract class ActionFilterAttributeBase : ActionFilterAttribute
    {
        protected static string Header = "";
        protected static string Footer = "";
        protected static bool ResetHeader = true;
        protected static bool ResetFooter = true;
        protected static string TelerikNavigationVersion = "stable";

        protected List<string> examplesUrl = new List<string>();

        private static readonly JavaScriptSerializer Serializer = new JavaScriptSerializer();

        public dynamic ViewBag
        {
            get
            {
                return Controller.ViewBag;
            }
        }

        public Controller Controller { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Controller = filterContext.Controller as Controller;
            string Url = filterContext.HttpContext.Request.Url.AbsoluteUri;

            if (ResetHeader)
            {
                UpdateHeader(Url);
            }
            if (ResetFooter)
            {
                UpdateFooter(Url);
            }

            ViewBag.ShowCodeStrip = true;
            ViewBag.Product = "aspnet-mvc";
            ViewBag.NavProduct = "mvc";
            ViewBag.TelerikNavigationHeader = Header;
            ViewBag.TelerikNavigationFooter = Footer;

            SetTheme();
            LoadNavigation();
            LoadCategories();

            if (Url.IndexOf("updateteleriknavigation") != -1)
            {
                ResetHeader = true;
                ResetFooter = true;
            }
        }

        protected void SetTheme()
        {
            var theme = "material";
            var themeParam = Controller.HttpContext.Request.QueryString["theme"];
            var themeCookie = Controller.HttpContext.Request.Cookies["theme"];

            if (themeParam != null && Regex.IsMatch(themeParam, "[a-z0-9\\-]+", RegexOptions.IgnoreCase))
            {
                theme = themeParam;

                // update cookie
                HttpCookie cookie = new HttpCookie("theme");
                cookie.Value = theme;
                Controller.ControllerContext.HttpContext.Response.Cookies.Add(cookie);
            }
            else if (themeCookie != null)
            {
                theme = themeCookie.Value;
            }

            var CommonFileCookie = Controller.HttpContext.Request.Cookies["commonFile"];

            ViewBag.Theme = theme;
            ViewBag.CommonFile = CommonFileCookie == null ? "common-material" : CommonFileCookie.Value;
        }

        protected void LoadNavigation()
        {
            ViewBag.Navigation = LoadWidgets();
        }

        protected void LoadCategories()
        {
            ViewBag.WidgetCategories = LoadWidgets().GroupBy(w => w.Category).ToList();
        }

        protected IEnumerable<NavigationWidget> LoadWidgets()
        {
            var navJson = IOFile.ReadAllText(Controller.Server.MapPath("~/content/nav.json"));

            return Serializer.Deserialize<NavigationWidget[]>(navJson.Replace("$FRAMEWORK", "ASP.NET MVC"));
        }

        protected void UpdateHeader(string Url)
        {
            ResetHeader = false;

            if (Url.IndexOf("localhost") == -1)
            {
                string ProductName = "asp-net-mvc";
                string cdnEnvironment = "";

                if (Url.IndexOf("kendobuild") != -1)
                {
                    cdnEnvironment = "uat";
                }

                string urlAddress = "https://" + cdnEnvironment + "cdn.telerik-web-assets.com/telerik-navigation/" + TelerikNavigationVersion + "/nav-" + ProductName + "-csa-abs-component.html";

                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
                    request.Timeout = 4000;
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            Stream receiveStream = response.GetResponseStream();
                            StreamReader readStream = null;

                            if (response.CharacterSet == null)
                            {
                                readStream = new StreamReader(receiveStream);
                            }
                            else
                            {
                                readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                            }

                            string data = readStream.ReadToEnd();

                            Header = data;

                            readStream.Close();
                            receiveStream.Close();
                            response.Close();
                        }
                    }
                }
                catch (Exception) { }
            }
        }

        protected void UpdateFooter(string Url)
        {
            ResetFooter = false;

            if (Url.IndexOf("localhost") == -1)
            {
                string cdnEnvironment = "";

                if (Url.IndexOf("kendobuild") != -1)
                {
                    cdnEnvironment = "uat";
                }

                string urlAddress = "https://" + cdnEnvironment + "cdn.telerik-web-assets.com/telerik-navigation/" + TelerikNavigationVersion + "/footer-big-abs-markup.html";

                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
                    request.Timeout = 4000;
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            Stream receiveStream = response.GetResponseStream();
                            StreamReader readStream = null;

                            if (response.CharacterSet == null)
                            {
                                readStream = new StreamReader(receiveStream);
                            }
                            else
                            {
                                readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                            }

                            string data = readStream.ReadToEnd();

                            Footer = data;

                            readStream.Close();
                            receiveStream.Close();
                            response.Close();
                        }
                    }
                }
                catch (Exception) { }
            }
        }
    }
}