using Nagarro.BookEvents.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.BookEvents.DAL;

namespace Nagarro.BookEvents.BLL
{
    public class BookEventsBLL
    {
        public List<BookEventDTO> GetBookEvents()
        {
            var bookEventsRepository = new BookEventsRepository();
            List<BookEventDTO> list = bookEventsRepository.GetBookEvents();
            return list;
        } 
        
        public BookEventDTO GetBookEventDetail(int id)
        {
            var bookEventsRepository = new BookEventsRepository();
            return bookEventsRepository.GetEventDetails(id);
        }

        public CreateEventDTO CreateEvent(CreateEventDTO createEventDTO)
        {
            BookEventsRepository bookEventsRepository = new BookEventsRepository();
            return bookEventsRepository.CreateEvent(createEventDTO);
        }

        public List<BookEventDTO> GetMyEventsList(BookEventDTO bookEventDTO)
        {
            BookEventsRepository bookEventsRepository = new BookEventsRepository();
            return bookEventsRepository.GetMyEvents(bookEventDTO);
        }
        public List<BookEventDTO> GetEventsInvitedList(BookEventDTO bookEventDTO)
        {
            BookEventsRepository bookEventsRepository = new BookEventsRepository();
            return bookEventsRepository.GetEventsInvited(bookEventDTO);
        }
    }
}
