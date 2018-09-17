using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;

namespace RemoteController.WindowsService
{
    public static class MachineInformation
    {
        public static string MacAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            var macAdress = string.Empty;

            foreach (var networkInterface in nics)
            {
                if (!string.IsNullOrEmpty(macAdress)) continue;

                macAdress = networkInterface.GetPhysicalAddress().ToString();
            }

            const string regex = "(.{2})(.{2})(.{2})(.{2})(.{2})(.{2})";
            const string replace = "$1:$2:$3:$4:$5:$6";
            var macAddressFormated = Regex.Replace(macAdress, regex, replace);

            return macAddressFormated;
        }

        public static string WindowsVersion()
        {
            return Environment.OSVersion.VersionString;
        }

        public static string IpAddress()
        {
            var hostName = Dns.GetHostName();

            return Dns.GetHostEntry(hostName).AddressList
                .FirstOrDefault(a => a.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)?.ToString();
        }

        public static string Name()
        {
            return Dns.GetHostName();
        }

        public static bool FirewallActive()
        {
            Type tpNetFirewall = Type.GetTypeFromProgID
                ("HNetCfg.FwMgr", false);

            INetFwMgr mgrInstance = (INetFwMgr)Activator
                .CreateInstance(tpNetFirewall);

            bool blnEnabled = mgrInstance.LocalPolicy
                .CurrentProfile.FirewallEnabled;
        }
    }
}
