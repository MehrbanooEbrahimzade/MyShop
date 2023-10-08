using Application.Dtos;
using Microsoft.Extensions.Hosting;
using Quartz;
using RestSharp;
using System;
using System.Net;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ApiStarter : IHostedService
    {
        //    private readonly ISchedulerFactory _schedulerFactory;
        //    private IScheduler _scheduler;


        //    public async Task StartAsync(CancellationToken cancellationToken)
        //    {

        //        var gap = 10000;

        //        _scheduler = await _schedulerFactory.GetScheduler(cancellationToken);

        //        await _scheduler.Start(cancellationToken);

        //        IJobDetail job = JobBuilder.Create<UpdateInventoryJob>()
        //            .Build();

        //        ITrigger trigger = TriggerBuilder.Create()
        //            .StartNow()
        //            .WithSimpleSchedule(x => x.WithInterval(TimeSpan.FromMilliseconds(gap))
        //            .RepeatForever())
        //            .ForJob(job)
        //            .Build();


        //        await _scheduler.ScheduleJob(job, trigger, cancellationToken);

        //        await _scheduler.ResumeAll(cancellationToken);


        //    }

        //    public async Task StopAsync(CancellationToken cancellationToken)
        //    {

        //        await _scheduler.Shutdown(cancellationToken);

    //}


}

}