using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORA.Models
{
    [Table("Comment")]
    public class Comment
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int postId { get; set; }
        public string content { get; set; }
        public string userMail { get; set; }
        public DateTime dateCreated { get; set; }
    }
}
