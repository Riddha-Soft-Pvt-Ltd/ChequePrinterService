using ChequePrinterService.Api;
using ChequePrinterService.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChequePrinterService
{
    partial class RiddhaPrintService : ServiceBase
    {
        private Thread _apiThread;
        private Api.ApiListener _apiListener;
        public RiddhaPrintService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Logger.Log("Service starting...");

            _apiListener = new Api.ApiListener();
            _apiThread = new Thread(_apiListener.Start);
            _apiThread.Start();
        }


        protected override void OnStop()
        {
            Logger.Log("Service stopping...");

            if (_apiListener != null)
                _apiListener.Stop();

            if (_apiThread != null && _apiThread.IsAlive)
                _apiThread.Abort();
        }
    }
}
