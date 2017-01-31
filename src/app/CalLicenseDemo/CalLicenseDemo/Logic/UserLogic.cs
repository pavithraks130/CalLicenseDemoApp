using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalLicenseDemo.DatabaseContext;
using CalLicenseDemo.Model;

namespace CalLicenseDemo.Logic
{
    public class UserLogic
    {
        private readonly LicenseAppDBContext  _dbContext = null;

        public UserLogic()
        {
            _dbContext = new LicenseAppDBContext();
        }
        public UserModel ValidateUser(string userName, string password)
        {
            string encryptedPassword = password;
            UserModel user = _dbContext.User.ToList().FirstOrDefault(u => u.Email == userName && u.Password == encryptedPassword);
            return user;
        }


    }
}
