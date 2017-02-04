using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using CalLicenseDemo.Common;
using CalLicenseDemo.DatabaseContext;
using CalLicenseDemo.Model;
using LicenseKey;
using Newtonsoft.Json;

namespace CalLicenseDemo.Logic
{
    internal class LicenseLogic : IDisposable
    {
        private readonly LicenseAppDBContext _dbContext;

        public LicenseLogic()
        {
            _dbContext = new LicenseAppDBContext();
        }

        public User User { get; set; }

        public string ErrorMessage { get; set; }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void ActivateSubscription()
        {
            //code for creating the licensekey and mapping with user and updating on the server.
            var liceseKey = GenerateLicense();

            UserLicenseJsonData licenseDetails;
            var licType = SingletonLicense.Instance.SelectedSubscription;//_dbContext.LicenseType.ToList().FirstOrDefault(l => l.TypeId.ToString() == subscriptionType);
            var folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "CalibrationLicense");

            //Checking the directory in app data. the License file will be saved in the appdata folder
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            //checking the license file for adding the new license records to the file.
            if (File.Exists(Path.Combine(folderPath, "LicenseData.json")))
            {
                var deserializeData = File.ReadAllBytes(Path.Combine(folderPath, "LicenseData.json"));
                var data = Encoding.ASCII.GetString(deserializeData);
                 licenseDetails = JsonConvert.DeserializeObject<UserLicenseJsonData>(data);
            }
            else
            {
                licenseDetails = new UserLicenseJsonData();
            }

            //adding the new license record to the list
            var detail = new LicenseDetails();
            detail.LicenseKey = liceseKey;
            detail.Type = licType;
            licenseDetails.LicenseList.Add(detail);

            //Saving the license file
            var datalicence = JsonConvert.SerializeObject(licenseDetails);
            byte[] serializedata = Encoding.ASCII.GetBytes(datalicence);
            var serializerdatastring = System.Text.Encoding.UTF8.GetString(serializedata, 0, serializedata.Length);
            var bw = new BinaryWriter(File.Open(Path.Combine(folderPath, "LicenseData.txt"), FileMode.OpenOrCreate));
            bw.Write(serializedata.ToArray());
            bw.Dispose();
        }

        public string GenerateLicense()
        {
            bool status;
            var userUniqueId = UniqueuserIdentifier();
            var licenseKey = string.Empty;
            while (string.IsNullOrEmpty(licenseKey))
            {
                var key = GetlicenseKey();
                if (!_dbContext.License.ToList().Any(l => l.LicenseKey == key))
                    licenseKey = key;
            }

            status = UpdateSubScriptionDetails(userUniqueId, licenseKey);
            if (status)
                return licenseKey;
            return string.Empty;
        }

        public string GetlicenseKey()
        {
            var keygeneration = new GenerateKey();
            keygeneration.LicenseTemplate = "vvvvppppxxxxxxxxxxxx-xxxxxxxxxxxxxxxxxxxx-xxxxxxxxxxxxxxxxxxxx" +
                                            "-xxxxxxxxxxxxxxxxxxxx-xxxxxxxxxxxxxxxxxxxx";
            keygeneration.MaxTokens = 2;
            keygeneration.AddToken(0, "v", GenerateKey.TokenTypes.NUMBER, "1");
            keygeneration.AddToken(1, "p", GenerateKey.TokenTypes.NUMBER, "2");
            keygeneration.UseBase10 = false;
            keygeneration.UseBytes = false;
            keygeneration.CreateKey();
            return keygeneration.GetLicenseKey();
        }

        public bool UpdateSubScriptionDetails(string userUniqueId, string licenseKey)
        {
            var lic = new License();
            lic.IsAvailable = false;
            lic.LicenseKey = licenseKey;
            lic.LicenseTypeId = SingletonLicense.Instance.SelectedSubscription.TypeId;

            var userLic = new UserLicense();
            userLic.UserKey = userUniqueId;
            userLic.ActivationDate = DateTime.Today;

            try
            {
                lic = _dbContext.License.Add(lic);
                userLic.LicenseId = lic.LicenseId;
                _dbContext.UserLicense.Add(userLic);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public string UniqueuserIdentifier()
        {
            string processId = string.Empty, motherBoard = string.Empty, volumeSerial = string.Empty;
            var mos = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
            var proDetails = mos.Get();
            foreach (ManagementObject o in proDetails)
                processId = o.Properties["ProcessorId"].Value.ToString();

            mos = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
            var moc = mos.Get();
            foreach (ManagementObject mo in moc)
                motherBoard = (string)mo["SerialNumber"];

            var drive = "C";
            var dsk = new ManagementObject(@"win32_logicaldisk.deviceid=""" + drive + @":""");
            dsk.Get();
            volumeSerial = dsk["VolumeSerialNumber"].ToString();
            try
            {
                var _id = string.Concat("LicenceModule", processId, motherBoard, volumeSerial);
                var _byteIds = Encoding.UTF8.GetBytes(_id);

                //Use MD5 to get the fixed length checksum of the ID string
                var _md5 = new MD5CryptoServiceProvider();
                var _checksum = _md5.ComputeHash(_byteIds);

                //Convert checksum into 4 ulong parts and use BASE36 to encode both
                var _part1Id = Base36.Encode(BitConverter.ToUInt32(_checksum, 0));
                var _part2Id = Base36.Encode(BitConverter.ToUInt32(_checksum, 4));
                var _part3Id = Base36.Encode(BitConverter.ToUInt32(_checksum, 8));
                var _part4Id = Base36.Encode(BitConverter.ToUInt32(_checksum, 12));

                //Concat these 4 part into one string
                return string.Format("{0}-{1}-{2}-{3}", _part1Id, _part2Id, _part3Id, _part4Id);
            }
            catch (Exception)
            {
            }
            return null;
        }

        public bool CreateUserInfo()
        {
            try
            {
                if (_dbContext.User.ToList().Any(u => u.Email == User.Email))
                {
                    ErrorMessage = "Email id is lready registered";
                    return false;
                }
                var _team =
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
                }
                User = _dbContext.User.Add(User);
                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public List<LicenseType> GetSubscriptionDetails()
        {
            return _dbContext.LicenseType.ToList();
        }
    }
}