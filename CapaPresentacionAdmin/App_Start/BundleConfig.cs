using System.Web;
using System.Web.Optimization;

namespace CapaPresentacionAdmin
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new Bundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new Bundle("~/bundles/complementos").Include(
            "~/Scripts/fontawesome/all.min.js",
            "~/Scripts/DataTables/jquery.dataTables.js",
            "~/Scripts/DataTables/dataTables.resposive.js",
            "~/Scripts/loadingoverlay/loadingoverlay.min.js",
            "~/Scripts/sweetalert.min.js",
            "~/Scripts/jquery.validate.js",
            "~/Scripts/jquery-ui.js",
            "~/Scripts/scripts.js"));

            //dataTables.resposive.js", esto nos permite visualizar nuestra tabla en un entorno movil para ajustarse al tamano de nuesto movil 

            // bundles.Add(new Bundle("~/bundles/jqueryval").Include(
            //             "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información sobre los formularios.  De esta manera estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            // bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //Agregar bundle
            //Quitar la palabra script del Bundle

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.bundle.js"));

            //Eliminar archivo bootstrap.css

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Site.css",
                      "~/Content/DataTables/css/jquery.dataTables.css",
                      "~/Content/DataTables/css/reponsive.dataTables.css",
                      "~/Content/sweetalert.css",
                      "~/Content/jquery-ui.css"
                      ));
        }
    }
}
