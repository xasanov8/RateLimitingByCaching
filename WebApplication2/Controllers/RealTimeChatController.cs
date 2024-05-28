using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RealTimeChatController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hubContext;

        public RealTimeChatController(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] Message message)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", message.User, message.Content);
            return Ok(message.User);
        }
    }
}
