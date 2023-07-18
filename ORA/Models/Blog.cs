using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORA.Models
{
    [Table("Bag")]
    public class Blog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Key]
        public int id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string userMail { get; set; }
    }
}
