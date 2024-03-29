using Nagarro.BookEvents.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.BookEvents.DAL;

namespace Nagarro.BookEvents.BLL
{
    public class AccountBLL
    {
        public RegisterDTO Register(RegisterDTO registerDTO)
        {
            var accountDal = new AccountDAL();
            bool isExists = accountDal.IsAccountAlreadyExists(registerDTO.Email);
            if(isExists.Equals(true))
            {
                registerDTO.IsAccountAlreadyExists = true;
                return registerDTO;
            }
            else
            {
                RegisterDTO addUser = accountDal.RegisterNewUser(registerDTO);
                if(addUser.IsDetailsSaved == true)
                {
                    registerDTO.IsAccountAlreadyExists = false;
                    registerDTO.IsDetailsSaved = true;
                    registerDTO.UserID = addUser.UserID;
                }
                else
                {
                    registerDTO.IsAccountAlreadyExists = false;
                    registerDTO.IsDetailsSaved = false;
                }
                return registerDTO;
            }  
        }

        public LoginDTO Login(LoginDTO loginDTO)
        {
            var accountDAL = new AccountDAL();
            bool isExists = accountDAL.IsAccountAlreadyExists(loginDTO.Email);
            if(isExists.Equals(true))
            {
                loginDTO.IsAccountAvailable = true;
                var resultLoginDTO = accountDAL.IsPasswordMatches(loginDTO);
                if(resultLoginDTO.IsPasswordMatches == true)
                {
                    loginDTO.IsPasswordMatches = true;
                    loginDTO.UserID = resultLoginDTO.UserID;
                    return loginDTO;
                }
                else
                {
                    loginDTO.IsPasswordMatches = false;
                    return loginDTO;
                }

            }
            else
            {
                loginDTO.IsAccountAvailable = false;
                return loginDTO;
            }
        }
    }
}
