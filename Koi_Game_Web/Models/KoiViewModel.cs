namespace Koi_Game_Web.Models
{
    public class KoiViewModel
    {
        public int? playerKoiId { get; set; }
        public int koiId { get; set; }
        public string name { get; set; } = "Không có tên"; // Giá trị mặc định
        public string color { get; set; } = "Không có màu sắc"; // Giá trị mặc định
        public decimal? price { get; set; } = 0; // Giá trị mặc định
        public string rare { get; set; } = "Không có độ hiếm"; // Giá trị mặc định
        public string ImageURL { get; set; } = "https://default-image.com/default.jpg"; // Giá trị mặc định
    }

}