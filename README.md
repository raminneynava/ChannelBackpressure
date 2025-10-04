# BoundedChannelDemo  

A demo project showcasing **.NET Channels** and how to use **bounded channels** to handle background jobs with built-in *backpressure*.  

## ✨ Features
- **Producer/Consumer** implementation using `System.Threading.Channels`  
- Prevents memory overuse (OOM) under heavy load  
- **BackgroundService** for safe and resilient job processing  
- **HTTP API** to enqueue work items  

## 📂 Project Structure
```
BoundedChannelDemo/
 ├─ Program.cs
 ├─ WorkItem.cs
 ├─ WorkQueueService.cs
 ├─ WorkProcessorService.cs
 └─ Controllers/
     └─ WorkController.cs
```

## 🚀 Run
```bash
dotnet run
```

Then enqueue a new job:  
```bash
curl -X POST http://localhost:5000/work/enqueue      -H "Content-Type: application/json"      -d "\"Hello Channel!\""
```

## 🛠 How It Works
- **Bounded Channel:** Holds up to 10 work items at once.  
- When the channel is full → producers naturally wait (backpressure).  
- A background consumer service processes jobs asynchronously.  

## ✅ Best Use Cases
- Webhook delivery queues  
- Email or notification processing  
- Offloading long-running jobs from web requests  

## 📖 References
- [Microsoft Docs - System.Threading.Channels](https://learn.microsoft.com/dotnet/api/system.threading.channels)  
- Real-world lessons from resilient system design under load  

---

👨‍💻 Built to practice **Backpressure concepts in .NET**  
