﻿using System.Web;
using System.Web.Optimization;

namespace SHF
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive-ajax.js",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Site.css"));

            bundles.Add(new StyleBundle("~/bundles/style-sheet").Include(
                        //"~/Content/site.css",
                        "~/bower_components/bootstrap/dist/css/bootstrap.css",
                        "~/bower_components/font-awesome/css/font-awesome.css",
                        "~/bower_components/Ionicons/css/ionicons.css",
                        "~/dist/css/AdminLTE.css",
                        "~/dist/css/skins/_all-skins.css",
                        "~/bower_components/morris.js/morris.css",
                        //"~/bower_components/jvectormap/jquery-jvectormap.css",
                        "~/bower_components/bootstrap-datepicker/dist/css/bootstrap-datepicker.css",
                        "~/bower_components/bootstrap-daterangepicker/daterangepicker.css",
                        "~/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.css",
                        "~/bower_components/datatables.net-bs/css/dataTables.bootstrap.css",
                        "~/plugins/iCheck/all.css",
                        //"~/bower_components/angular-icheck/angular-icheck.css",
                        "~/bower_components/bootstrap-colorpicker/dist/css/bootstrap-colorpicker.css",
                        "~/plugins/timepicker/bootstrap-timepicker.css",
                        //"~/bower_components/select2/dist/css/select2.css",
                        "~/bower_components/select2/select2.css",
                        "~/bower_components/angular-ui-select/dist/select.css",
                        "~/bower_components/angular-ui-select/dist/select2.css",
                        "~/bower_components/angular-ui-select/dist/selectize.default.css",
                        "~/Content/toastr.css",
                        "~/Content/ui-bootstrap-csp.css"
                    ));

            bundles.Add(new ScriptBundle("~/bundles/java-scripts").Include(
                      "~/bower_components/jquery/dist/jquery.js",
                      "~/bower_components/jquery-ui/jquery-ui.js",
                      "~/bower_components/bootstrap/dist/js/bootstrap.js",
                      "~/bower_components/raphael/raphael.js",
                      "~/bower_components/morris.js/morris.js",
                      "~/bower_components/jquery-sparkline/dist/jquery.sparkline.js",
                      //"~/plugins/jvectormap/jquery-jvectormap-1.2.2.js",
                      //"~/plugins/jvectormap/jquery-jvectormap-world-mill-en.js",
                      "~/bower_components/jquery-knob/dist/jquery.knob.js",
                      "~/bower_components/moment/moment.js",
                      //"~/bower_components/moment/min/moment.min.js",                     
                      "~/bower_components/bootstrap-datepicker/dist/js/bootstrap-datepicker.js",
                       "~/bower_components/bootstrap-daterangepicker/daterangepicker.js",
                      "~/bower_components/bootstrap-colorpicker/dist/js/bootstrap-colorpicker.js",
                      "~/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.js",
                      "~/bower_components/jquery-slimscroll/jquery.slimscroll.js",
                      "~/bower_components/fastclick/lib/fastclick.js",
                      "~/dist/js/adminlte.js",
                      //"~/dist/js/adminlte.min.js",
                      //"~/dist/js/pages/dashboard.js",
                      //"~/dist/js/demo.js",
                      "~/bower_components/datatables.net/js/jquery.dataTables.js",
                      "~/bower_components/datatables.net-bs/js/dataTables.bootstrap.js",
                      "~/bower_components/fastclick/lib/fastclick.js",
                      //"~/bower_components/select2/dist/js/select2.full.js",
                      "~/bower_components/select2/select2.js",
                      "~/plugins/input-mask/jquery.inputmask.js",
                      "~/plugins/input-mask/jquery.inputmask.date.extensions.js",
                      "~/plugins/input-mask/jquery.inputmask.extensions.js",
                      "~/plugins/timepicker/bootstrap-timepicker.js",
                      "~/bower_components/jquery-slimscroll/jquery.slimscroll.js",
                      "~/plugins/iCheck/icheck.js",
                      "~/bower_components/fastclick/lib/fastclick.js",
                      "~/bower_components/ckeditor/ckeditor.js",
                      "~/Scripts/toastr.js",
                      //"~/Scripts/JSLINQ-vsdoc.js",
                      "~/Scripts/JSLINQ.js",
                      "~/Scripts/LINQ_JS/LINQ_JS.js",
                      //"~/Scripts/linq-vsdoc.js",
                      //"~/Scripts/linq.js",//
                      //"~/Scripts/jquery.linq-vsdoc.js",
                      //"~/Scripts/jquery.linq.js",//
                      "~/Scripts/jquery.blockUI.js",
                       //"~/Scripts/sweetalert.min.js",
                       "~/Scripts/jspdf.js",
                        "~/Scripts/html2canvas.js",
                         "~/Scripts/pdfmake.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/angular-scripts").Include(
                    "~/Scripts/angular.js",
                    "~/Scripts/angular-sanitize.js",
                    "~/Scripts/angular-cookies.js",
                    "~/Scripts/angular-loader.js",
                    "~/Scripts/angular-route.js",
                    "~/Scripts/angular-messages.js",
                    "~/Scripts/angular-ui/ui-bootstrap.js",
                    "~/Scripts/angular-ui/ui-bootstrap-tpls.js",
                    "~/bower_components/angularjs-dropdown-multiselect/src/angularjs-dropdown-multiselect.js",
                    "~/bower_components/angular-ui-select/dist/select.js",
                    "~/bower_components/angular-ui-select2/src/select2.js",
                    "~/bower_components/ng-remote-validate/release/ngRemoteValidate.js",
                    "~/Scripts/date.format.js"
                //"~/bower_components/mdr-angular-select2/dist/mdr-select2.js"
                //"~/bower_components/multiplex.js/build/multiplex.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/con_ser/angular-controllers-services").Include(
                 "~/Scripts/app.js",
                 "~/Scripts/angular-delmon-service.js",
                 "~/Scripts/angular-delmon-directive.js",
                 "~/Scripts/Services/AspNetUser.js",
                 "~/Scripts/Services/AspNetRole.js",
                 "~/Scripts/Services/Tenant.js",
                 "~/Scripts/Services/SubMenu.js",
                 "~/Scripts/Services/MenuAccessPolicy.js",
                 "~/Scripts/Services/CodeValue.js",
                  "~/Scripts/Services/Message.js",
                 "~/AngularControllers/AspNetUserController.js",
                 "~/AngularControllers/RoleController.js",
                 "~/AngularControllers/TenantController.js",
                 "~/AngularControllers/SubMenuController.js",
                 "~/AngularControllers/MenuAccessPolicyController.js",
                 "~/AngularControllers/MessageController.js"
                ));


#if DEBUG
            BundleTable.EnableOptimizations = SHF.Helper.busConstant.Misc.FALSE;
#endif

#if !DEBUG
              BundleTable.EnableOptimizations = SHF.Helper.busConstant.Misc.FALSE;
#endif

        }
    }
}