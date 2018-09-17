using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Connections.Client;
using Microsoft.AspNetCore.SignalR.Client;
using PeterKottas.DotNetCore.WindowsService.Base;
using PeterKottas.DotNetCore.WindowsService.Interfaces;
using RemoteController.Domain.Interfaces;

namespace RemoteController.WindowsService
{
    public sealed class Service : MicroService, IMicroService
    {
        private readonly IMicroServiceController _microServiceController;
        private readonly IPowerShellWorker _powerShellWorker;
        private static HubConnection _connection;

        public Service(IMicroServiceController microServiceController ,IPowerShellWorker powerShellWorker)
        {
            _microServiceController = microServiceController;
            _powerShellWorker = powerShellWorker;
        }

        public void Start()
        {
            StartBase();

            _connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:44393/hub")
                .Build();

            var teste = new Thread(async () =>
                await ConnectToServer()
            ); 

            teste.Start();

            //_powerShellWorker.ReadOutput();

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

        public static async Task<int> ConnectToServer()
        {
            var baseUrl = "http://localhost:44393/hub";

            Console.WriteLine("Conectando ao servidor");

            var httpConnection = new HttpConnection(new Uri(baseUrl));

            var connection = new HubConnectionBuilder()
                .WithUrl(baseUrl)
                .Build();

            try
            {
                await connection.StartAsync();

                Console.WriteLine("------ Connectado ao servidor ---------");
            }
            catch (AggregateException aex) when (aex.InnerExceptions.All(e => e is OperationCanceledException))
            {
            }
            catch (OperationCanceledException)
            {
            }
            finally
            {
                await connection.DisposeAsync();
            }

            return 0;
        }
    }
}
