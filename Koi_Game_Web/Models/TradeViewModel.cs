
namespace Koi_Game_Web.Models
{
    public class koiOnSaleViewModel
    {
        public int tradeId { get; set; }
        public KoiViewModel koi { get; set; }=new KoiViewModel();
    }
    public class TradeViewModel 
    {
        public List<TradeItemViewModel> TradeItems { get; set; }=new List<TradeItemViewModel>();
        public List<koiOnSaleViewModel > koiOnSale { get; set; }=new List<koiOnSaleViewModel>();
        public List<KoiViewModel> koiNotOnSale { get; set;}=new List<KoiViewModel>();

    }
}
