using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models.Model;

namespace WebApi.Models.Repositories
{
    public class UserRepository
    {
        private readonly DB _db;
        public UserRepository(DB context)
        {
            _db = context;
        }

        private bool DoesPasswordMatch(string hashedPwdFromDatabase, string userEnteredPassword)
        {
            return BCrypt.CheckPassword(userEnteredPassword + "^Y8~JJ", hashedPwdFromDatabase);
        }

        public User Login(string username,string password)
        {
            try
            {
                var user = _db.Users.Where(x => x.Username == username).SingleOrDefault();
                if (user != null && BCrypt.CheckPassword(password + "^Y8~JJ", user.Password))
                {
                    return user;
                }

                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public string Register(RegisterModel model)
        {
            try
            {
                var user = _db.Users.Where(x => x.Username == model.Username).SingleOrDefault();
                if (user != null )
                {
                    return "DUPLICATE";
                }
                User newuser = new User();
                newuser.Name = model.Name;
                newuser.Surname = model.Surname;
                newuser.Password = BCrypt.HashPassword(model.Password + "^Y8~JJ", BCrypt.GenerateSalt());
                newuser.Username = model.Username;
                _db.Users.Add(newuser);
                _db.SaveChanges();
                return "SUCCESS";
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
