using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Nagarro.BookEvents.DAL;

namespace Nagarro.BookEvents.DAL
{
    class EventInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<EventContext>
    {
        protected override void Seed(EventContext context)
        {
            var users = new List<User>
            {
                new User{Email="abc@gmail.com",Password="12345",FullName="abc"},
                new User{Email="qwe@gmail.com",Password="12345",FullName="qwe"},
                new User{Email="asd@gmail.com",Password="12345",FullName="asd"},
                new User{Email="zxc@gmail.com",Password="12345",FullName="zxc"},
                new User{Email="bnm@gmail.com",Password="12345",FullName="bnm"},
                new User{Email="jkl@gmail.com",Password="12345",FullName="jkl"},
                new User{Email="iop@gmail.com",Password="12345",FullName="iop"},
                new User{Email="cvb@gmail.com",Password="12345",FullName="cvb"},
                new User{Email="fgh@gmail.com",Password="12345",FullName="fgh"},
                new User{Email="myadmin@bookevents.com",Password="12345",FullName="Admin"},
                new User{Email="rty@gmail.com",Password="12345",FullName="rty"}
            };

            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();

            var events = new List<BookEvent>
            {
                new BookEvent{UserId=1,Title="Dan Brown 1",Date=DateTime.Parse("2019-02-17"),Location="Plot 13",Time=10,Type="Public",Description="Book Name is Da Vinci Code",OtherDetails="Half book Reading"},
                new BookEvent{UserId=1,Title="Dan Brown 2",Date=DateTime.Parse("2019-02-18"),Location="Plot 13",Time=10,Type="Public",Description="Book Name is Da Vinci Code",OtherDetails="Remain Half book Reading"},
                new BookEvent{UserId=4,Title="Blue Umbrella",Date=DateTime.Parse("2019-02-27"),Location="Plot 37",Time=10,Type="Private",Description="Book Name is Blue Umbrella",OtherDetails="Full book Reading"},
                new BookEvent{UserId=7,Title="Harry Potter 1",Date=DateTime.Parse("2019-02-23"),Location="Plot 371",Time=10,Type="Public",Description="Book Name is Curse Child",OtherDetails="Half book Reading"},
                new BookEvent{UserId=7,Title="Harry Potter 2",Date=DateTime.Parse("2019-02-24"),Location="Plot 371",Time=10,Type="Public",Description="Book Name is Da Vinci Code",OtherDetails="Remaining book Reading"}
            };

            events.ForEach(e => context.BookEvents.Add(e));
            context.SaveChanges();

            var comments = new List<Comment>
            {
                new Comment{Content="Great Session",EventId=1,UserId=1},
                new Comment{Content="Wonderful Session",EventId=5,UserId=5},
                new Comment{Content="Bornig",EventId=2,UserId=2},
                new Comment{Content="Mind Blowing",EventId=2,UserId=9},
                new Comment{Content="Loved It!",EventId=4,UserId=6},
                new Comment{Content="Waiting for next one",EventId=1,UserId=2},
                new Comment{Content="Average",EventId=3,UserId=7},
                new Comment{Content="Event was very refreshing",EventId=4,UserId=8}
            };

            comments.ForEach(c => context.Comments.Add(c));
            context.SaveChanges();

            var invitedUsers = new List<InvitedUser>
            {
                new InvitedUser{UserId=1,EventId=1},
                new InvitedUser{UserId=3,EventId=1},
                new InvitedUser{UserId=5,EventId=1},
                new InvitedUser{UserId=2,EventId=2},
                new InvitedUser{UserId=4,EventId=2},
                new InvitedUser{UserId=6,EventId=2},
                new InvitedUser{UserId=7,EventId=3},
                new InvitedUser{UserId=8,EventId=3},
                new InvitedUser{UserId=7,EventId=4},
                new InvitedUser{UserId=1,EventId=4},
                new InvitedUser{UserId=6,EventId=5},
            };

            invitedUsers.ForEach(i => context.InvitedUsers.Add(i));
            context.SaveChanges();
        }
    }
}
