using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportManagmentSystemAPI.DBconfig;
using TransportManagmentSystemAPI.Models;

//Core Service - travaller profile managment 
namespace TransportManagmentSystemAPI.Services
{
    public class TravallerProfileService : ITravallerService
    {
        private readonly IMongoCollection<TravallerProfile> _travalProfileList;
        private readonly IMongoCollection<User> _userList;
        private readonly IMongoDatabase _database;
        public TravallerProfileService(IDatabaseSettings _databaseSettings,IScheam _scheam)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _travalProfileList = database.GetCollection<TravallerProfile>(_scheam.TravellerScheama);
            _userList = database.GetCollection<User>(_scheam.UsersScheama);
        }

        // Method for creating or updating a traveller profile
        public TravallerProfile CreateUpdateTravellerProfile(TravallerProfile travallerProfile)
        {
            try
            {
                
                if (travallerProfile.Id != null)
                {
                    //profile update
                    var update = Builders<TravallerProfile>.Update.
                        Set(upf => upf.FirstName, travallerProfile.FirstName)
                        .Set(upf => upf.LastName, travallerProfile.LastName)
                        .Set(upf => upf.MobileNo, travallerProfile.MobileNo);

                    var updatedProfile = _travalProfileList.UpdateOne(trav => trav.Id == travallerProfile.Id, update);

                    if (travallerProfile?.TravellerInfo != null && travallerProfile.TravellerInfo.Password != null)
                    {
                        // Update password
                        var updatePassword = Builders<User>.Update.
                            Set(upf => upf.Password, travallerProfile.TravellerInfo.Password);
                        var passwordReset = _userList.UpdateOne(up => up.Nic == travallerProfile.Nic, updatePassword);
                    }
                    
                    return travallerProfile;
                }
                else
                {
                    // creating a new profile
                    var uniqueCounts = _travalProfileList.Find(trv => trv.Nic == travallerProfile.Nic).ToList().Count;
                    if (uniqueCounts == 0)
                    {
                        travallerProfile.AccCreatedDate = DateTime.Now;
                        travallerProfile.TravellerInfo.Nic = travallerProfile.Nic;
                        _userList.InsertOne(travallerProfile.TravellerInfo);
                        _travalProfileList.InsertOne(travallerProfile);
                        return travallerProfile;
                    }
                    else
                    {
                        return null;
                    }
                }
                
            }
            catch (Exception e)
            {
                throw new Exception("Something went wrong ERRLOGGED ! " + e.ToString());
            }
            
        }

        // Method for deleting a traveller profile by NIC
        public String DeletedTravellerProfile(String _Nic)
        {
            try
            {
                 _travalProfileList.DeleteOne(trv => trv.Nic == _Nic);
                return _Nic;

            }
            catch (Exception e)
            {
                throw new Exception("Something went wrong ERRLOGGED ! " + e.ToString());
            }
        }

        // Method for displaying all active profiles
        public List<TravallerProfile> DisplayAllActiveProfile(bool isActive)
        {
            try
            {
                var profileList = _travalProfileList.Find(trav => trav.AccStatus == isActive).ToList();

                List<TravallerProfile> secureProfileList = profileList.Select(item =>
                {
                    item.TravellerInfo = null;
                    return item;
                }
                ).ToList();

                return secureProfileList.Count > 0 ? secureProfileList : null; 
            }
            catch (Exception e)
            {
                throw new Exception("Something went wrong ERRLOGGED ! " + e.ToString());
            }
        }

        // Method for managing the activation status of a traveller profile
        public TravallerProfile ManageActivationTravellerProfile(string nic , TravallerProfile travallerProfile)
        {
            try
            {
                if (nic != null)
                {
                    var updatedStatus = Builders<TravallerProfile>.Update.
                           Set(upf => upf.AccStatus, travallerProfile.AccStatus);
                    _travalProfileList.UpdateOne(trav => trav.Nic == nic, updatedStatus);
                    return travallerProfile;
                }
                else 
                {
                    return null;
                }
               
            }
            catch (Exception e)
            {
                throw new Exception("Something went wrong ERRLOGGED ! " + e.ToString());
            }
        }

        // Method for getting a traveller profile by NIC
        public TravallerProfile GetTravallerProfileByNic(string _Nic)
        {
            var profile = _travalProfileList.Find(pro => pro.Nic == _Nic).ToList().FirstOrDefault();
            if (profile != null)
            {
                return profile;
            }
            else 
            {
                return null;
            }
        }
    }
}
