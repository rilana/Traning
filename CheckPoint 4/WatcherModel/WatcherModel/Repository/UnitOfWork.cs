using System.Data.Entity;
using System.Linq;

namespace WatcherModel.Repository
{
    public class UnitOfWork
    {
        protected DbContext Context;

        private IRepository<Order> _reposOrder;
        private IRepository<Manager> _reposManager;
        private IRepository<NameFile> _reposNameFile;
        private IRepository<Client> _reposClient;
        private IRepository<Goods> _reposGoods;

        public UnitOfWork(DbContext context)
        {
            Context = context;
        }

        public IRepository<Order> ReposOrder
        {
            get
            {
                if (_reposOrder==null)
                    _reposOrder=new Repository<Order>(Context);
                return _reposOrder;
            }
        }

        public IRepository<Manager> ReposManager
        {
            get
            {
                if (_reposManager == null)
                    _reposManager = new Repository<Manager>(Context);
                return _reposManager;
            }
        }

        public IRepository<NameFile> ReposNameFile
        {
            get
            {
                if (_reposNameFile == null)
                    _reposNameFile = new Repository<NameFile>(Context);
                return _reposNameFile;
            }
        }

        public IRepository<Client> ReposClient
        {
            get
            {
                if (_reposClient == null)
                    _reposClient = new Repository<Client>(Context);
                return _reposClient;
            }
        }

        public IRepository<Goods> ReposGoods
        {
            get
            {
                if (_reposGoods == null)
                    _reposGoods = new Repository<Goods>(Context);
                return _reposGoods;
            }
        }

        #region return or creates a new
        public Manager GetManager(string name)
        {
            var manager = ReposManager.GetAll().FirstOrDefault(x => x.SecondName == name);
            if (manager == null)
            {
                manager = new Manager { SecondName = name, FirstName = name };
                ReposManager.Insert(manager);
            }
            return manager;
        }

        public Client GetClient(string name)
        {
            var client =ReposClient.GetAll().FirstOrDefault(x => x.SecondName == name);
            if (client == null)
            {
                client = new Client();
                client.SecondName = name;
                client.FirstName = name;
                ReposClient.Insert(client);
            }
            return client;
        }

        public NameFile GetNameFile(string name)
        {
            var nameFile = ReposNameFile.GetAll().FirstOrDefault(x => x.Name == name);
            if (nameFile == null)
            {
                nameFile = new NameFile() { Name = name };
                ReposNameFile.Insert(nameFile);
            }
            return nameFile;
        }

        public Goods GetGoods(string name)
        {
            var goods = ReposGoods.GetAll().FirstOrDefault(x => x.NameGoods == name);
            if (goods == null)
            {
                goods = new Goods { NameGoods = name };
                ReposGoods.Insert(goods);
            }
            return goods;
        }
        #endregion
        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
