using System;
using System.IO;
using System.Linq;
using System.Text;
using CalLicenseDemo.Common;
using CalLicenseDemo.DatabaseContext;
using CalLicenseDemo.Model;
using Newtonsoft.Json;

namespace CalLicenseDemo.Logic
{
    public class LoginLogic : IDisposable
    {
        private readonly LicenseAppDBContext _dbContext;

        public LoginLogic()
        {
            _dbContext = new LicenseAppDBContext();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public bool ValidateUser(string userName, string password)
        {
            var encryptedPassword = password;
            var user =
                _dbContext.User.ToList().FirstOrDefault(u => u.Email == userName && u.Password == encryptedPassword);
            if (user != null) SingletonLicense.Instance.User = user;
            return user != null;
        }

        /// <summary>
        ///     Verifying the user license is still active and listing feature based on the
        /// </summary>
        public void GetFeatureList()
        {
            var folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "CalibrationLicense");
            UserLicenseJsonData licenseDetails;
            //Checking the directory in app data. the License file will be saved in the appdata folder
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            //checking the license file for adding the new license records to the file.
            if (File.Exists(Path.Combine(folderPath, "LicenseData.json")))
            {
                var deserializeData = File.ReadAllBytes(Path.Combine(folderPath, "LicenseData.json"));
                var data = Encoding.ASCII.GetString(deserializeData);
                licenseDetails = JsonConvert.DeserializeObject<UserLicenseJsonData>(data);
                foreach (var ld in licenseDetails.LicenseList)
                    if (ld.ExpireDate.Date > DateTime.Today.Date)
                        SingletonLicense.Instance.FeatureList.AddRange(ld.Type.FeatureList.ToList());
            }
        }

        public bool ValidateOldPassword(string password)
        {
            return false;
        }

        public bool UpdatePassword(string oldPassword, string newPassword)
        {
            return true;
        }

        public string CreateSalt(int size)
        {
            byte[] bytedata = new byte[size];

            return string.Empty;
        }

        public string CreatePasswordhash()
        {
            return string.Empty;
        }
    }
}