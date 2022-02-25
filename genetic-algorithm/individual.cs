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
            pump1 = new List<bool>();
            pump2 = new List<bool>();
            pump3 = new List<bool>();
            pump4 = new List<bool>();
            genesList = new List<bool>();
            numberOfGenes = numOfGenes;
            waterLevelList = new List<double>();
            numberOfPumps = 4;
            initialWaterLevel = 200;
            actualWaterLevel = initialWaterLevel;
        }
        public double initialWaterLevel { get; set; }

        public List<double> waterLevelList { get; }

        public List<bool> genesList { get; set; }

        public int numberOfGenes { get; set; }

        public int numberOfPumps { get; set; }

        public double actualWaterLevel { get; set; }

        public List<bool> pump1 { get; set; }
        public List<bool> pump2 { get; set; }
        public List<bool> pump3 { get; set; }
        public List<bool> pump4 { get; set; }

        public void createPumpLists()
        {
            for (int i = 0; i < numberOfGenes / numberOfPumps; i++)
            {
                pump1.Add(genesList[i]);
                pump2.Add(genesList[i + numberOfGenes / numberOfPumps]);
                pump3.Add(genesList[i + numberOfGenes * 2 / numberOfPumps]);
                pump4.Add(genesList[i + numberOfGenes * 2 / numberOfPumps]);
            }
        }

        public List<double> createWaterLevelList(Water_Pump_Station waterPumpStation)
        {

            int variationOfPumpsUsed;
            double lostWater = 0;

            for (int i = 0; i < pump1.Count(); i++)
            {
                
                variationOfPumpsUsed = (pump1[i]==true?1:0);
                variationOfPumpsUsed += pump2[i] == true ? 1*2 : 0;
                variationOfPumpsUsed += pump3[i] == true ? 1 * 4 : 0;
                variationOfPumpsUsed += pump4[i] == true ? 1 * 8 : 0;
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
            if(waterLevelList[-1]<initialWaterLevel)
            {
                lostWater+=initialWaterLevel-waterLevelList[-1];
            }
            return waterLevelList;
        }

        public double CalculateCost()
        {
            double cost = 0;
            return cost;
        }
        public double FitnessFunction()
        {
            //Console.WriteLine(numberOfGenes);
            return numberOfGenes;
        }
    }

}
