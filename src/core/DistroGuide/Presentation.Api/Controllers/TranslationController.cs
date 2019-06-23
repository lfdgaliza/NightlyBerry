using DistroGuide.Domain.Services;
using DistroGuide.Domain.Services.Dto;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public ActionResult<Dictionary<string, string>> GetModule(string moduleName)
        {
            var locale = Request.HttpContext.Features.Get<IRequestCultureFeature>();
            var language = locale.RequestCulture.UICulture.ToString();

            return this.translationService.GetModuleTranslation(moduleName, language);
        }

        [Route("components")]
        [HttpGet]
        public ActionResult<TranslationBundleDto> GetComponentsTranslation()
        {
            var locale = Request.HttpContext.Features.Get<IRequestCultureFeature>();
            var language = locale.RequestCulture.UICulture.ToString();

            return this.translationService.GetComponentsTranslation(language);
        }
    }
}
