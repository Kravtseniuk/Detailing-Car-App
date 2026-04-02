namespace BaseLibrary.DTOs
{
    public class CompanyServiceDto
    {
        public int Id { get; set; }
        public string CompanyServiceName { get; set; } = string.Empty;
        public decimal DefaultPrice { get; set; }
    }
}
