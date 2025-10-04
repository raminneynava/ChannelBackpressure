namespace ChannelBackpressure
{
    public class WorkItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Payload { get; set; } = string.Empty;
    }
}
