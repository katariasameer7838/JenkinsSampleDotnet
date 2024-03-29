using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Nagarro.BookEvents.Main.Models
{
    public class CreateEventModel
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        [DisplayName("Start Time")]
        public int StartTime { get; set; }
        public string Type { get; set; }
        public int? Duration { get; set; }
        public string Description { get; set; }
        [DisplayName("Other Details")]
        public string OtherDetails { get; set; }
        [DisplayName("Invite By Email")]
        public string InviteByEmail { get; set; }
    }
}