using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Model;
using WebApi.Models.Repositories;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly MessageRepository _repo;

        public MessageController(MessageRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("Messages")]
        public IActionResult Messages([FromBody] MessageRequest model)
        {
            var result = _repo.Messages(model.UserId,model.Take,model.Skip);
            return Ok(result);
        }
        [HttpPost("Read")]
        public IActionResult Read([FromBody] MessageRequest model)
        {
            var result = _repo.MessageRead(model.MessageId);
            return Ok(result);
        }
        [HttpPost("GetTotalInfo")]
        public IActionResult GetTotalInfo([FromBody] MessageRequest model)
        {
            var result = _repo.GetMessageInfo(model.UserId);
            return Ok(result);
        }
    }
}