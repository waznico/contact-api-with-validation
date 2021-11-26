using System.ComponentModel.DataAnnotations;

namespace ContactService.Models.Database
{
    public class ContactForm
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(255)]
        public string MailAddress { get; set; }
        [MaxLength(500)]
        public string Message { get; set; }
    }
}
