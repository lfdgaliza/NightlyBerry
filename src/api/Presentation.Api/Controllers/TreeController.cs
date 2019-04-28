using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DistroGuide.Domain.Dto;
using DistroGuide.Domain.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentation.Api.Controllers
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
        public ActionResult<List<TreeDto>> Get()
        {
            return Ok(this.treeService.GenerateTree());
        }
    }
}
