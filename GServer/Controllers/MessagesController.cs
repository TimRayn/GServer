using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private BaseContext db;

        public MessagesController(BaseContext context)
        {
            this.db = context;
            if (!db.Messages.Any())
            {
                db.Messages.Add(new Message {Text = "Default Message", Time = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds});
                db.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Message> GetMessages()
        {
            return db.Messages.ToList();
        }

        [HttpGet("{id}")]
        public IActionResult GetMessage(int id)
        {
            Message message = db.Messages.Find(id);
            return message == null ? NotFound() : (IActionResult)new ObjectResult(message);
        }

        [HttpPost]
        public IActionResult PostMessage([FromBody] Message message)
        {
            if (message == null) return BadRequest();

            db.Messages.Add(message);
            db.SaveChanges();
            return Ok(message);
        }

        [HttpPut]
        public IActionResult PutMessage([FromBody] Message message)
        {
            if (message == null) return BadRequest();
            if (!db.Messages.Any(x => x.Id == message.Id)) return NotFound();

            db.Update(message);
            db.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMessages(int id)
        {
            Message message = db.Messages.Find(id);
            if (message == null) return NotFound();
            db.Messages.Remove(message);
            db.SaveChanges();
            return Ok(message);
        }
    }
}