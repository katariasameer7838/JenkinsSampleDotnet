﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nagarro.BookEvents.Main.Models
{
    public class EventListModel
    {
        public int EventId { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
    }
}