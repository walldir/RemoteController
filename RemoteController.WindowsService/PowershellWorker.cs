using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using RemoteController.Domain.Interfaces;

namespace RemoteController.WindowsService
{
    public sealed class PowerShellWorker : IPowerShellWorker
    {
        private readonly Process _powerShellProcess;

        public PowerShellWorker()
        {
            _powerShellProcess = new Process
            {
                StartInfo =
                {
                    FileName = "powershell",
                    RedirectStandardInput = true,
                    ErrorDialog = false,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true
                }
            };

            _powerShellProcess.Start();
            ReadInput("dir");
            ReadInput("cd");
        }

        public void ReadInput(string command)
        {
            var standardInput = _powerShellProcess.StandardInput;
;
            standardInput.WriteLine(command);
        }

        public void ReadOutput()
        {
            _powerShellProcess.BeginOutputReadLine();
            _powerShellProcess.OutputDataReceived += (sender, outputLine) =>
            {
                if (outputLine.Data == null) return;

                Console.WriteLine(outputLine.Data);
            };
        }
    }
}
