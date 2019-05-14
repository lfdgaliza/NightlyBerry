using System.Collections.Generic;
using DistroGuide.Domain.Services;
using DistroGuide.Domain.Services.Dto;
using Microsoft.AspNetCore.Mvc;

namespace DistroGuide.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
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
