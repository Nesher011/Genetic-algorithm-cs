using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genetic_algorithm
{
    internal class Crossover    
    {      
        public Crossover()
        {

        }

        public void SinglePoint(Individual childOne, Individual childTwo, double RateOfCrossover)
        {
            Random random = new();
            int pointOfCrossover = random.Next(childOne.GenesList.Count);
            if (random.NextDouble() <= RateOfCrossover)
            {
                childOne.GenesList = childOne.GenesList.GetRange(0, pointOfCrossover).Concat(childTwo.GenesList.GetRange(pointOfCrossover, childOne.GenesList.Count)).ToList();
                childTwo.GenesList = childTwo.GenesList.GetRange(0, pointOfCrossover).Concat(childOne.GenesList.GetRange(pointOfCrossover, childTwo.GenesList.Count)).ToList();
            }
        }
    }
}
