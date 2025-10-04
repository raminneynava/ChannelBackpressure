using Microsoft.AspNetCore.Mvc;
using System.Threading.Channels;

namespace ChannelBackpressure.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkController : ControllerBase
    {
        private readonly ChannelWriter<WorkItem> _writer;
        private readonly ILogger<WorkController> _logger;

        public WorkController(WorkQueueService queue, ILogger<WorkController> logger)
        {
            _writer = queue.Writer;
            _logger = logger;
        }

        [HttpPost("enqueue")]
        public async Task<IActionResult> Enqueue([FromBody] string payload)
        {
            var item = new WorkItem { Payload = payload };

            try
            {
                await _writer.WriteAsync(item);
                _logger.LogInformation("Queued item {Id}", item.Id);
                return Accepted(new { item.Id });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to enqueue item");
                return StatusCode(500, "Failed to enqueue");
            }
        }
    }
}
