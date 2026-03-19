namespace BaseLibrary.DTOs
{
    public class CompanyServiceDto
    {
        public int Id { get; set; }
        public string CompanyServiceTitle { get; set; } = string.Empty;
        public decimal DefaultPrice { get; set; }
    }
}
