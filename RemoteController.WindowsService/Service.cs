using System;
using PeterKottas.DotNetCore.WindowsService.Base;
using PeterKottas.DotNetCore.WindowsService.Interfaces;
using RemoteController.Domain.Interfaces;

namespace RemoteController.WindowsService
{
    public sealed class Service : MicroService, IMicroService
    {
        private readonly IMicroServiceController _microServiceController;
        private readonly IPowerShellWorker _powerShellWorker;

        public Service(IMicroServiceController microServiceController ,IPowerShellWorker powerShellWorker)
        {
            _microServiceController = microServiceController;
            _powerShellWorker = powerShellWorker;
        }

        public void Start()
        {
            StartBase();

            _powerShellWorker.ReadOutput();

            //Timers.Start("Commands", 200, () =>
            //{
            //    powerShell.ReadOutput();
            //});

            //Timers.Start("Poller", 1000, () =>
            //{
            //    Console.WriteLine($"Polling at {DateTime.Now:o}");
            //});
        }

        public void Stop()
        {
            StopBase();
            Console.WriteLine("Stopped");
        }
    }
}
