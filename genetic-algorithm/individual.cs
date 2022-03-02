using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genetic_algorithm
{
    internal class Individual
    {
        public Individual(int numOfGenes)
        {
            random = new Random();
            pumpSchedule = new bool[4,24];
            Water_Pump_Station waterPumpStation = new Water_Pump_Station();
            numberOfGenes = numOfGenes;
            genesList = generateGenes(numberOfGenes);
            createPumpLists();
            waterLevelList = new List<decimal>();
            actualWaterLevel = waterPumpStation.initialWaterLevel;
            lostWater = 0;
            costOfSolution = 0;
            fitnessValue = FitnessFunction(waterPumpStation);
        }
        public decimal initialWaterLevel { get; set; }
        public List<decimal> waterLevelList { get; }
        public List<bool> genesList { get; set; }
        public int numberOfGenes { get; }
        public decimal actualWaterLevel { get; set; }
        public bool[,] pumpSchedule { get; set; }
        public decimal lostWater { get; set; }
        public decimal costOfSolution { get; set; }
        private Random random { get; set; }
        public decimal fitnessValue { get; set; }
        public List<bool> generateGenes(int numberOfGenes)
        {
            genesList = new List<bool>();
            for (int i = 0; i < numberOfGenes; i++)
            {
                genesList.Add(random.NextDouble() >= 0.5);
            }
            return genesList;
        }
        public void createPumpLists()
        {
            for (int i = 0; i < numberOfPumps; i++)
            {
                for(int j = 0; j < numberOfGenes / numberOfPumps; j++)
                {
                    pumpSchedule[i,j] = genesList[j+i*24];
                }
            }
        }
        public List<decimal> createWaterLevelList(Water_Pump_Station waterPumpStation)
        {
            int variationOfPumpsUsed=0;
            lostWater = 0;
            for (int i = 0; i < pumpSchedule.GetLength(0); i++)
            {
                for(int j=0;j < pumpSchedule.GetLength(1); j++)
                {
                    variationOfPumpsUsed += pumpSchedule[i,j] == true ? Convert.ToInt32(Math.Pow(2, i)) : 0;
                }
                decimal actualPumpVolume = waterPumpStation.waterPumpVolume[variationOfPumpsUsed];
                Console.WriteLine(variationOfPumpsUsed);
                actualWaterLevel = actualWaterLevel + actualPumpVolume - waterPumpStation.waterDemand[i];
                waterLevelList.Add(actualWaterLevel);
                if (actualWaterLevel > 800)
                {
                    lostWater += actualWaterLevel - 800;
                    actualWaterLevel = 800;
                }
                else if (actualWaterLevel < 0)
                {
                    lostWater -= actualWaterLevel;
                    actualWaterLevel = 0;
                }
            }
            if (waterLevelList.Last() < initialWaterLevel)
            {
                lostWater += initialWaterLevel - waterLevelList[-1];
            }
            return waterLevelList;
        }
        public decimal CalculateCost(Water_Pump_Station waterPumpStation)
        {
            List<decimal> pumpElectricityList = new List<decimal>();
            decimal totalCost = 0;
            for (int j = 0; j < pumpSchedule.GetLength(1); j++)
            {
                int variationOfPumpsUsed = 0;
                for (int i = 0; i < pumpSchedule.GetLength(0); i++)
                {
                    variationOfPumpsUsed += pumpSchedule[i,j] == true ? Convert.ToInt32(Math.Pow(2, i)) : 0;
                }
                pumpElectricityList.Add(waterPumpStation.waterPumpElectricity[variationOfPumpsUsed]);
                totalCost += pumpElectricityList[j] * (j < 7 || j  >= 20 ? waterPumpStation.energyPriceNight : waterPumpStation.energyPriceDay);
            }
            totalCost += lostWater * waterPumpStation.costOfLostWater;
            return totalCost;
        }
        public decimal FitnessFunction(Water_Pump_Station waterPumpStation)
        {
            costOfSolution = CalculateCost(waterPumpStation);
            decimal minimalCubicMeters = 0;
            for (int i = 0; i < waterPumpStation.waterDemand.Count(); i++)
            {
                minimalCubicMeters+=waterPumpStation.waterDemand[i];
            }
            decimal minimalCost = minimalCubicMeters * waterPumpStation.energyPriceNight;
            return costOfSolution/minimalCost;
        }

    }
}