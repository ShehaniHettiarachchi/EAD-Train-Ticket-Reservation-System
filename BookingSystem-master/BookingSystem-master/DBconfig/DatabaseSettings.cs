using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportManagmentSystemAPI.DBconfig
{
    // Initialization of the configuration settings for the database.
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
