using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ChequePrinterService.Utilities
{
    public static class Logger
    {
        public static void Log(string message)
        {
            try
            {
                // Get folder where your EXE is located
                string exeFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                // Define log file path inside that folder
                string logPath = Path.Combine(exeFolder, "log.txt");

                // Append log message with timestamp
                File.AppendAllText(logPath, $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}{Environment.NewLine}");
            }
            catch
            {
                // Optionally ignore or handle errors silently
            }
        }
    }

    public static class NetworkUtils
    {
        public static string GetMacAddress()
        {
            var interfaces = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces();
            foreach (var adapter in interfaces)
            {
                if (adapter.OperationalStatus == System.Net.NetworkInformation.OperationalStatus.Up)
                    return adapter.GetPhysicalAddress().ToString();
            }
            return "Unavailable";
        }
    }
}
