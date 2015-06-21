using System;
using System.IO;
using System.Threading.Tasks;

namespace FillFolderInDatabase
{
    public class WatcherFolder
    {
        private FileSystemWatcher _watcher;

        public WatcherFolder(string pathFolder)
        {
            _watcher=new FileSystemWatcher(pathFolder);
            _watcher.Filter = "*.csv";
            //_watcher.Changed += new FileSystemEventHandler(OnChanged);
            _watcher.Created += OnAdd;
            _watcher.Deleted +=OnDelete;
            //_watcher.Renamed += new RenamedEventHandler(OnRenamed);
        }

        public void Run()
        {
            _watcher.EnableRaisingEvents = true;
        }

        private void OnAdd(object sender, FileSystemEventArgs e)
        {
            AddAsync(e.FullPath);
           // Add(e.FullPath);
            Console.WriteLine("finish onAdd");
        }

        private async void AddAsync(string path)
        {
            await Task.Factory.StartNew(Add, path);
        }

        private void Add(object path)
        {
            var parser = new Parser((string)path);
            var fillInDatabase = new FillInDatabase();
            fillInDatabase.AddOrders(parser.Orders);
        }

        private void OnDelete(object sender, FileSystemEventArgs e)
        {

        }
    }
}
