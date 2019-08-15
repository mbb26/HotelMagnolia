using System;
using System.Web.Http;
using System.Web.Mvc;
using Ulacit.Mandiola.API.Areas.HelpPage.ModelDescriptions;
using Ulacit.Mandiola.API.Areas.HelpPage.Models;

namespace Ulacit.Mandiola.API.Areas.HelpPage.Controllers
{
    /// <summary>The controller that will handle requests for the help page.</summary>
    public class HelpController : Controller
    {
        /// <summary>Name of the error view.</summary>
        private const string ErrorViewName = "Error";

        /// <summary>Initializes a new instance of the Ulacit.Mandiola.API.Areas.HelpPage.Controllers.HelpController class.</summary>
        public HelpController()
            : this(GlobalConfiguration.Configuration)
        {
        }

        /// <summary>Initializes a new instance of the Ulacit.Mandiola.API.Areas.HelpPage.Controllers.HelpController class.</summary>
        /// <param name="config">The configuration.</param>
        public HelpController(HttpConfiguration config)
        {
            Configuration = config;
        }

        /// <summary>Gets the configuration.</summary>
        /// <value>The configuration.</value>
        public HttpConfiguration Configuration { get; private set; }

        /// <summary>Gets the index.</summary>
        /// <returns>A response stream to send to the Index View.</returns>
        public ActionResult Index()
        {
            ViewBag.DocumentationProvider = Configuration.Services.GetDocumentationProvider();
            return View(Configuration.Services.GetApiExplorer().ApiDescriptions);
        }

        /// <summary>Apis.</summary>
        /// <param name="apiId">Identifier for the API.</param>
        /// <returns>A response stream to send to the API View.</returns>
        public ActionResult Api(string apiId)
        {
            if (!String.IsNullOrEmpty(apiId))
            {
                HelpPageApiModel apiModel = Configuration.GetHelpPageApiModel(apiId);
                if (apiModel != null)
                {
                    return View(apiModel);
                }
            }

            return View(ErrorViewName);
        }

        /// <summary>Resource model.</summary>
        /// <param name="modelName">Name of the model.</param>
        /// <returns>A response stream to send to the ResourceModel View.</returns>
        public ActionResult ResourceModel(string modelName)
        {
            if (!String.IsNullOrEmpty(modelName))
            {
                ModelDescriptionGenerator modelDescriptionGenerator = Configuration.GetModelDescriptionGenerator();
                ModelDescription modelDescription;
                if (modelDescriptionGenerator.GeneratedModels.TryGetValue(modelName, out modelDescription))
                {
                    return View(modelDescription);
                }
            }

            return View(ErrorViewName);
        }
    }
}