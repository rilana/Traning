using System;
using System.Globalization;
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
            //_watcher.Changed += OnReplace;
            _watcher.Created += OnAdd;
            _watcher.Deleted +=OnDelete;
            //_watcher.NotifyFilter = NotifyFilters.FileName;//| NotifyFilters.Size;
            //_watcher.Renamed += new RenamedEventHandler(OnRenamed);
        }

        public void Run()
        {
            _watcher.EnableRaisingEvents = true;
        }
        public void Stop()
        {
            _watcher.Created -= OnAdd;
            _watcher.Deleted -= OnDelete;
            _watcher.EnableRaisingEvents = false;
        }
        //private void OnReplace(object sender, FileSystemEventArgs e)
        //{
        //    Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
        //    AddAsync(e.FullPath);
        //    // Add(e.FullPath);
        //    Console.WriteLine("finish onAdd");
        //}

        private void OnAdd(object sender, FileSystemEventArgs e)
        {
            AddAsync(e.FullPath);
            Console.WriteLine("finish onAdd");
        }

        private async void AddAsync(string path)
        {
            await Task.Factory.StartNew(Add, path);
        }
        private object locker = new object();
        private void Add(object path)
        {
            var parser = new Parser((string)path);
            var fillInDatabase = new FillInDatabase(locker);
            fillInDatabase.AddOrders(parser.Orders);
        }

        private void OnDelete(object sender, FileSystemEventArgs e)
        {
            DeleteAsync(e.FullPath);
        }
        private async void DeleteAsync(string path)
        {
            Console.WriteLine("Delete");
            await Task.Factory.StartNew(Delete, path);
        }
        private void Delete(object path)
        {
            var val = Path.GetFileNameWithoutExtension((string)path).Split('_');
            var date = DateTime.ParseExact(val[1], "ddMMyyyy", CultureInfo.InvariantCulture);
            var fillInDatabase = new FillInDatabase(locker);
            fillInDatabase.DeleteOrders(val[0], date);
        }
    }
}
