using System;
namespace FillFolderInDatabase
{
    class Order
    {
        public string Manager { get; set; }
        public string Client { get; set; }
        public string Good { get; set; }
        public int Cost { get; set; }
        public DateTime Date { get; set; }
    }
}
