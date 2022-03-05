using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genetic_algorithm
{
    internal class Individual
    {
        private Random random { get; set; }
        public List<bool> genesList { get; set; }
        private int numberOfGenes { get; set; }
        private int numberOfPumps { get; }
        private List<decimal> waterLevelList { get; }
        public List<List<bool>> pumpSchedule { get; }
        private decimal costOfSolution { get; set; }
        public decimal fitnessValue { get; set; }
        private decimal actualWaterLevel { get; set; }
        private decimal lostWater { get; set; }

        private List<bool> generateGenes(int numberOfGenes)
        {
            genesList = new List<bool>();
            for (int i = 0; i < numberOfGenes; i++)
            {
                genesList.Add(random.NextDouble() >= 0.5);
            }
            return genesList;
        }
        private List<List<bool>> createPumpLists()
        {
            List<List<bool>> listOfPumps= new List<List<bool>>();
            for (int i = 0; i < numberOfPumps; i++)
            {
                List<bool> pump = new List<bool>();
                for (int j = 0; j < numberOfGenes / numberOfPumps; j++)
                {
                    pump.Add(genesList[j + i * 24]);
                }
                listOfPumps.Add(pump);
            }
            return listOfPumps;
        }

        public Individual(int numOfGenes)
        {
            random = new Random();
            pumpSchedule = new List<List<bool>>();
            Water_Pump_Station waterPumpStation = new Water_Pump_Station();
            numberOfGenes = numOfGenes;
            numberOfPumps = 4;
            genesList = generateGenes(numberOfGenes);
            createPumpLists();
            waterLevelList = new List<decimal>();
            actualWaterLevel = waterPumpStation.initialWaterLevel;
            lostWater = 0;
            costOfSolution = 0;
            fitnessValue = FitnessFunction(waterPumpStation);
        }   
        
        public List<decimal> createWaterLevelList(Water_Pump_Station waterPumpStation)
        {
            int variationOfPumpsUsed=0;
            lostWater = 0;
            for (int i = 0; i < pumpSchedule.Count(); i++)
            {
                for(int j=0;j < pumpSchedule[0].Count(); j++)
                {
                    variationOfPumpsUsed += pumpSchedule[i][j] == true ? Convert.ToInt32(Math.Pow(2, i)) : 0;
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
            if (waterLevelList.Last() < waterPumpStation.initialWaterLevel)
            {
                lostWater += waterPumpStation.initialWaterLevel - waterLevelList[-1];
            }
            return waterLevelList;
        }

        public decimal CalculateCost(Water_Pump_Station waterPumpStation)
        {
            List<decimal> pumpElectricityList = new List<decimal>();
            decimal totalCost = 0;
            for (int i = 0; i < pumpSchedule.Count(); i++)
            {
                int variationOfPumpsUsed = 0;
                for (int j = 0; j < pumpSchedule[i].Count(); j++)
                {
                    variationOfPumpsUsed += pumpSchedule[i][j] == true ? Convert.ToInt32(Math.Pow(2, i)) : 0;
                }
                pumpElectricityList.Add(waterPumpStation.waterPumpElectricity[variationOfPumpsUsed]);
                totalCost += pumpElectricityList[i] * (i < 7 || i  >= 20 ? waterPumpStation.energyPriceNight : waterPumpStation.energyPriceDay);
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