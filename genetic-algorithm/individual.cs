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
            FitnessValue = FitnessFunction(waterPumpStation);
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
            decimal actualWaterLevel = waterPumpStation.InitialWaterLevel;
            List<decimal> WaterVolumeList = CreateList(waterPumpStation.WaterPumpVolume);
            waterPumpStation.LostWater = 0;
            for (int i = 0; i < GenesList.Count / NumberOfPumps; i++)
            {
                actualWaterLevel += WaterVolumeList[i] - waterPumpStation.WaterDemand[i];
                WaterLevelList.Add(actualWaterLevel);
                if (actualWaterLevel > 800)
                {
                    waterPumpStation.LostWater += actualWaterLevel - 800;
                    actualWaterLevel = waterPumpStation.MaxWaterLevel;
                }
                else if (actualWaterLevel < 0)
                {
                    waterPumpStation.LostWater -= actualWaterLevel;
                    actualWaterLevel = waterPumpStation.MinWaterLevel;
                }
            }
            if (WaterLevelList.Last() < waterPumpStation.InitialWaterLevel)
            {
                waterPumpStation.LostWater += waterPumpStation.InitialWaterLevel - WaterLevelList.Last();
            }
            Console.WriteLine(waterPumpStation.LostWater);
            foreach (decimal waterLevel in WaterLevelList)
            {
                Console.WriteLine(waterLevel);
            }
            return WaterLevelList;
        }

        private decimal CalculateCost(WaterPumpStation waterPumpStation)
        {
            decimal totalCost = 0;
            List<decimal> electricityList = CreateList(waterPumpStation.WaterPumpElectricity);
            for (int i = 0; i < GenesList.Count / NumberOfPumps; i++)
            {
                totalCost = electricityList[i] * (i < 7 || i > 20 ? waterPumpStation.EnergyPriceNight : waterPumpStation.EnergyPriceDay);
            }
            totalCost += waterPumpStation.LostWater * waterPumpStation.CostOfLostWater;
            return totalCost;
        }
        private List<decimal> CreateList(List<decimal> inputList)
        {
            List<decimal> outputList = new();
            for (int i = 0; i < GenesList.Count / NumberOfPumps; i++)
            {
                int variationOfPumpsUsed = 0;
                for (int j = 0; j < NumberOfPumps; j++)
                {
                    variationOfPumpsUsed += GenesList[i + j * 24] == true ? Convert.ToInt32(Math.Pow(2, j)) : 0;
                }
                outputList.Add(inputList[variationOfPumpsUsed]);
            }
            return outputList;
        }

        public decimal FitnessFunction(WaterPumpStation waterPumpStation)
        {
            decimal minimalCubicMeters = 0;
            for (int i = 0; i < waterPumpStation.WaterDemand.Count; i++)
            {
                minimalCubicMeters += waterPumpStation.WaterDemand[i];
            }
            decimal minimalCost = minimalCubicMeters * waterPumpStation.EnergyPriceNight;
            return CostOfSolution / minimalCost;
        }
    }
}