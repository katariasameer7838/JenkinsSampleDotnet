using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEvents.DAL
{
    public class InvitedUser
    {
        [Key]
        public int InvitationId { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
    }
}
