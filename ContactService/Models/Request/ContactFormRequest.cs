namespace ContactService.Models.Request
{
    public class ContactFormRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MailAddress { get; set; }
        public string Message { get; set; }
    }
}
