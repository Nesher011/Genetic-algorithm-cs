using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genetic_algorithm
{
    internal class Water_Pump_Station
    {
        public Water_Pump_Station()
        {
            waterDemand = new List<float>();
            waterPumpVolume = new List<int>();
            waterPumpElectricity = new List<int>();
            waterDemand.Add(60);
            waterDemand.Add(50);
            waterPumpVolume.Add(0);
            waterPumpVolume.Add(10);
            waterPumpElectricity.Add(0);
            waterPumpElectricity.Add(12);
        }
        public List<float> waterDemand { get; }
        public List<int> waterPumpVolume { get; }
        public List<int> waterPumpElectricity { get; }

    }
}
