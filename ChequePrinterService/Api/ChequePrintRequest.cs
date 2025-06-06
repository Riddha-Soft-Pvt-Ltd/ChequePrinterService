using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChequePrinterService.Api
{
    internal class ChequePrintRequest
    {
        public Dictionary<string, string> Data { get; set; }
        public string Template { get; set; }
        public int LeafCount { get; set; }
    }
}
