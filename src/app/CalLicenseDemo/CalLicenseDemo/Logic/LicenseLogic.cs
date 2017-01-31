using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using CalLicenseDemo.DatabaseContext;
using CalLicenseDemo.Model;

namespace CalLicenseDemo.Logic
{
    class LicenseLogic
    {
        public UserModel User { get; set; }

        public string ErrorMessage { get; set; }

        private readonly LicenseAppDBContext _dbContext;

        public LicenseLogic()
        {
            _dbContext = new LicenseAppDBContext();
        }

        public void GenerateLicense()
        {
            bool status;
            status = CreateUserInfo();
            if (status)
                status = UpdateSubScriptionDetails();


        }

        public bool UpdateSubScriptionDetails()
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
            ManagementObjectCollection proDetails = mos.Get();
            try
            {


            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool CreateUserInfo()
        {
            try
            {
                if (_dbContext.User.ToList().Any(u => u.Email == User.Email && u.Password == User.Password))
                {
                    ErrorMessage = "Email id is lready registered";
                    return false;
                }
                Team _team =
                    _dbContext.Team.ToList()
                        .FirstOrDefault(
                            t => t.Name == User.Organization.Name && t.GroupEmail == User.Organization.GroupEmail);
                if (_team != null)
                {
                    User.Organization = _team;
                    User.TeamID = _team.TeamId;
                }
                else
                {
                    _team = _dbContext.Team.Add(User.Organization);
                    User.TeamID = _team.TeamId;
                    User = _dbContext.User.Add(User);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public List<LicenseType> GetSubscriptionDetails()
        {
            return _dbContext.LicenseType.ToList();
        }

        public bool ValidateLicense()
        {

            return true;
        }


    }
}
