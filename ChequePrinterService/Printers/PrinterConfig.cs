using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChequePrinterService.Printers
{
    public enum PrinterType
    {
        WINDOWS_GDI, // Office Printers
        RAW_TEXT,    // Dot-matrix (e.g., Epson LX/LQ)
        ESC_POS,     // POS Printers (e.g., Epson TM-T20)
        ZPL          // Zebra Label Printers
    }

    public class PrinterConfig
    {
        public string PrinterName { get; set; }
        public PrinterType Type { get; set; }
    }
}
