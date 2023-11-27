using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportManagmentSystemAPI.Models
{
    // Initialization of attributes for TravallerProfile model 
    public class TravallerProfile
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nic { get; set; }
        public string MobileNo { get; set; }
        public bool AccStatus { get; set; }
        public DateTime AccCreatedDate { get; set; }

        [BsonIgnore]
        public User TravellerInfo { get; set; }

    }
}
