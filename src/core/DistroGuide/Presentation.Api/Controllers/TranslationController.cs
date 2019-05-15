using System;
using System.Collections.Generic;
using DistroGuide.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace DistroGuide.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
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
        public ActionResult<Dictionary<string, string>> GetModule(string moduleName, string lang)
        {
            return this.translationService.GetModuleTranslation(moduleName, lang);
        }
    }
}
