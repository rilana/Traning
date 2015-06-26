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
            _watcher.Created += OnAdd;
            _watcher.Deleted +=OnDelete;           
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
       
        private void OnAdd(object sender, FileSystemEventArgs e)
        {
            AddAsync(e.FullPath);
        }

        private async void AddAsync(string path)
        {
            await Task.Factory.StartNew(Add, path);
            Console.WriteLine("finish onAdd");
        }
       
        private void Add(object path)
        {
            var parser = new Parser((string)path);
            parser.FillOrderToBase();
        }

        private void OnDelete(object sender, FileSystemEventArgs e)
        {
            DeleteAsync(e.FullPath);
        }
        private async void DeleteAsync(string path)
        {
            await Task.Factory.StartNew(Delete, path);
            Console.WriteLine("finish onDelete");
        }
        private void Delete(object path)
        {
            var fillInDatabase = new OperationToDatabase();
            fillInDatabase.DeleteOrders(Path.GetFileNameWithoutExtension((string)path));
        }
    }
}
