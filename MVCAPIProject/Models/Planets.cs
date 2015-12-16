using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAPIProject.Models
{
    public class Planets
    {
        public int PlanetID { get; set; }
        public string PlanetName { get; set; }
        public int GalaxyID { get; set; }
        public string GalaxyName { get; set; }
        public string PlanetColor { get; set; }
        public int RingsNumber { get; set; }
        public string Civilization { get; set; }
        public int RecolutionTime { get; set; }

    }
}