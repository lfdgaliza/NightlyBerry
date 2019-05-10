using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DistroGuide.Services;
using DistroGuide.VO;
using Microsoft.AspNetCore.Mvc;

namespace DistroGuide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistroController : ControllerBase
    {
        private readonly ISearchDistroService searchDistroService;

        public DistroController(ISearchDistroService searchDistroService)
        {
            this.searchDistroService = searchDistroService;
        }

        [Route("for-search")]
        [HttpGet]
        public ActionResult<IEnumerable<DistroSearchItemVO>> Get()
        {
            return this.searchDistroService.GetAllDistrosForSearch();
        }
    }
}
