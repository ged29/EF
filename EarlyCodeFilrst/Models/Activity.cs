using System.Collections.Generic;

namespace EarlyCodeFilrst.Models
{
    public class Activity
    {
        public int ActivityId { get; set; }        
        public string Name { get; set; }

        public List<Trip> Trips { get; set; }
    }
}
