using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CalLicenseDemo.DatabaseContext
{
    public class SQL_LiteDBContext
    {
        SQLiteConnection dbConnection;

        public SQL_LiteDBContext()
        {
            if (!File.Exists("C:\\pavithra\\DataBase\\LicenseSoftware.sqlite"))
                SQLiteConnection.CreateFile("C:\\pavithra\\DataBase\\LicenseSoftware.sqlite");
            dbConnection = new SQLiteConnection("DataSource=C:\\pavithra\\DataBase\\LicenseSoftware.sqlite;Version=3;");
        }

        public void InitializeDB()
        {
           
            dbConnection.Open();

            //Team table Creation
            string sql = "create table Team( TeamId int not null primary key, Name varchar(250), GroupEmail varchar(250))";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();

            //User Table Creation
            sql = "create table Users(" +
                        "UId int not null primary key," +
                        "FName varchar(50), " +
                        "LName varchar(50)," +
                        "EmailId varchar(250)," +
                        "Password varchar(500)," +
                        "TeamID int Foreign Key References Team(TeamId) )";

            command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();

            //License Type Table Cration
            sql = "create table LicenseTypes(" +
                  "TypeId int not null primary key, " +
                  "TypeName varchar(250)," +
                  "Description varchar(max)," +
                  "ActivationDuration int )";
                      

            command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();

            //License Table Creation 
            sql = "create table Licenses(" +
                  "LId int not null primary key, " +
                  "LicenseKey varchar(500)," +
                  "IsAvailable bit," +
                  "LicenseTypeId Foreign Key References LicenseTypes(TypeId))";

            command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();

            //User License Table Creation 
            sql = "create table UserLicenses(" +
                  "ULId int not null primary key, " +
                  "UserKey varchar(500)," +
                  "IsExpired bit,"+
                  "IsDeleted bit,"+
                  "LicenseId Foreign Key References Licenses(LId))";

            command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
            dbConnection.Close();

        }
    }
}
