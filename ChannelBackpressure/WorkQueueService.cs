using System.Threading.Channels;


namespace ChannelBackpressure;
public class WorkQueueService
{
    private readonly Channel<WorkItem> _channel;

    public WorkQueueService()
    {
        var options = new BoundedChannelOptions(10) // فقط 10 کار همزمان
        {
            FullMode = BoundedChannelFullMode.Wait // اگر پر شد → منتظر بمان
        };
        _channel = Channel.CreateBounded<WorkItem>(options);
    }

    public ChannelWriter<WorkItem> Writer => _channel.Writer;
    public ChannelReader<WorkItem> Reader => _channel.Reader;
}
