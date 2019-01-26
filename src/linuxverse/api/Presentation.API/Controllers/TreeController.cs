
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using NightlyBerry.LinuxTree.Domain.Core.Services;
using NightlyBerry.LinuxTree.Domain.Output;

namespace Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreeController : ControllerBase
    {
        private readonly ITreeService treeService;

        public TreeController(ITreeService treeService)
        {
            this.treeService = treeService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<List<TreeDTO>> Get()
        {
            return Ok(this.treeService.GenerateTree());
        }
    }
}
