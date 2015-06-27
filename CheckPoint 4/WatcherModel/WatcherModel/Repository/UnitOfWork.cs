using System.Data.Entity;

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

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
