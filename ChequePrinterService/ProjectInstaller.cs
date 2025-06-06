using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace ChequePrinterService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        private ServiceProcessInstaller processInstaller;
        private ServiceInstaller serviceInstaller;
        public ProjectInstaller()
        {
            InitializeComponent();
            processInstaller = new ServiceProcessInstaller();
            serviceInstaller = new ServiceInstaller();

            // Set the account that the service will run under
            processInstaller.Account = ServiceAccount.LocalSystem;

            // Set service properties
            serviceInstaller.ServiceName = "ChequePrinterService";
            serviceInstaller.DisplayName = "Cheque Printer Windows Service";
            serviceInstaller.StartType = ServiceStartMode.Automatic;

            // Add installers to collection
            Installers.Add(processInstaller);
            Installers.Add(serviceInstaller);
        }
    }
}
