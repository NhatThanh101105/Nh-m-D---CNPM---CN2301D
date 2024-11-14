using Koi_Game_Web.Models;

public class TradeItemViewModel
{
    public int tradeId { get; set; }
    public int? sellerId { get; set; }
    public string sellerName { get; set; } = "Chưa có tên người bán"; // Giá trị mặc định
    public KoiViewModel koi { get; set; } = new KoiViewModel(); // Giá trị mặc định là một KoiViewModel mới
    public decimal? price { get; set; } = 0; // Giá trị mặc định
}
