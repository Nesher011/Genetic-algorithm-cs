namespace genetic_algorithm
{
    internal class WaterPumpStation
    {
        public WaterPumpStation()
        {
            WaterDemand = new List<decimal>() { 60, 50, 40, 30, 40, 50, 60, 100, 120, 150, 160, 160, 160, 130, 130, 150, 150, 150, 140, 130, 120, 100, 80, 70 };
            WaterPumpVolume = new List<decimal>() { 0, 10, 30, 40, 50, 60, 80, 90, 100, 110, 130, 140, 150, 160, 180, 190 };
            WaterPumpElectricity = new List<decimal>() { 0, 12, 30, 42, 44, 56, 74, 86, 80, 92, 111, 124, 127, 141, 165, 182 };
            EnergyPriceDay = 0.51M;
            EnergyPriceNight = 0.34M;
            MaxWaterLevel = 800;
            MinWaterLevel = 0;
            CostOfLostWater = 1000;
            InitialWaterLevel = 300;
        }
        public List<decimal> WaterDemand { get; }
        public List<decimal> WaterPumpVolume { get; }
        public List<decimal> WaterPumpElectricity { get; }
        public decimal InitialWaterLevel { get; }
        public decimal MaxWaterLevel { get; private set; }
        public decimal MinWaterLevel { get; private set; }
        public decimal LostWater { get; set; }
        public decimal EnergyPriceDay { get; }
        public decimal EnergyPriceNight { get; private set; }
        public decimal CostOfLostWater { get; }
    }
}
