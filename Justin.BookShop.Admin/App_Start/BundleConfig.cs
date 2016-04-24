using System.Web;
using System.Web.Optimization;

namespace Justin.BookShop.Admin
{
    public class BundleConfig
    {
        // 有关 Bundling 的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/miniui_js").Include(
                        "~/Scripts/jquery-1.6.2.js",
                        "~/Scripts/miniui.js"));

            bundles.Add(new StyleBundle("~/bundles/miniui_css").Include(
                        "~/Content/themes/mini/default/miniui.css",
                        "~/Content/themes/mini/icons.css",
                        "~/Content/themes/my_icon.css"));
        }
    }
}