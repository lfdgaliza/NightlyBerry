using System.Collections.Generic;
using DistroGuide.App_Domain.CrossCutting.VO;
using DistroGuide.App_Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace DistroGuide.Controllers
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
        public ActionResult<List<DistroSearchItemVO>> Get(string term)
        {
            return this.searchDistroService.GetDistrosByTerm(term ?? string.Empty);
        }
    }
}
