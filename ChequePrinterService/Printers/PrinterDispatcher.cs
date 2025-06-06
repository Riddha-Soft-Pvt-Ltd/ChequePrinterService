using ChequePrinterService.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChequePrinterService.Printers
{
    public static class PrinterDispatcher
    {
        public static string Print(PrinterConfig config, string content)
        {
            switch (config.Type)
            {
                case PrinterType.WINDOWS_GDI:
                    return WindowsGDIPrinter.Print(config.PrinterName, content) ? "Printed via GDI" : "Failed";

                case PrinterType.RAW_TEXT:
                    return RawPrinterHelper.Print(config.PrinterName, content) ? "Printed RAW" : "Failed";

                case PrinterType.ESC_POS:
                    return ESCPosHelper.Print(config.PrinterName, content) ? "Printed POS" : "Failed";

                case PrinterType.ZPL:
                    return ZPLPrinterHelper.Print(config.PrinterName, content) ? "Printed ZPL" : "Failed";

                default:
                    return "Unsupported printer type.";
            }
        }
    }

}
