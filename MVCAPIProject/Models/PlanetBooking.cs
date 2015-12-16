using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAPIProject.Models
{
    public class PlanetBooking
    {
        public int EID { get; set; }
        public int PlanetID { get; set; }
        public string HumanName { get; set; }
        public string Gender { get; set; }
        public int FamilySize { get; set; }
        
    }
}