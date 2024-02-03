using Coravel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaskScheduling.Coravel.Console;

var builder = Host.CreateApplicationBuilder();
builder.Services.AddScheduler();
//builder.Services.AddTransient<MyRepeatableTask>();

var application = builder.Build();
var services = application.Services;
services.UseScheduler(scheduler =>
{
    // scheduler.Schedule(() => Console.WriteLine("This was scheduled"))
    //     .EverySeconds(2);

    // scheduler.ScheduleAsync(async () =>
    //     {
    //         await Task.Yield();
    //         Console.WriteLine("This was scheduled asynchronously");
    //     })
    //     .EverySeconds(2);

    // scheduler.Schedule<MyRepeatableTask>()
    //     .EveryFiveSeconds();

    scheduler.ScheduleWithParams<MyRepeatableTask>("localhost")
        .EveryFiveSeconds()
        .PreventOverlapping("some-unique-id");
});


application.Run();