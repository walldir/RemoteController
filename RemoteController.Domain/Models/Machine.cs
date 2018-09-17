using System.Collections;
using System.Collections.Generic;
using RemoteController.Domain.Core.Models;

namespace RemoteController.Domain.Models
{
    public class Machine : Entity
    {
        public string Name { get; set; }
        public string MacAddress { get; set; }
        public string IpAddress { get; set; }
        public string Antivirus { get; set; }
        public bool IsFirewallActive { get; set; }
        public bool IsAvailable { get; set; }
        public string WindowsVersion { get; set; }
        public string DotNetFrameworkVersion { get; set; }
        public double SpaceHdUsed { get; set; }
        public double HdSize { get; set; }

        public ICollection<Log> Logs { get; set; }
    }
}
