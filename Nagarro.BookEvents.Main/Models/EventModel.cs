using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Nagarro.BookEvents.Main.Models
{
    public class EventModel
    {
        public int EventId { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public int? Time { get; set; }
        public string Description { get; set; }
        [DisplayName("Other Details")]
        public string OtherDetails { get; set; }
        [DisplayName("Total Invited")]
        public int TotalInvited { get; set; }

        public List<string> Comments { get; set; }
        
    }
}