using System.Web.Optimization;

namespace AbpCompanyName.AbpProjectName.WebMpa
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            bundles.Add(
                new StyleBundle("~/Bundles/account-vendor/css")
                    .Include("~/fonts/roboto/roboto.css", new CssRewriteUrlTransform())
                    .Include("~/fonts/material-icons/materialicons.css", new CssRewriteUrlTransform())
                    .Include("~/lib/bootstrap/dist/css/bootstrap.css", new CssRewriteUrlTransform())
                    .Include("~/lib/toastr/toastr.css", new CssRewriteUrlTransform())
                    .Include("~/lib/sweetalert/dist/sweetalert.css", new CssRewriteUrlTransform())
                    .Include("~/lib/famfamfam-flags/dist/sprite/famfamfam-flags.css", new CssRewriteUrlTransform())
                    .Include("~/lib/font-awesome/css/font-awesome.css", new CssRewriteUrlTransform())
                    .Include("~/lib/Waves/dist/waves.css", new CssRewriteUrlTransform())
                    .Include("~/lib/animate.css/animate.css", new CssRewriteUrlTransform())
                    .Include("~/css/materialize.css", new CssRewriteUrlTransform())
                    .Include("~/css/style.css", new CssRewriteUrlTransform())
                    .Include("~/Views/Account/_Layout.css", new CssRewriteUrlTransform())
            );

            bundles.Add(
                new ScriptBundle("~/Bundles/account-vendor/js/bottom")
                    .Include(
                        "~/lib/json2/json2.js",
                        "~/lib/jquery/dist/jquery.js",
                        "~/lib/bootstrap/dist/js/bootstrap.js",
                        "~/lib/moment/min/moment-with-locales.js",
                        "~/lib/jquery-validation/dist/jquery.validate.js",
                        "~/lib/blockUI/jquery.blockUI.js",
                        "~/lib/toastr/toastr.js",
                        "~/lib/sweetalert/dist/sweetalert-dev.js",
                        "~/lib/spin.js/spin.js",
                        "~/lib/spin.js/jquery.spin.js",
                        "~/lib/Waves/dist/waves.js",
                        "~/lib/abp-web-resources/Abp/Framework/scripts/abp.js",
                        "~/lib/abp-web-resources/Abp/Framework/scripts/libs/abp.jquery.js",
                        "~/lib/abp-web-resources/Abp/Framework/scripts/libs/abp.toastr.js",
                        "~/lib/abp-web-resources/Abp/Framework/scripts/libs/abp.blockUI.js",
                        "~/lib/abp-web-resources/Abp/Framework/scripts/libs/abp.spin.js",
                        "~/lib/abp-web-resources/Abp/Framework/scripts/libs/abp.sweet-alert.js",
                        "~/js/admin.js",
                        "~/js/main.js"
                    )
            );

            //VENDOR RESOURCES

            //~/Bundles/vendor/css
            bundles.Add(
                new StyleBundle("~/Bundles/vendor/css")
                    .Include("~/Content/BsbAdmin/css/themes/all-themes.css", new CssRewriteUrlTransform())
                    .Include("~/Content/toastr.min.css", new CssRewriteUrlTransform())
                    .Include("~/Scripts/sweetalert/sweet-alert.css", new CssRewriteUrlTransform())
                    .Include("~/Content/flags/famfamfam-flags.css", new CssRewriteUrlTransform())
                    .Include("~/Content/font-awesome.min.css", new CssRewriteUrlTransform())
                );

            //~/Bundles/vendor/js/top (These scripts should be included in the head of the page)
            bundles.Add(
                new ScriptBundle("~/Bundles/vendor/js/top")
                    .Include(
                        "~/Abp/Framework/scripts/utils/ie10fix.js",
                        "~/Scripts/modernizr-2.8.3.js"
                    )
                );

            //~/Bundles/vendor/bottom (Included in the bottom for fast page load)
            bundles.Add(
                new ScriptBundle("~/Bundles/vendor/js/bottom")
                    .Include(
                        "~/Scripts/json2.min.js",

                        "~/Scripts/jquery-2.2.0.min.js",
                        "~/Scripts/jquery-ui-1.11.4.min.js",

                        "~/Scripts/bootstrap.min.js",

                        "~/Scripts/moment-with-locales.min.js",
                        "~/Scripts/jquery.validate.min.js",
                        "~/Scripts/jquery.blockUI.js",
                        "~/Scripts/toastr.min.js",
                        "~/Scripts/sweetalert/sweet-alert.min.js",
                        "~/Scripts/others/spinjs/spin.js",
                        "~/Scripts/others/spinjs/jquery.spin.js",

                        "~/Abp/Framework/scripts/abp.js",
                        "~/Abp/Framework/scripts/libs/abp.jquery.js",
                        "~/Abp/Framework/scripts/libs/abp.toastr.js",
                        "~/Abp/Framework/scripts/libs/abp.blockUI.js",
                        "~/Abp/Framework/scripts/libs/abp.spin.js",
                        "~/Abp/Framework/scripts/libs/abp.sweet-alert.js",

                        "~/Scripts/jquery.signalR-2.2.1.min.js"
                    )
                );

            //APPLICATION RESOURCES

            //~/Bundles/css
            bundles.Add(
                new StyleBundle("~/Bundles/css")
                    .Include("~/css/main.css")
                );

            //~/Bundles/js
            bundles.Add(
                new ScriptBundle("~/Bundles/js")
                    .Include("~/js/main.js")
                );
        }
    }
}