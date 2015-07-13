
namespace WebSales.Models
{
    public class FilterModels:FilterDateModels
    {
        public int? FilterManager { get; set; }
        public int? FilterClient { get; set; }
        public int? FilterGoods { get; set; }
        public int? FilterNameFile { get; set; }
    }
}