using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RemoteController.Application.ViewModels
{
    public class MachineViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        [DisplayName("Endereço MAC")]
        public string MacAddress { get; set; }

        [DisplayName("Endereço Ip")]
        public string IpAddress { get; set; }

        public string Antivirus { get; set; }

        [DisplayName("Firewall ativo?")]
        public bool IsFirewallActive { get; set; }

        [DisplayName("Maquina disponível?")]
        public bool IsAvailable { get; set; }

        [DisplayName("Versão do Windows")]
        public string WindowsVersion { get; set; }

        [DisplayName("Versão do .NET Framework")]
        public string DotNetFrameworkVersion { get; set; }

        [DisplayName("Espaço usado no HD")]
        public double SpaceHdUsed { get; set; }

        [DisplayName("Espaço total do HD")]
        public double HdSize { get; set; }
    }
}
