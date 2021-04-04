namespace HDO.Services.Background
{
    using global::Services.Background.Contracts;
    using Microsoft.Extensions.Logging;
    using Models.Input;
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    public class DelayedTask : IDelayedTask
    {

        private readonly IStatisticService _statisticService;

        private FileSystemWatcher _fileSystemWatcher;
        private readonly ILogger<DelayedTask> _logger;
        private bool isCreated;

        public DelayedTask(IStatisticService statisticService, ILogger<DelayedTask> logger)
        {
            _statisticService = statisticService;
            _logger = logger;
        }
       /* public async Task DoWork(CancellationToken token)
        {
            while (true)
            {
                await StartAsync(token);
                await Task.Delay(TimeSpan.FromMinutes(1));
            }
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Service startup.");
            _fileSystemWatcher = new FileSystemWatcher(@"/myfolder/myfolder2");
            _fileSystemWatcher.IncludeSubdirectories = true;

            _fileSystemWatcher.Filter = "*.text";
            _fileSystemWatcher.Created += (e, args) => _logger.LogWarning("StartAsync watcher: {0}", args.FullPath);
            _fileSystemWatcher.EnableRaisingEvents = true;

            return StartAsync(cancellationToken);
        }


        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stopping Service");

            await StopAsync(cancellationToken);
        }

        protected async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Service Execute.");

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Keep alive: {time}", DateTimeOffset.Now);
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }

            _logger.LogInformation("Service Execute stopped.");
        }
       */
         public async Task DoWork(CancellationToken token)
         {                 
           /*  while (true)
             {
                await ExecuteScanner();

                if(isCreated)
                await ExecuteWork();

                await Task.Delay(TimeSpan.FromMinutes(1));
             }*/
         }

        private async Task ExecuteWork()
        {
            var Model = new StatisticInputModel()
            {
                MoviesCount = 1
            };

           await _statisticService.Update(Model);
           isCreated = false;
        }

        public async Task ExecuteScanner()
         {
            using var watcher = new FileSystemWatcher(@"C:\source\movies");

            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;

            watcher.NotifyFilter = NotifyFilters.Attributes
                                 | NotifyFilters.CreationTime
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.Security
                                 | NotifyFilters.Size;

            watcher.Changed += OnChanged;
            watcher.Created += OnCreated;
          //  watcher.Deleted += OnDeleted;
            watcher.Renamed += OnRenamed;
            watcher.Error += OnError;

            watcher.Filter = "1.txt";


        }
         private static void OnChanged(object sender, FileSystemEventArgs e)
         {
             if (e.ChangeType != WatcherChangeTypes.Changed)
             {
                 return;
             }
           //  Console.WriteLine($"Changed: {e.FullPath}");
         }

         private static void OnCreated(object sender, FileSystemEventArgs e)
         {
             string value = $"Created: {e.FullPath}";
            // isCreated = true;
         }

      //   private static void OnDeleted(object sender, FileSystemEventArgs e) =>
    //    PrintException(e.GetException());

         private static void OnRenamed(object sender, RenamedEventArgs e)
         {
            // Console.WriteLine($"Renamed:");
           //  Console.WriteLine($"    Old: {e.OldFullPath}");
            // Console.WriteLine($"    New: {e.FullPath}");
         }

         private static void OnError(object sender, ErrorEventArgs e) =>
             PrintException(e.GetException());

         private static void PrintException(Exception? ex)
         {
             if (ex != null)
             {
               //  Console.WriteLine($"Message: {ex.Message}");
                // Console.WriteLine("Stacktrace:");
               //  Console.WriteLine(ex.StackTrace);
               //  Console.WriteLine();
                 PrintException(ex.InnerException);
             }
         }
    }
    public interface IDelayedTask
    {
        Task DoWork(CancellationToken stoppingToken);
    }
}

/*public abstract class BackgroundService : IHostedService, IDisposable
{
    private Task _executingTask;
    private readonly CancellationTokenSource _stoppingCts = new CancellationTokenSource();

    protected abstract Task ExecuteAsync(CancellationToken stoppingToken);

    public virtual Task StartAsync(CancellationToken cancellationToken)
    {
        _executingTask = ExecuteAsync(_stoppingCts.Token);

        if (_executingTask.IsCompleted)
        {
            return _executingTask;
        }

        return Task.CompletedTask;
    }

    public virtual async Task StopAsync(CancellationToken cancellationToken)
    {
        if (_executingTask == null)
        {
            return;
        }

        try
        {
            _stoppingCts.Cancel();
        }
        finally
        {
            await Task.WhenAny(_executingTask, Task.Delay(Timeout.Infinite, cancellationToken));
        }

    }

    public virtual void Dispose()
    {
        _stoppingCts.Cancel();
 }
}

 public class SystemController : Controller
{
    private readonly RecureHostedService _recureHostedService;

    public SystemController(IHostedService hostedService)
    {
        _recureHostedService = hostedService as RecureHostedService;
    }
    [HttpGet(ApiRoutes.System.Start)]
    public IActionResult Start()
    {
        Console.WriteLine("Start Service");
        _recureHostedService.StartAsync(new CancellationToken());
        return Ok();
    }

    [HttpGet(ApiRoutes.System.Stop)]
    public IActionResult Stop()
    {
        Console.WriteLine("Stop Service");
        Console.WriteLine(_recureHostedService == null);
        _recureHostedService.StopAsync(new CancellationToken());
        return Ok();
    }
}*/