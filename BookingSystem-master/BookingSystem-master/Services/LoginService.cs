using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportManagmentSystemAPI.DBconfig;
using TransportManagmentSystemAPI.Interfaces;
using TransportManagmentSystemAPI.Models;

//Core Service - login Controller and Service
namespace TransportManagmentSystemAPI.Services
{
    public class LoginService : ILoginService
    {
        private readonly IMongoCollection<User> _userList;
        private readonly IMongoCollection<TravallerProfile> _travalProfileList;

        public LoginService(IDatabaseSettings _databaseSettings, IScheam _scheam)
        {
            // Initializing MongoDB client and database
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);

            // Getting collections for User and TravallerProfile
            _travalProfileList = database.GetCollection<TravallerProfile>(_scheam.TravellerScheama);
            _userList = database.GetCollection<User>(_scheam.UsersScheama);
        }

        //Method - User Login
        public User MakeLogin(User user)
        {
            // Checking if NIC and Password are provided
            if (user.Nic != null && user.Password != null)
            {
               var profileActiveOrExist =  _travalProfileList.Find(pro => pro.Nic == user.Nic && pro.AccStatus).FirstOrDefault();
                if (profileActiveOrExist != null)
                {
                    // Validating user based on NIC and Password
                    var validatedUser =   _userList.Find(us => us.Nic == user.Nic && us.Password == user.Password).FirstOrDefault();
                    return validatedUser != null ? validatedUser : null;
                }
                else 
                {
                    return null;
                }
            } 
            else 
            {
                throw new NullReferenceException("Please Enter Your Nic and password!");
            }
        }
    }
}
