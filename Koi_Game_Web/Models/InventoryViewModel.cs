namespace Koi_Game_Web.Models
{
    public class InventoryViewModel
    {
        public int? itemId { get; set; }
        public string? nameType { get; set; }
        public int? quantity { get; set; }
        public string PondImageUrl
        {
            get
            {
                return itemId switch
                {
                    1 => "/images/pond/pond1.jpg",
                    2 => "/images/pond/pond5.jpg",
                    3 => "/images/pond/pond7.jpg",
                    _ => "/images/default_pond.jpg"
                };
            }
        }
        public List<KoiViewModel> KoiList { get; set; } = new List<KoiViewModel>();
    }
}
