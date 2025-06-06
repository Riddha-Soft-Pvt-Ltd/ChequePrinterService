using ChequePrinterService.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChequePrinterService.Printers
{
    public static class ESCPosHelper
    {
        public static bool Print(string printerName, string content)
        {
            string escContent = "\x1B@" + content + "\n\x1DVA\x00"; // Initialize + content + cut
            return RawPrinterHelper.Print(printerName, escContent);
        }
    }
}
