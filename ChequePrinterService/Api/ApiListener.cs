
using ChequePrinterService.Printers;
using ChequePrinterService.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChequePrinterService.Api
{
    public class ApiListener
    {
        private HttpListener _listener;
        private bool _running = true;

        public void Start()
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add("http://localhost:8080/");
            _listener.Start();
            
            //.Log("API Listener started on http://localhost:8080/");

            while (_running)
            {
                var context = _listener.GetContext();
                ThreadPool.QueueUserWorkItem(_ => HandleRequest(context));
            }
        }

        public void Stop()
        {
            _running = false;
            _listener.Stop();
        }

        private void HandleRequest(HttpListenerContext context)
        {
            try
            {
                var path = context.Request.Url.AbsolutePath.ToLower();
                string method = context.Request.HttpMethod.ToUpper();

                // CORS Headers
                context.Response.AddHeader("Access-Control-Allow-Origin", "*");
                context.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, OPTIONS");
                context.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type");

                if (method == "OPTIONS")
                {
                    context.Response.StatusCode = 200;
                    context.Response.Close();
                    return;
                }


                if (path == "/systeminfo")
                {
                    var info = Services.SystemInfoService.GetInfo();
                    context.Response.ContentType = "application/json";
                    // 🔴 You must add these headers:

                    using (var writer = new System.IO.StreamWriter(context.Response.OutputStream))
                        writer.Write(info);
                }
                else if (path == "/chequeprint" && context.Request.HttpMethod == "POST")
                {
                    using (var reader = new System.IO.StreamReader(context.Request.InputStream))
                    {
                        var json = reader.ReadToEnd();

                        // Deserialize JSON: expects { "template": "....", "data": { "Payee": "...", "Amount": "...", ... } }
                        dynamic input = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                        string template = input.template;
                        int leafCount = input.leafCount ?? 1; // Default to 1 leaf if not specified
                        Dictionary<string, string> chequeData = ((Newtonsoft.Json.Linq.JObject)input.data)
                                                                .ToObject<Dictionary<string, string>>();

                        // Replace placeholders in template with actual values
                        string formattedCheque = template;

                        formattedCheque = TemplateFormatter.FormatTemplate(template, chequeData, leafCount);

                        // Load printer config
                        var config = PrinterConfigLoader.Load();

                        // Try printing
                        string result;
                        bool success = false;

                        try
                        {
                            result = PrinterDispatcher.Print(config, formattedCheque);
                            success = result.Contains("Printed");
                        }
                        catch (Exception ex)
                        {
                            result = "Error: " + ex.Message;
                        }

                        // If printer failed, return formatted text as fallback
                        if (!success)
                        {
                            result = "Printer not available. Here's the cheque content:\n\n" + formattedCheque;
                        }

                        // Write response
                        using (var writer = new System.IO.StreamWriter(context.Response.OutputStream))
                        {
                            writer.Write(result);
                        }
                    }
                }
                else if (path == "/formattest" && context.Request.HttpMethod == "POST")
                {
                    using (var reader = new System.IO.StreamReader(context.Request.InputStream))
                    {
                        var json = reader.ReadToEnd();
                        var printRequest = JsonConvert.DeserializeObject<ChequePrintRequest>(json);

                        // Just format the cheque, don't print
                        string formatted = TemplateFormatter.FormatTemplate(printRequest.Template, printRequest.Data, printRequest.LeafCount);

                        using (var writer = new System.IO.StreamWriter(context.Response.OutputStream))
                            writer.Write(formatted);
                    }
                }
                else
                {
                    context.Response.StatusCode = 404;
                    context.Response.Close();
                }
            }
            catch (Exception ex) 
            {

                context.Response.StatusCode = 500;
                using (var writer = new System.IO.StreamWriter(context.Response.OutputStream))
                    writer.Write("Server error: " + ex.Message);
            }
        }
    }
}
