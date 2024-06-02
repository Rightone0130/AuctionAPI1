using Microsoft.AspNetCore.Mvc;

namespace AuctionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BidController : ControllerBase
    {
        private readonly RabbitMQService _rabbitMQService;

        public BidController(RabbitMQService rabbitMQService)
        {
            _rabbitMQService = rabbitMQService;
        }

        [HttpPost("submit")]
        public IActionResult SubmitBid([FromBody] string bid)
        {
            _rabbitMQService.Publish("bidding_queue", bid);
            return Ok(new { Message = "Bid submitted", Bid = bid });
        }

         [HttpGet("receive")]
        public IActionResult ReceiveBid()
        {
            List<string> messages = _rabbitMQService.Consume("bidding_queue");
            return Ok(new { Messages = messages });
        }
    }
}
