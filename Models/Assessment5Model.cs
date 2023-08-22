using System.Numerics;
using System.Text.RegularExpressions;

namespace MongoAssessment.Models
{
    public class Assessment5Model
    {
        public ErrorMessage ErrorMessage { get; set; }
        public string Successful { get; set; }
        public Containers Containers { get; set; }
        public Groups Groups { get; set; }
        public List<Player> Players { get; set; }
    }

    public class ErrorMessage
    {
    }
    public class Containers
    {
    }
    public class Groups
    {
    }
    public class Player
    {
        public string CustomerID { get; set; }
        public string Name { get; set; }
        public object OfflineSince { get; set; }
        public string PlayerID { get; set; }
        public List<Property> Property { get; set; }
        public string Status { get; set; }
    }
    public class Property
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
