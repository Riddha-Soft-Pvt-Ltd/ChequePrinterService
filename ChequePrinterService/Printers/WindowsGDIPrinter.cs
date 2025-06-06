using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChequePrinterService.Printers
{
    public  class WindowsGDIPrinter
    {
        private static  string _content;

        public static  bool Print(string printerName, string content)
        {
            _content = content;

            try
            {
                PrintDocument pd = new PrintDocument();
                pd.PrinterSettings.PrinterName = printerName;
                pd.PrintPage += (s, e) =>
                {
                    Font font = new Font("Courier New", 10); // Monospaced
                    e.Graphics.DrawString(_content, font, Brushes.Black, new PointF(10, 10));
                };
                pd.Print();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
