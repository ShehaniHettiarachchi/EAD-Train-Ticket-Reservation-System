using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportManagmentSystemAPI.DBconfig;
using TransportManagmentSystemAPI.Interfaces;
using TransportManagmentSystemAPI.Models;

//Core Service - Schedule Managment Service
namespace TransportManagmentSystemAPI.Services
{
    public class ScheduleServiceManagment : IScheduleService
    {
        private readonly IMongoCollection<Schedule> _schedueList;
        private readonly IMongoCollection<Train> _trainList;
        public ScheduleServiceManagment(IDatabaseSettings _databaseSettings, IScheam _scheam)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);

            // Initialize Schedule collection
            _schedueList = database.GetCollection<Schedule>(_scheam.ScheduleScheam);

            // Initialize Train collection
            _trainList = database.GetCollection<Train>(_scheam.TrainScheam);
        }

        // Method to add a new schedule for an existing train
        public Schedule AddNewScheduleForExisitingTrain(string trainId, Schedule schedule)
        {
            throw new NotImplementedException();
        }

        // Method to update an existing schedule
        public Schedule UpdateSchedule(string id, Schedule schedule)
        {
            throw new NotImplementedException();
        }
    }
}
