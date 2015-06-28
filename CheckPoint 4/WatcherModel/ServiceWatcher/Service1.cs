using FillFolderInDatabase;
using System.ServiceProcess;
using System.Threading;

namespace ServiceWatcher
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        private WatcherFolder _watcherFolder = new WatcherFolder(@"C:\Наташа");
        protected override void OnStart(string[] args)
        {
            Thread.Sleep(20000);
           _watcherFolder.Run();
        }

        protected override void OnStop()
        {
            _watcherFolder.Stop();
        }
    }
}
