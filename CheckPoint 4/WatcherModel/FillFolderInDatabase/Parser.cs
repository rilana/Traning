using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FillFolderInDatabase
{
    class Parser
    {
        private string _secondNameManager;
        private string _nameFile;
        private string _path;
        public Parser(string path)
        {
            _path = path;
            _nameFile= Path.GetFileNameWithoutExtension(path);
            if (_nameFile != null)
            {
                var values =_nameFile.Split('_');
                _secondNameManager = values[0];
                
            }
        }

        public static readonly object Locker = new object();
        public List<OrderFromFile> Orders
        {
            get
            {
                var orders = new List<OrderFromFile>();
                using (var sr = new StreamReader(_path,Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var val = line.Split(',');
                        if (val.Count() == 4)
                        {
                            orders.Add(
                                new OrderFromFile()
                                {
                                    Date = Convert.ToDateTime(val[0]),
                                    Client = val[1],
                                    Good = val[2],
                                    Cost = Convert.ToInt32(val[3]),
                                    Manager = _secondNameManager,
                                    NameFile=_nameFile,
                                });
                        }
                    }
                }
                return orders;
            }
        }
        public void FillOrderToBase()
        {
            using (var sr = new StreamReader(_path, Encoding.Default))
            {
                string line;
                IOperationToDatabase fillToBase=new OperationToDatabase();
                while ((line = sr.ReadLine()) != null)
                {
                    var val = line.Split(',');
                    if (val.Count() == 4)
                    {
                          var orderFile=new OrderFromFile()
                            {
                                Date = Convert.ToDateTime(val[0]),
                                Client = val[1],
                                Good = val[2],
                                Cost = Convert.ToInt32(val[3]),
                                Manager = _secondNameManager,
                                NameFile = _nameFile,
                            };
                        lock (Locker)
                        {
                            fillToBase.AddOrder(orderFile);        
                        }
                    }
                }
            }
        }
    }
}
