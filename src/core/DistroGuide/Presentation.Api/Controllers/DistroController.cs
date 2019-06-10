using DistroGuide.Domain.Services;
using DistroGuide.Domain.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DistroGuide.Presentation.Api.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class DistroController : ControllerBase
    {
        private readonly IDistroService searchDistroService;

        public DistroController(IDistroService searchDistroService)
        {
            this.searchDistroService = searchDistroService;
        }

        [Route("for-search")]
        [HttpGet]
        public ActionResult<List<DistroSearchItemDto>> Get(string term)
        {
            return this.searchDistroService.GetDistrosByTerm(term ?? string.Empty);
        }
    }
}
