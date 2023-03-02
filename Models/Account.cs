namespace InteractiveAssesment_API.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string Balance { get; set; }
        public string StatusId { get; set; }
        public string StatementType { get; set; }
    }
}