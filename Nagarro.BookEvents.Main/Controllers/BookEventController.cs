using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nagarro.BookEvents.BLL;
using Nagarro.BookEvents.Main.Filter;
using Nagarro.BookEvents.Main.Models;
using Nagarro.BookEvents.Shared;

namespace Nagarro.BookEvents.Main.Controllers
{
    public class BookEventController : Controller
    {
        // GET: BookEvent
        public ActionResult EventDetail(int id)
        {
            var bookEventBLL = new BookEventsBLL();
            var model = bookEventBLL.GetBookEventDetail(id);
            var mainModel = new EventModel();
            if(model != null)
            {
                mainModel.EventId = model.EventId;
                mainModel.Title = model.Title;
                mainModel.Date = model.Date;
                mainModel.Location = model.Location;
                mainModel.Time = model.Time;
                mainModel.Description = model.Description;
                mainModel.OtherDetails = model.OtherDetails;
                int invitedUserCount = 0;
                foreach(var user in model.UsersInvited)
                {
                    invitedUserCount++;
                }
                mainModel.TotalInvited = invitedUserCount;
                mainModel.Comments = model.Comments;
            }
            return View(mainModel);
        }

        [HttpGet]
        [LoginFilter]
        public ActionResult CreateEvent()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateEventModel eventModel)
        {
            if(ModelState.IsValid)
            {
                var bookEventDTO = new CreateEventDTO();
                bookEventDTO.Title = eventModel.Title;
                bookEventDTO.Date = eventModel.Date;
                bookEventDTO.Location = eventModel.Location;
                bookEventDTO.StartTime = eventModel.StartTime;
                bookEventDTO.Type = eventModel.Type;
                bookEventDTO.Description = eventModel.Description;
                bookEventDTO.OtherDetails = eventModel.OtherDetails;               
                bookEventDTO.Duration = eventModel.Duration;
                bookEventDTO.InviteByEmail = eventModel.InviteByEmail;
                HttpCookie cookie = Request.Cookies["UserInfo"];
                bookEventDTO.UserId = int.Parse(cookie["id"]);
                BookEventsBLL bookEventsBLL = new BookEventsBLL();
                var resultEventDTO = bookEventsBLL.CreateEvent(bookEventDTO);
                if(resultEventDTO != null)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        [LoginFilter]
        public ActionResult MyEvents()
        {
            BookEventDTO bookEventDTO = new BookEventDTO();
            HttpCookie cookie = Request.Cookies["UserInfo"];
            bookEventDTO.UserId = 1/*int.Parse(cookie["id"])*/;
            BookEventsBLL bookEventsBLL = new BookEventsBLL();
            var resultDTOList = bookEventsBLL.GetMyEventsList(bookEventDTO);
            List<EventListModel> modelList = new List<EventListModel>();
            foreach (var listItem in resultDTOList)
            {
                EventListModel modelSample = new EventListModel();
                modelSample.EventId = listItem.EventId;
                modelSample.Title = listItem.Title;
                modelSample.Date = listItem.Date;
                modelList.Add(modelSample);
            }
            return View(modelList);
        }

        [LoginFilter]
        public ActionResult EventsInvited()
        {
            BookEventDTO bookEventDTO = new BookEventDTO();
            HttpCookie cookie = Request.Cookies["UserInfo"];
            bookEventDTO.UserId = 1/*int.Parse(cookie["id"])*/;
            BookEventsBLL bookEventsBLL = new BookEventsBLL();
            var resultDTOList = bookEventsBLL.GetEventsInvitedList(bookEventDTO);
            List<EventListModel> modelList = new List<EventListModel>();
            foreach (var listItem in resultDTOList)
            {
                EventListModel modelSample = new EventListModel();
                modelSample.EventId = listItem.EventId;
                modelSample.Title = listItem.Title;
                modelSample.Date = listItem.Date;
                modelList.Add(modelSample);
            }
            return View(modelList);
        }
    }
}