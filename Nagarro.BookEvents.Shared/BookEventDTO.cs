using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEvents.Shared
{
    public class BookEventDTO
    {
        public int EventId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public int Time { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string OtherDetails { get; set; }
        public List<string> Comments { get; set; }
        public List<int> UsersInvited { get; set; }
    }
}
