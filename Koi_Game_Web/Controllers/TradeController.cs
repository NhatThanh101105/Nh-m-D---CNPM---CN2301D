
using Koi_Game_Services.Interfaces;
using Koi_Game_Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Koi_Game_Web.Controllers
{
    public class TradeController : Controller
    {
        private readonly ITradeService _tradeService;
        private readonly IHienThiCaService _hienThiCaService;
        public TradeController(ITradeService tradeService, IHienThiCaService hienThiCaService)
        {
            _tradeService = tradeService;
            _hienThiCaService = hienThiCaService;
        }
        public IActionResult Trade()
        {
            var idplayer = HttpContext.Session.GetInt32("playerId");
            var playerPondId = HttpContext.Session.GetInt32("playerPondId");
            if (!idplayer.HasValue)
            {
                return RedirectToAction("Login", "Account");
            }

            var koiInPond = _hienThiCaService.GetKoiInPond(idplayer.Value, playerPondId.Value);//koi trong hôf

            var allKoi = _hienThiCaService.getAllKoiPlayer(idplayer.Value);// koi của người chơi

            var koiOnSale = _tradeService.getKoiOnSale(idplayer.Value);// koi đang trên ttcn

            var TradeList = _tradeService.getAllTrade(idplayer.Value);// danh sách cá koi đang bán

            //var koiNotInPond = allKoi.Where(k => !koiInPond.Any(kinPond => kinPond.PlayerKoiId == k.PlayerKoiId)).ToList();

            // lay cas o
            var koiNotInPondAndOnSale = allKoi
                .Where(k => !koiInPond.Any(kinPond => kinPond.PlayerKoiId == k.PlayerKoiId) && !koiOnSale.Any(kSale => kSale.PlayerKoiId == k.PlayerKoiId) && !k.IsOnTrade)
                .ToList();
            Console.WriteLine($"Số lượng Koi đang bán: {koiOnSale?.Count()}");
            Console.WriteLine($"Số lượng giao dịch: {TradeList?.Count()}");
            if (koiOnSale != null && TradeList != null)
            {
                var koiOnSaleViewModel = koiOnSale.Select(trade => new koiOnSaleViewModel
                {
                    tradeId = trade.TradeId,
                    koi = new KoiViewModel
                    {
                        playerKoiId = trade.PlayerKoi?.PlayerKoiId ?? 0, // Kiểm tra null và gán giá trị mặc định
                        koiId = trade.PlayerKoi.Koi?.KoiId ?? 0, // Kiểm tra null và gán giá trị mặc định
                        color = trade.PlayerKoi.Koi?.Color ?? "Unknown", // Nếu Koi là null, sử dụng "Unknown"
                        name = trade.PlayerKoi.Koi?.KoiName ?? "Unknown", // Nếu KoiName là null, sử dụng "Unknown"
                        ImageURL = trade.PlayerKoi.Koi?.ImageURL ?? "", // Nếu ImageURL là null, sử dụng ""
                        price = trade.PlayerKoi.Koi?.Price ?? 0, // Nếu Price là null, sử dụng 0
                        rare = trade.PlayerKoi.Koi?.Rare ?? "Unknown" // Nếu Rare là null, sử dụng "Unknown"
                    }
                }).ToList();

                var koiNotInPondAndOnSaleViewModel = koiNotInPondAndOnSale.Select(k => new KoiViewModel
                {
                    playerKoiId = k.PlayerKoiId,
                    koiId = k.Koi.KoiId,
                    color = k.Koi.Color,
                    name = k.Koi.KoiName,
                    ImageURL = k.Koi.ImageURL,
                    price = k.Koi.Price,
                    rare = k.Koi.Rare
                }).ToList();

                var tradeListViewModel = TradeList
                    .Select(trade => new TradeItemViewModel
                    {
                        tradeId = trade.TradeId,
                        sellerId = trade.SellerId ?? 0,
                        sellerName = trade.Seller?.Name ?? "Chưa có tên người bán",  // Kiểm tra null cho Seller
                        price = trade.Price ?? 0,  // Kiểm tra null cho Price
                        koi = new KoiViewModel
                        {
                            playerKoiId = trade.PlayerKoi?.PlayerKoiId ?? 0,  // Kiểm tra null cho PlayerKoi và gán giá trị mặc định
                            koiId = trade.PlayerKoi?.Koi?.KoiId??0,  // Nếu Koi là null, không gán giá trị
                            color = trade.PlayerKoi?.Koi?.Color ?? "Unknown",  // Nếu KoiColor là null, sử dụng "Unknown"
                            name = trade.PlayerKoi?.Koi?.KoiName ?? "Unknown",  // Nếu KoiName là null, sử dụng "Unknown"
                            ImageURL = trade.PlayerKoi?.Koi?.ImageURL ?? "default-image-url",  // Nếu ImageURL là null, sử dụng giá trị mặc định
                            price = trade.PlayerKoi?.Koi?.Price ?? 0,  // Nếu KoiPrice là null, sử dụng giá trị mặc định
                            rare = trade.PlayerKoi?.Koi?.Rare ?? "Unknown"  // Nếu KoiRare là null, sử dụng "Unknown"
                        }
                    }).ToList();




                var model = new TradeViewModel
                {
                    koiOnSale = koiOnSaleViewModel ?? new List<koiOnSaleViewModel>(), // Danh sách rỗng nếu không có dữ liệu
                    koiNotOnSale = koiNotInPondAndOnSaleViewModel ?? new List<KoiViewModel>(), // Danh sách rỗng nếu không có dữ liệu
                    TradeItems = tradeListViewModel ?? new List<TradeItemViewModel>() // Danh sách rỗng nếu không có dữ liệu
                };
                return View("~/Views/Game/TradeView.cshtml", model);
            }

            return View("~/Views/Game/TradeView.cshtml");
        }
        [HttpPost]
        public IActionResult Sell(int playerKoiId, decimal price)
        {
            var idplayer = HttpContext.Session.GetInt32("playerId");
            if (!idplayer.HasValue)
            {
                return RedirectToAction("Login", "Account");
            }
            Console.WriteLine($"idplayer: {idplayer.Value}, playerKoiId: {playerKoiId}, price: {price}");
            bool newtrade = _tradeService.newTrade(idplayer.Value, playerKoiId, price);
            if (newtrade)
            {
                TempData["success"] = "đăng bán thành công";
            }
            else
            {
                TempData["fail"] = "đăng bán thất bại";
            }

            return RedirectToAction("Trade", "Trade");
        }

        [HttpPost]
        public IActionResult Cancel(int tradeId)
        {
            var idplayer = HttpContext.Session.GetInt32("playerId");
            if (!idplayer.HasValue)
            {
                return RedirectToAction("Login", "Account");
            }
            bool cancel = _tradeService.cancelTrade(tradeId);
            if (cancel)
            {
                TempData["success"] = "hủy thành công";
            }
            else
            {
                TempData["fail"] = "hủy thất bại, hoặc đã được mua";
            }
            return RedirectToAction("Trade", "Trade");
        }
        [HttpPost]
        public async Task<IActionResult> Buy(int tradeId,int koiId)
        {
            var idplayer = HttpContext.Session.GetInt32("playerId");
            if (!idplayer.HasValue)
            {
                return RedirectToAction("Login", "Account");
            }
            bool buy = await _tradeService.trade(idplayer.Value, tradeId,koiId);

            if (buy)
            {
                TempData["success"] = "mua thành công";
            }
            else
            {
                TempData["fail"] = "mua thất bại, kiểm tra số dư, hoặc đã có người khác mua";
            }
            return RedirectToAction("Trade", "Trade");
        }
    }
}
