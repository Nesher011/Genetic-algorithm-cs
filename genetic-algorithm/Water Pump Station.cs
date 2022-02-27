﻿using System;
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
            waterDemand = new List<decimal>(){ 60, 50, 40, 30, 40, 50, 60, 100, 120, 150, 160, 160, 160, 130, 130, 150, 150, 150, 140, 130, 120, 100, 80, 70 };
            waterPumpVolume = new List<int>() { 0, 10, 30, 40, 50, 60, 80, 90, 100, 110, 130, 140, 150, 160, 180, 190 }; 
            waterPumpElectricity = new List<int>() { 0, 12, 30, 42, 44, 56, 74, 86, 80, 92, 111, 124, 127, 141, 165, 182 };
            energyPriceDay = 0.37M;
            energyPriceNight = 0.51M;
            costOfLostWater = 1000;
            initialWaterLevel = 200;
        }
        public List<decimal> waterDemand { get; }
        public List<int> waterPumpVolume { get; }
        public List<int> waterPumpElectricity { get; }

        internal decimal initialWaterLevel { get; }

        public decimal energyPriceDay { get; set; }
        public decimal energyPriceNight { get; set; }
        public decimal costOfLostWater { get; }

    }
}
