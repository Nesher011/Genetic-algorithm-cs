namespace genetic_algorithm
{
    internal class Individual
    {
        public List<bool> GenesList { get; set; }
        private int NumberOfPumps { get; set; }
        private decimal CostOfSolution { get; set; }
        private List<decimal> WaterLevelList { get; set; }
        public decimal FitnessValue { get; }
        public Individual(int numberOfGenes)
        {
            NumberOfPumps = numberOfGenes / 24;//24 hours per day, so one gene for an hour
            GenesList = GenerateGenes(numberOfGenes);
            WaterPumpStation waterPumpStation = new();
            WaterLevelList = CreateWaterLevelList(waterPumpStation);
            CostOfSolution = CalculateCost(waterPumpStation);
            FitnessValue = FitnessFunction(waterPumpStation);

        }
        public Individual()
        {
            int numberOfGenes = 96;
            NumberOfPumps = numberOfGenes / 24;
            GenesList = GenerateGenes(numberOfGenes);
            WaterPumpStation waterPumpStation = new();
            WaterLevelList = CreateWaterLevelList(waterPumpStation);
            CostOfSolution = CalculateCost(waterPumpStation);
        }

        private List<bool> GenerateGenes(int numberOfGenes)
        {
            Random random = new();
            GenesList = new List<bool>();
            for (int i = 0; i < numberOfGenes; i++)
            {
                GenesList.Add(random.NextDouble() >= 0.5);
            }
            return GenesList;
        }

        private List<decimal> CreateWaterLevelList(WaterPumpStation waterPumpStation)
        {
            WaterLevelList = new List<decimal>();
            decimal actualWaterLevel = waterPumpStation.initialWaterLevel;
            int variationOfPumpsUsed;
            waterPumpStation.lostWater = 0;
            for (int i = 0; i < GenesList.Count / NumberOfPumps; i++)
            {
                variationOfPumpsUsed = 0;
                for (int j = 0; j < NumberOfPumps; j++)
                {
                    variationOfPumpsUsed += GenesList[i + j * 24] == true ? Convert.ToInt32(Math.Pow(2, j)) : 0;
                }
                decimal actualPumpVolume = waterPumpStation.waterPumpVolume[variationOfPumpsUsed];
                actualWaterLevel += actualPumpVolume - waterPumpStation.waterDemand[i];
                WaterLevelList.Add(actualWaterLevel);
                if (actualWaterLevel > 800)
                {
                    waterPumpStation.lostWater += actualWaterLevel - 800;
                    actualWaterLevel = waterPumpStation.maxWaterLevel;
                }
                else if (actualWaterLevel < 0)
                {
                    waterPumpStation.lostWater -= actualWaterLevel;
                    actualWaterLevel = waterPumpStation.minWaterLevel;
                }
            }
            if (WaterLevelList.Last() < waterPumpStation.initialWaterLevel)
            {
                waterPumpStation.lostWater += waterPumpStation.initialWaterLevel - WaterLevelList.Last();
            }
            return WaterLevelList;
        }

        public decimal CalculateCost(WaterPumpStation waterPumpStation)
        {
            decimal totalCost = 0;
            //***TO DO*** create a function that takes care of the pump electricity/pump volume List creation
            for (int i = 0; i < GenesList.Count / NumberOfPumps; i++)
            {
                int variationOfPumpsUsed = 0;
                for (int j = 0; j < NumberOfPumps; j++)
                {
                    variationOfPumpsUsed += GenesList[i + j * 24] == true ? Convert.ToInt32(Math.Pow(2, j)) : 0;
                }
                totalCost += waterPumpStation.waterPumpElectricity[variationOfPumpsUsed] * (i < 7 || i >= 20 ? waterPumpStation.energyPriceNight : waterPumpStation.energyPriceDay);
            }
            totalCost += waterPumpStation.lostWater * waterPumpStation.costOfLostWater;
            return totalCost;
        }

        public decimal FitnessFunction(WaterPumpStation waterPumpStation)
        {
            decimal minimalCubicMeters = 0;
            for (int i = 0; i < waterPumpStation.waterDemand.Count; i++)
            {
                minimalCubicMeters += waterPumpStation.waterDemand[i];
            }
            decimal minimalCost = minimalCubicMeters * waterPumpStation.energyPriceNight;
            return CostOfSolution / minimalCost;
        }
    }
}