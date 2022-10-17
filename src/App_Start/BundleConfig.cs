﻿using System.Web.Optimization;

namespace Kendo.Mvc.Examples
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/demo").Include(
                        "~/Scripts/console.js",
                        "~/Scripts/prettify.js"));

            bundles.IgnoreList.Clear();
        }
    }
}
