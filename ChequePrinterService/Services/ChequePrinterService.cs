using ChequePrinterService.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChequePrinterService.Services
{
    public static class ChequePrinterService
    {
        public static string PrintCheque(Dictionary<string, string> chequeData, string template,int leafCount)
        {
            try
            {
                // Step 1: Format the template using data
                string formattedCheque = TemplateFormatter.FormatTemplate(template, chequeData,leafCount) + "\r\n\r\n";

                // Step 2: Get printer name from config
                string printerName = ConfigurationManager.AppSettings["PrinterName"];
                if (string.IsNullOrWhiteSpace(printerName))
                {
                    return "Error: PrinterName is not configured in App.config";
                }

                // Step 3: Attempt to print
                bool success = RawPrinterHelper.Print(printerName, formattedCheque);
                if (success)
                {
                    return formattedCheque;
                }
                else
                {
                    // Printer failure fallback
                    return "Printer not available. Here's the formatted cheque:\n\n" + formattedCheque;
                }
            }
            catch (Exception ex)
            {
                return "Error printing cheque: " + ex.Message;
            }
        }
    }
    // TemplateFormatter class from earlier

    public class ChequeModel
    {
        public string PayeeName { get; set; }
        public string AccountNumber { get; set; }
        public decimal Amount { get; set; }
        public int LeafCount { get; set; }
        public string Date { get; set; }
    }

}
