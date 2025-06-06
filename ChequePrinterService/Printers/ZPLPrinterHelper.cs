using ChequePrinterService.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChequePrinterService.Printers
{
    public static class ZPLPrinterHelper
    {
        public static bool Print(string printerName, string zplCode)
        {
            return RawPrinterHelper.Print(printerName, zplCode);
        }
    }
}
