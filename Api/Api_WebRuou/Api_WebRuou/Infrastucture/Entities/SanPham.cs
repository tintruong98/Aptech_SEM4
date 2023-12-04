namespace Api_WebRuou.Infrastucture.Entities
{
    public class SanPham
    {
        public int Id { get; set; } 

        public string Name { get; set; }

        public string? Description { get; set; }

        public string UrlImage { get; set; }

        public int Promotion { get; set; }
    }
}
