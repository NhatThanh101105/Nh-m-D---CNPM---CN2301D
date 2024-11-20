namespace Koi_Game_Web.Models
{
    // tao player viewmodel de luu cac du lieeu owr session maf khoong dungf toiws viewbag
    public class PlayerViewModel
    {
        public int id { get; set; }
        public string username { get; set; }
        public decimal? coin { get; set; }
        public string name { get; set; }
        public int countKoi { get; set; }
    }
}
