namespace Koi_Game_Web.Models
{
    public class GameViewModel
    {
       public  PlayerViewModel player { get; set; }
      public  PondDetailViewModel PondDetail { get; set; }

        public List<KoiViewModel> Koi { get; set; } = new List<KoiViewModel>();
    }
}
