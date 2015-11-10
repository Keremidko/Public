using System.Web;
using System.Web.Optimization;

namespace Requirements_and_Design_environment
{
    public class BundleConfig
    {
        private const string LIBRARIES_PATH = "~/JS_Libraries/";

        private const string SCRIPTS_PATH = "~/Scripts/";

        private const string STYLES_PATH = "~/Styles/";

        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterLibraries(bundles);
            RegisterClientScripts(bundles);
            RegisterStyles(bundles);
        }

        private static void RegisterLibraries(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                LIBRARIES_PATH + "angular.js",
                LIBRARIES_PATH + "angular-cookies.js",
                LIBRARIES_PATH + "angular-ui-router.js",
                LIBRARIES_PATH + "angular-animate.js",
                LIBRARIES_PATH + "ui-tinymce.js",
                LIBRARIES_PATH + "ui-bootstrap-0.11.0.js"));

            bundles.Add(new ScriptBundle("~/bundles/tinymce").Include(
                LIBRARIES_PATH + "tinymce/js/tinymce/tinymce.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include((
                LIBRARIES_PATH + "jquery-1.10.2.js")));
        }

        private static void RegisterClientScripts(BundleCollection bundles)
        {
            //App bundle - bundle-a със всички модули за приложението
            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                SCRIPTS_PATH + "app.js"));

            bundles.Add(new ScriptBundle("~/bundles/app/controllers").Include(
                SCRIPTS_PATH + "/controllers/MenuController.js",
                SCRIPTS_PATH + "/controllers/AccountController.js",
                SCRIPTS_PATH + "/controllers/ProjectExplorerController.js",
                SCRIPTS_PATH + "/controllers/BaseController.js",
                SCRIPTS_PATH + "/controllers/WorkingAreaController.js",
                SCRIPTS_PATH + "/controllers/ToolboxController.js",
                SCRIPTS_PATH + "/controllers/DiagramController.js",
                SCRIPTS_PATH + "/controllers/modals/NewProjectController.js",
                SCRIPTS_PATH + "/controllers/modals/OpenProjectController.js",
                SCRIPTS_PATH + "/controllers/modals/ManageProjectsController.js",
                SCRIPTS_PATH + "/controllers/modals/SelectThemeController.js",
                SCRIPTS_PATH + "/controllers/modals/NewItemController.js",
                SCRIPTS_PATH + "/controllers/modals/SaveItemController.js"));

            bundles.Add(new ScriptBundle("~/bundles/app/services").Include(
                SCRIPTS_PATH + "/services/ModalService.js",
                SCRIPTS_PATH + "/services/AuthorizationService.js",
                SCRIPTS_PATH + "/services/DeserializationService.js",
                SCRIPTS_PATH + "/services/ProjectService.js",
                SCRIPTS_PATH + "/services/ToolsService.js",
                SCRIPTS_PATH + "/services/ErrorHandlingService.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/app/models").Include(
                SCRIPTS_PATH + "/models/Item.js"));

            bundles.Add(new ScriptBundle("~/bundles/app/filters").Include(
                SCRIPTS_PATH + "/filters/ProjectFilters.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/app/directives").Include(
                SCRIPTS_PATH + "/directives/ContextMenu.js",
                SCRIPTS_PATH + "/directives/Resizer.js",
                SCRIPTS_PATH + "/directives/StopPropagation.js",
                SCRIPTS_PATH + "/directives/DiagramView.js",
                SCRIPTS_PATH + "/directives/Contenteditable.js",
                SCRIPTS_PATH + "/directives/SvgTextInput.js",
                SCRIPTS_PATH + "/directives/Draggable.js",
                SCRIPTS_PATH + "/directives/Line/Line.js",
                SCRIPTS_PATH + "/directives/Text/Text.js",
                SCRIPTS_PATH + "/directives/Ellipse/Ellipse.js",
                SCRIPTS_PATH + "/directives/vector_drag/VectorDrag.js",
                SCRIPTS_PATH + "/directives/Rectangle/Rectangle.js",
                SCRIPTS_PATH + "/directives/ClassDiagram/ClassDiagram.js",
                SCRIPTS_PATH + "/directives/Comment/Comment.js",
                SCRIPTS_PATH + "/directives/SvgWrapper/SvgWrapper.js"));
        }

        private static void RegisterStyles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      STYLES_PATH + "Site.css"));
        }

    }
}
