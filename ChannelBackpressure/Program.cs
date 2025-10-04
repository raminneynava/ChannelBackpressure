using ChannelBackpressure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<WorkQueueService>();
builder.Services.AddHostedService<WorkProcessorService>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();