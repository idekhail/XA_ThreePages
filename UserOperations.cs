using System;
using System.Collections.Generic;
using System.IO;
using SQLite;
namespace XA1_ThreePages
{
    public class UserOperations
    {
        //database path
        private readonly string dbPath = Path.Combine(
                System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "XA2DB1.db3");
        //Constructor     
        public UserOperations()
        {
            //Creating database, if it doesn't already exist 
            if (!File.Exists(dbPath))
            {
                var db = new SQLiteConnection(dbPath);
                db.CreateTable<Users>();
                //db.CreateTable<Students>();
            }
        }
        //  Insert users intoDB (array of users)
        //  ادخال مستخدم جديد
        public void InsertUser(Users user)
        {
            var db = new SQLiteConnection(dbPath);
            db.Insert(user);
        }

        // User Upbdate
        public void UpdateUser(Users user)
        {
            var db = new SQLiteConnection(dbPath);
            db.Update(user);
        }

        // User Delete
        public void DeleteUser(Users user)
        {
            var db = new SQLiteConnection(dbPath);
            db.Delete(user);
        }


        // Object ارجاع بيانات مستخدم واحد على شكل   
        public Users GetUser(string username, string password)
        {
            var db = new SQLiteConnection(dbPath);
            //Console.WriteLine("Reading data From Table");
            var user = db.Table<Users>().Where(i => i.Username == username && i.Password == password).FirstOrDefault();
            return user;
        }
        // Return User Record by using UId
        public Users GetUserById(int uid)
        {
            var db = new SQLiteConnection(dbPath);
            Console.WriteLine("Reading data From Table");
            try
            {
                var user = db.Table<Users>().Where(i => i.UId == uid).FirstOrDefault();
                return user;
            }
            catch
            {
                return null;
            }
        }
        public List<Users> GetAllUsers()
        {
            var db = new SQLiteConnection(dbPath);
            Console.WriteLine("Reading data From Table");
            try
            {
                var user = db.Table<Users>().ToList();
                return user;
            }
            catch
            {
                return null;
            }
        }
        [Table("Users")]
        public class Users
        {
            [PrimaryKey, AutoIncrement, Column("_uid")]
            public int UId { get; set; }
            [MaxLength(3)]
            public string Username { get; set; }
            [MaxLength(2)]
            public string Password { get; set; }
            [MaxLength(3)]
            public string Mobile { get; set; }
            [MaxLength(2)]
            public string Email { get; set; }
            public double Latitude { get; set; }
            public double Longitude { get; set; }
        }        
    }
}
