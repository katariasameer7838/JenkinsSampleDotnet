using Nagarro.BookEvents.Shared;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Nagarro.BookEvents.DAL
{
    public class BookEventsRepository
    {
        public List<BookEventDTO> GetBookEvents()
        {
            List<BookEventDTO> bookEvents = new List<BookEventDTO>();
            using (var dbContext = new EventContext())
            {
                //var bookEventEntities = (from bookEvent in dbContext.BookEvents
                //                         join comment in dbContext.Comments
                //                             on bookEvent.EventId equals comment.EventId
                //                         select new { bookevnt = bookEvent,
                //                         comments = comment});

                var bookeEventEntities = dbContext.BookEvents;

                foreach (var bookEvent in bookeEventEntities)
                {
                    var bookEventDto = new BookEventDTO();
                    bookEventDto.EventId = bookEvent.EventId;
                    bookEventDto.UserId = bookEvent.UserId;
                    bookEventDto.Title = bookEvent.Title;
                    bookEventDto.Date = bookEvent.Date;
                    bookEventDto.Location = bookEvent.Location;
                    bookEventDto.Time = bookEvent.Time;
                    bookEventDto.Type = bookEvent.Type;
                    bookEventDto.Description = bookEvent.Description;
                    bookEventDto.OtherDetails = bookEvent.OtherDetails;
                    //var comments = bookEvent.Comments;
                    //foreach(var comm in comments)
                    //{
                    //    bookEventDto.Comments.Add(comm.Content);
                    //}
                    bookEvents.Add(bookEventDto);
                }
            }

            return bookEvents;

        }

        public BookEventDTO GetEventDetails(int eventId)
        {
            var bookEventDto = new BookEventDTO();
            using (var dbContext = new EventContext())
            {
                var bookEventEntity = dbContext.BookEvents.Include(c => c.Comments).Include(u => u.InvitedUsers).SingleOrDefault(bookEvent => bookEvent.EventId == eventId);
                if (bookEventEntity != null)
                {
                    bookEventDto.EventId = bookEventEntity.EventId;
                    bookEventDto.UserId = bookEventEntity.UserId;
                    bookEventDto.Title = bookEventEntity.Title;
                    bookEventDto.Date = bookEventEntity.Date;
                    bookEventDto.Location = bookEventEntity.Location;
                    bookEventDto.Time = bookEventEntity.Time;
                    bookEventDto.Type = bookEventEntity.Type;
                    bookEventDto.Description = bookEventEntity.Description;
                    bookEventDto.OtherDetails = bookEventEntity.OtherDetails;
                    var comments = bookEventEntity.Comments;
                    var users = bookEventEntity.InvitedUsers;
                    List<int> userList = new List<int>();
                    List<string> commentList = new List<string>();
                    foreach (var comm in comments)
                    {
                        commentList.Add(comm.Content);
                    }
                    foreach (var user in users)
                    {
                        userList.Add(user.UserId);
                    }
                    bookEventDto.Comments = commentList;
                    bookEventDto.UsersInvited = userList;
                }
            }
            return bookEventDto;
        }

        public CreateEventDTO CreateEvent(CreateEventDTO createEventDto)
        {
            using (var dbContext = new EventContext())
            {
                //logic to save event
                var bookEventEntity = new BookEvent()
                {
                    OtherDetails = createEventDto.OtherDetails,
                    Title = createEventDto.Title,
                    Date = createEventDto.Date,
                    Location = createEventDto.Location,
                    Time = createEventDto.StartTime,
                    Type = createEventDto.Type,
                    Description = createEventDto.Description,
                    UserId = createEventDto.UserId
                };

                dbContext.BookEvents.Add(bookEventEntity);
                dbContext.SaveChanges();

                createEventDto.EventId = bookEventEntity.EventId;


                var invitedUserEmails = createEventDto.InviteByEmail.Split(',');

                var userIds = from user in dbContext.Users
                              where invitedUserEmails.Contains(user.Email)
                              select user.UserId;

                // save userIds in invitedUser
                foreach (var userId in userIds)
                {
                    var invitedUsers = new InvitedUser()
                    {
                        UserId = userId,
                        EventId = createEventDto.EventId
                    };

                    dbContext.InvitedUsers.Add(invitedUsers);
                }

                dbContext.SaveChanges();
            }
            return createEventDto;
        }

        public List<BookEventDTO> GetMyEvents(BookEventDTO bookEventDTO)
        {
            using (var dbContext = new EventContext())
            {
                var data = dbContext.BookEvents.Where(u => u.UserId.Equals(bookEventDTO.UserId));
                var eventList = new List<BookEventDTO>();
                foreach(var events in data)
                {
                    BookEventDTO bookEvent = new BookEventDTO();
                    bookEvent.Title = events.Title;
                    bookEvent.EventId = events.EventId;
                    bookEvent.Date = events.Date;
                    eventList.Add(bookEvent);
                }
                return eventList;
            }
        }
        public List<BookEventDTO> GetEventsInvited(BookEventDTO bookEventDTO)
        {
            using (var dbContext = new EventContext())
            {
                var eventIds = dbContext.InvitedUsers.Where(u => u.UserId.Equals(bookEventDTO.UserId));
                var eventList = new List<BookEventDTO>();
                foreach(var events in eventIds)
                {
                    var eventInfo = GetInvitedEventDetail(events.EventId);
                    BookEventDTO bookEvent = new BookEventDTO();
                    bookEvent.Title = eventInfo.Title;
                    bookEvent.EventId = eventInfo.EventId;
                    bookEvent.Date = eventInfo.Date;
                    eventList.Add(bookEvent);
                }
                return eventList;
            }
        }
        public BookEvent GetInvitedEventDetail(int eventID)
        {
            using (var dbContext = new EventContext())
            {
                var eventInfo = dbContext.BookEvents.SingleOrDefault(e => e.EventId == eventID);
                return eventInfo;
            }
            

        }

    }
}
