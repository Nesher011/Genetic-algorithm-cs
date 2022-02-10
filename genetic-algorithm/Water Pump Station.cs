using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genetic_algorithm
{
    internal class Water_Pump_Station
    {
        public Water_Pump_Station(float[] demand, int[] pumpVolume, int[] pumpElectricity)
        {
            waterDemand = new List<float>();
            waterPumpVolume = new List<int>();
            waterPumpElectricity = new List<int>();
            waterDemand.AddRange(demand);
            waterPumpVolume.AddRange(pumpVolume);
            waterPumpElectricity.AddRange(pumpElectricity);
        }
        public List<float> waterDemand { get; }
        public List<int> waterPumpVolume { get; }
        public List<int> waterPumpElectricity { get; }

    }
}
