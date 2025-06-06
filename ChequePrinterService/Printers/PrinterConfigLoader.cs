using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChequePrinterService.Printers
{
    public class PrinterConfigLoader
    {
        public static PrinterConfig Load()
        {
            string name = ConfigurationManager.AppSettings["PrinterName"];
            string typeString = ConfigurationManager.AppSettings["PrinterType"];

            PrinterType type;
            if (!Enum.TryParse(typeString, true, out type))
            {
                type = PrinterType.WINDOWS_GDI; // default fallback
            }

            return new PrinterConfig
            {
                PrinterName = name,
                Type = type
            };
        }
    }
}
