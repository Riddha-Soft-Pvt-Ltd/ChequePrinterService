using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChequePrinterService.Utilities
{
    public class TemplateFormatter
    {
        public static string FormatTemplate(string template, Dictionary<string, string> values,int leafCount)
        {
            var formattedList = new List<string>();
            for (int i = 0; i < leafCount; i++)
            {
                string temp = template;
                foreach (var pair in values)
                {
                    temp = temp.Replace("{" + pair.Key + "}", pair.Value);
                }
                formattedList.Add(temp);
            }

            return string.Join("",formattedList);
        }
    }
}
