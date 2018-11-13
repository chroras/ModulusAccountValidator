using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ValidatingAccountNumbers.Models;
using ValidatingAccountNumbers.Services;

namespace ValidatingAccountNumbers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidationController : ControllerBase
    {

        private readonly IAlgorithmsInterface _algorithmsInterface;

        public ValidationController(IAlgorithmsInterface algorithmsInterface)
        {
            _algorithmsInterface = algorithmsInterface;
        }

        [HttpGet]
        public async Task<IActionResult> Index(AccountModel model)
        {
            var result = await _algorithmsInterface.Mod();

            if (result == false)
                return BadRequest(false);

            return Ok(true);
        }
    }
}
