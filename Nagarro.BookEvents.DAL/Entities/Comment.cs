using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEvents.DAL
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentID { get; set; }
        public string Content { get; set; }
        
        [Required]
        public int EventId { get; set; }
        public int UserId { get; set; }

        public BookEvent BookEvent { get; set; }
        public virtual User User { get; set; }
    }
}
