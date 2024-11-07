namespace Koi_Game_Web.Models
{
    public class PondDetailViewModel
    {
        public int playerPondId { get; set; }
        public int pondId { get; set; }
        public List<KoiViewModel > koilist { get; set; }
        public List<KoiViewModel> koiNotInPond { get; set; }
        public string PondImageUrl
        {
            get
            {
                return pondId switch
                {
                    1 => "/images/pond/pond1.jpg",
                    2 => "/images/pond/pond5.jpg",
                    3 => "/images/pond/pond7.jpg",
                    _ => "/images/default_pond.jpg" // Default image for other pond IDs
                };
            }
        }
    }
}
