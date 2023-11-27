using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportManagmentSystemAPI.DBconfig
{
    // Interface for providing database settings
    public interface IDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
