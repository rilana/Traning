using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillFolderInDatabase
{
    class Parser
    {
        private string _secondNameManager;
        //???????
        //private DateTime _date;
        private string _path;
        public Parser(string path)
        {
            _path = path;
            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
            if (fileNameWithoutExtension != null)
            {
                var values =fileNameWithoutExtension.Split('_');
                _secondNameManager = values[0];
                //??????????
                //_date = Convert.ToDateTime(values[1]);
            }
        }

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
                                    Manager = _secondNameManager
                                });
                        }
                    }
                }
                return orders;
            }
        }
    }
}
