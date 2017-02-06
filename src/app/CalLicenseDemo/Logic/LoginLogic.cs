using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using CalLicenseDemo.Common;
using CalLicenseDemo.DatabaseContext;
using CalLicenseDemo.Model;
using CalLicenseDemo.ViewModel;
using Newtonsoft.Json;

namespace CalLicenseDemo.Logic
{
    public class LoginLogic : IDisposable
    {
        private readonly LicenseAppDBContext _dbContext;

        public string ErrorMessage { get; set; }

        public LoginLogic()
        {
            _dbContext = new LicenseAppDBContext();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        //Validate Email address return true if email does not exist and false if email Exist
        public bool ValidateEmail(string email)
        {
            if (_dbContext.User.ToList().Count == 0)
                return true;
            return !(_dbContext.User.Any(u => u.Email.ToLower() == email.ToLower()));
        }

        public bool AuthenticateUser(string userName, string password)
        {
            var encryptedPassword = password;
            var status = _dbContext.User.ToList().Any(u => u.Email.ToLower() == userName.ToLower());
            User user = null;
            if (status)
            {
                user =
                    _dbContext.User.ToList()
                        .FirstOrDefault(u => u.Email.ToLower() == userName.ToLower());

                if (user != null)
                {
                    string hashPasword = CreatePasswordhash(password, user.ThumbPrint);
                    if (hashPasword == user.PasswordHash)
                        SingletonLicense.Instance.User = user;
                    else
                        ErrorMessage = "Invalid Password";
                }
                else
                    ErrorMessage = "Specified Credentials are invalid";
            }
            else
            {
                ErrorMessage = "Specified Email is not registered";
            }
            return user != null;
        }

        /// <summary>
        ///     Verifying the user license is still active and listing feature based on the
        /// </summary>

        public void GetFeatureList()
        {
            var folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "CalibrationLicense");
            UserLicenseJsonData licenseDetails;
            //Checking the directory in app data. the License file will be saved in the appdata folder
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            //checking the license file for adding the new license records to the file.
            if (File.Exists(Path.Combine(folderPath, "LicenseData.txt")))
            {
                var deserializeData = File.ReadAllBytes(Path.Combine(folderPath, "LicenseData.txt"));
                var data = Encoding.ASCII.GetString(deserializeData);
                licenseDetails = JsonConvert.DeserializeObject<UserLicenseJsonData>(data);
                var validLienseList = licenseDetails;
                foreach (var ld in licenseDetails.LicenseList)
                    if (ld.ExpireDate.Date > DateTime.Today.Date)
                        SingletonLicense.Instance.FeatureList.AddRange(ld.Type.FeatureList.ToList());
                    else
                        //Code is used to remove the Subscription which is expired
                        validLienseList.LicenseList.Remove(ld);
            }
        }

        public bool CreateUserInfo(RegistrationModel registrationModel)
        {
            try
            {
                if (_dbContext.User.ToList().Any(u => u.Email == registrationModel.Email))
                {
                    ErrorMessage = "Email id is lready registered";
                    return false;
                }
                User user = new User();
                user.FName = registrationModel.FName;
                user.LName = registrationModel.LName;
                user.Email = registrationModel.Email;

                Team _team =
                    _dbContext.Team.ToList()
                        .FirstOrDefault(
                            t => t.Name.ToLower() == registrationModel.OrganizationName.ToLower());
                if (_team != null)
                    user.Organization = _team;
                else
                {
                    _team = new Team() { Name = registrationModel.OrganizationName };
                    _team = _dbContext.Team.Add(_team);
                    user.Organization = _team;
                }
                string thumbPrint = string.Empty;
                user.PasswordHash = HashPassword(registrationModel.Password, out thumbPrint);
                user.ThumbPrint = thumbPrint;
                user = _dbContext.User.Add(user);
                _dbContext.SaveChanges();
                SingletonLicense.Instance.User = user;
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public string HashPassword(string password, out string thumbprint)
        {
            int size = 10;
            thumbprint = CreateSalt(size);
            return CreatePasswordhash(password, thumbprint);
        }

        public string CreateSalt(int size)
        {
            byte[] bytedata = new byte[size];
            var rngProvider = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rngProvider.GetBytes(bytedata);
            return Convert.ToBase64String(bytedata);
        }

        public string CreatePasswordhash(string password, string thumbPrint)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(password + thumbPrint);
            System.Security.Cryptography.SHA256Managed sha256 = new SHA256Managed();
            var byteHashData = sha256.ComputeHash(bytes);
            return ByteArrayToHexString(byteHashData);
        }

        public String ByteArrayToHexString(byte[] bytes)
        {
            int length = bytes.Length;

            char[] chars = new char[length << 1];

            for (int i = 0, j = 0; i < length; i++, j++)
            {
                byte b = (byte)(bytes[i] >> 4);
                chars[j] = (char)(b > 9 ? b + 0x37 : b + 0x30);

                j++;

                b = (byte)(bytes[i] & 0x0F);
                chars[j] = (char)(b > 9 ? b + 0x37 : b + 0x30);
            }

            return new String(chars);
        }
    }
}