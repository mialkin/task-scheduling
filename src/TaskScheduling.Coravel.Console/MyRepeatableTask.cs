using Coravel.Invocable;
using Microsoft.Extensions.Logging;

namespace TaskScheduling.Coravel.Console;

public class MyRepeatableTask : IInvocable
{
    private readonly ILogger<MyRepeatableTask> _logger;
    private readonly string _connectionString;

    public MyRepeatableTask(ILogger<MyRepeatableTask> logger, string connectionString)
    {
        _logger = logger;
        _connectionString = connectionString;
    }

    public async Task Invoke()
    {
        await Task.Yield();
        _logger.LogInformation("Hello from invocable {connectionString}", _connectionString);
    }
}