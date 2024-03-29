using Nagarro.BookEvents.BLL;
using Nagarro.BookEvents.Main.Models;
using Nagarro.BookEvents.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nagarro.BookEvents.Main.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
            var bookEventsBLL = new BookEventsBLL();
            var model = bookEventsBLL.GetBookEvents();
            List<EventListModel> modelList = new List<EventListModel>();
            foreach(var events in model)
            {
                var eventModel = new EventListModel();
                eventModel.EventId = events.EventId;
                eventModel.Title = events.Title;
                eventModel.Date = events.Date;
                modelList.Add(eventModel);
            }
            return View(modelList);
        }

        public ActionResult CostumerSupport()
        {
            return Redirect("http://helpdesk.nagarro.com");
        }

        public ActionResult Logout()
        {
            if (Request.Cookies["userInfo"] != null)
            {
                var c = new HttpCookie("userInfo");
                c.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(c);
            }
            return RedirectToAction("Index", "Home");
        }

        private List<EventModel> GetEventModels(List<BookEventDTO> bookEventDTOs)
        {
            List<EventModel> eventModels = new List<EventModel>();

            foreach(var bookEventDto in bookEventDTOs)
            {
                EventModel eventModel = new EventModel()
                {
                    Title = bookEventDto.Title
                };
            }

            return eventModels;
        }
        
    }
}