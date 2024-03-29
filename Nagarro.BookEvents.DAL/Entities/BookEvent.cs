using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEvents.DAL
{
    public class BookEvent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Location { get; set; }
        public int Time { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string OtherDetails { get; set; }

        public virtual ICollection<InvitedUser> InvitedUsers { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        
    }
}
