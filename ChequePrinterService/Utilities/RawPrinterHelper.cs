using ChequePrinterService.Printers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ChequePrinterService.Utilities
{
    public class RawPrinterHelper 
    {
        [StructLayout(LayoutKind.Sequential)]
        public class DOCINFOA
        {
            public string pDocName;
            public string pOutputFile;
            public string pDataType;
        }

        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA",
            SetLastError = true, CharSet = CharSet.Ansi,
            ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool OpenPrinter(string szPrinter, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter",
            SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA",
            SetLastError = true, CharSet = CharSet.Ansi,
            ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, int level, [In] DOCINFOA di);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter",
            SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter",
            SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter",
            SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "WritePrinter",
            SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, int dwCount, out int dwWritten);

        public static bool Print(string printerName, string data)
        {
            IntPtr pBytes = Marshal.StringToCoTaskMemAnsi(data);
            bool success = SendBytesToPrinter(printerName, pBytes, data.Length);
            Marshal.FreeCoTaskMem(pBytes);
            return success;
        }

        private static bool SendBytesToPrinter(string printerName, IntPtr pBytes, int count)
        {
            IntPtr hPrinter = IntPtr.Zero;
            DOCINFOA docInfo = new DOCINFOA { pDocName = "Cheque Print Job", pDataType = "RAW" };
            int written = 0;
            bool success = false;

            if (OpenPrinter(printerName, out hPrinter, IntPtr.Zero))
            {
                if (StartDocPrinter(hPrinter, 1, docInfo))
                {
                    if (StartPagePrinter(hPrinter))
                    {
                        success = WritePrinter(hPrinter, pBytes, count, out written);
                        EndPagePrinter(hPrinter);
                    }
                    EndDocPrinter(hPrinter);
                }
                ClosePrinter(hPrinter);
            }

            return success;
        }
    }
}
