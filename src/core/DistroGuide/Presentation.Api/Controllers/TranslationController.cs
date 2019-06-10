using DistroGuide.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace DistroGuide.Presentation.Api.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class TranslationController : ControllerBase
    {
        private readonly ITranslationService translationService;

        public TranslationController(
            ITranslationService translationService)
        {
            this.translationService = translationService;
        }

        [Route("module/{moduleName}")]
        [HttpGet]
        public ActionResult<Dictionary<string, string>> GetModule(string moduleName, string[] language)
        {
            var locale = Request.HttpContext.Features.Get<IRequestCultureFeature>();
            var BrowserCulture = locale.RequestCulture.UICulture.ToString();

            var languages = Request.GetTypedHeaders()
                       .AcceptLanguage
                       ?.OrderByDescending(x => x.Quality ?? 1) // Quality defines priority from 0 to 1, where 1 is the highest.
                       .Select(x => x.Value.ToString())
                       .ToArray() ?? Array.Empty<string>();

            var y = CultureInfo.DefaultThreadCurrentUICulture.Name;

            throw new NotImplementedException();
            //Request.Cookies["dg-lang"]
            //return this.translationService.GetModuleTranslation(moduleName, language);
        }
    }
}
