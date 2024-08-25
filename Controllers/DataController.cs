using BajajFinservTest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using BajajFinservTest.Repositories;

namespace BajajFinservTest.Controllers
{
    [Route("bfhl")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IDataRepository _dataRepository;

        public DataController(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpPost]
        public IActionResult PostData([FromBody] Dictionary<string, List<string>> request)
        {
            if (request == null || !request.ContainsKey("data") || request["data"] == null || !request["data"].Any())
            {
                return BadRequest(new { is_success = false, message = "Invalid input" });
            }

            try
            {
                var response = _dataRepository.ProcessData(request["data"]);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { is_success = false, error = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetOperationCode()
        {
            var response = _dataRepository.GetOperationCode();
            return Ok(response);
        }
    }
}
