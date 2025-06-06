using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChequePrinterService.Services
{
    public static class SystemInfoService
    {
        public static string GetInfo()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            var ip = "Unavailable";
            foreach (var ipAddress in host.AddressList)
            {
                if (ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    ip = ipAddress.ToString();
                    break;
                }
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                MachineName = Environment.MachineName,
                UserName = Environment.UserName,
                IP = ip,
                OSVersion = Environment.OSVersion.ToString(),
                MAC = Utilities.NetworkUtils.GetMacAddress()
            });
        }
    }
}
