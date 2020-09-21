using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

// following https://codeopinion.com/self-host-asp-net-web-api/

namespace Webcam_WS
{
    public partial class WinServiceBase : ServiceBase
    {
        private IDisposable _webapp;
        public WinServiceBase()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            _webapp = WebApp.Start<Startup>("http://localhost:3000");
        }

        protected override void OnStop()
        {
            _webapp.Dispose();
        }
    }
}
