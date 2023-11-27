using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportManagmentSystemAPI.DBconfig
{
    //Define schemas for the entities in the DB
    public interface IScheam
    {
        // Schema for the Users table.
        public string UsersScheama { get; set; }

        // Schema for the Traveller table.
        public string TravellerScheama { get; set; }

        // Schema for the Train table.
        public string TrainScheam { get; set; }

        // Schema for the Reservation table.
        public string ReservationScheam { get; set; }

        // Schema for the Schedule table.
        public string ScheduleScheam { get; set; }


    }
}
