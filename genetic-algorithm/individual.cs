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
            numberOfPumps = 4;
            numberOfGenes = numOfGenes;
            genesList = generateGenes();
            createPumpLists();
            waterLevelList = new List<double>();
            actualWaterLevel = waterPumpStation.initialWaterLevel;
            lostWater = 0;
            costOfSolution = 0;
        }
        public double initialWaterLevel { get; set; }

        public List<double> waterLevelList { get; }

        public List<bool> genesList { get; set; }

        public int numberOfGenes { get; set; }

        public int numberOfPumps { get; set; }

        public double actualWaterLevel { get; set; }

        public bool[,] pumpSchedule { get; set; }

        public double lostWater { get; set; }
        public double costOfSolution { get; set; }

        private Random random { get; set; }

        public List<bool> generateGenes()
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

        public List<double> createWaterLevelList(Water_Pump_Station waterPumpStation)
        {
            int variationOfPumpsUsed=0;
            lostWater = 0;
            for (int i = 0; i < pumpSchedule.GetLength(0); i++)
            {
                for(int j=0;j < pumpSchedule.GetLength(1); j++)
                {
                    variationOfPumpsUsed += pumpSchedule[i,j] == true ? Convert.ToInt32(Math.Pow(2, i)) : 0;
                }
                double actualPumpVolume = waterPumpStation.waterPumpVolume[variationOfPumpsUsed];
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
            Console.WriteLine(waterLevelList[0]);
            if (waterLevelList.Last() < initialWaterLevel)
            {
                lostWater += initialWaterLevel - waterLevelList[-1];
            }
            return waterLevelList;
        }

        public double CalculateCost(Water_Pump_Station waterPumpStation)
        {
            List<double> pumpElectricityList = new List<double>();
            double totalCost = 0;
            Console.WriteLine(pumpSchedule.GetLength(0));
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
        public double FitnessFunction()
        {
            //Console.WriteLine(numberOfGenes);
            return numberOfGenes;
        }
        public bool czyKochaPiwo()
        {
            return random.NextDouble() > 0.5;
        }
    }
}