using System.Threading.Channels;


namespace ChannelBackpressure;
public class WorkProcessorService : BackgroundService
{
    private readonly ChannelReader<WorkItem> _reader;
    private readonly ILogger<WorkProcessorService> _logger;

    public WorkProcessorService(WorkQueueService queue, ILogger<WorkProcessorService> logger)
    {
        _reader = queue.Reader;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await foreach (var item in _reader.ReadAllAsync(stoppingToken))
        {
            _logger.LogInformation("Processing item {Id} with payload: {Payload}", item.Id, item.Payload);
            await Task.Delay(2000, stoppingToken); // شبیه‌سازی کار سنگین
        }
    }
}
