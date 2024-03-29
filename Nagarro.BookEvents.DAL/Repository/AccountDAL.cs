using Nagarro.BookEvents.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEvents.DAL
{
    public class AccountDAL
    {
        public bool IsAccountAlreadyExists(string email)
        {
            using (var dbContext = new EventContext())
            {
                var checkMail = dbContext.Users.Where(e => e.Email.Equals(email)).FirstOrDefault();
                if(checkMail == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            
        }

        public LoginDTO IsPasswordMatches(LoginDTO loginDTO)
        {
            using (var dbContext = new EventContext())
            {
                var checkPass = dbContext.Users.Where(e => e.Email.Equals(loginDTO.Email)).FirstOrDefault();
                if(checkPass.Password.Equals(loginDTO.Password))
                {
                    loginDTO.UserID = checkPass.UserId;
                    loginDTO.IsPasswordMatches = true;
                    return loginDTO;
                }
                else
                {
                    loginDTO.IsPasswordMatches = false;
                    return loginDTO;
                }
            }
        }

        public RegisterDTO RegisterNewUser(RegisterDTO registerDTO)
        {
            using (var dbContext = new EventContext())
            {
                var user = new User()
                {
                    FullName = registerDTO.FullName,
                    Email = registerDTO.Email,
                    Password = registerDTO.Password
                };
                try
                {
                    dbContext.Users.Add(user);
                    dbContext.SaveChanges();
                    registerDTO.IsDetailsSaved = true;
                    registerDTO.UserID = registerDTO.UserID;
                    return registerDTO;
                }
                catch(DataException)
                {
                    registerDTO.IsDetailsSaved = false;
                    return registerDTO;
                }

            }
        }
    }
}
