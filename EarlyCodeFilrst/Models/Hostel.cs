using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarlyCodeFilrst.Models
{
    public class Hostel : Lodging
    {
        public int MaxPersonsPerRoom { get; set; }
        public bool PrivateRoomsAvailable { get; set; }
    }
}