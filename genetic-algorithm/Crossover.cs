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
            foreach (bool gene in childOne.GenesList)
            {
                Console.Write(gene == true ? "1" : "0");
                Console.Write(" ");
            }
            Random random = new();
            int pointOfCrossover = random.Next(childOne.GenesList.Count);
            if (random.NextDouble() <= RateOfCrossover)
            {
                List<bool> childOnePartOne = childOne.GenesList.GetRange(0, pointOfCrossover);
                List<bool> childOnePartTwo = childOne.GenesList.GetRange(pointOfCrossover, childOne.GenesList.Count-pointOfCrossover);
                List<bool> childTwoPartOne=childTwo.GenesList.GetRange(0, pointOfCrossover);
                List<bool> childTwoPartTwo = childTwo.GenesList.GetRange(pointOfCrossover, childTwo.GenesList.Count-pointOfCrossover);
                childOne.GenesList = childOnePartOne.Concat(childTwoPartTwo).ToList();
                childTwo.GenesList = childTwoPartOne.Concat(childOnePartTwo).ToList();
            }
            Console.WriteLine("");
            foreach (bool gene in childOne.GenesList)
            {
                Console.Write(gene == true ? "1" : "0");
                Console.Write(" ");
            }
        }
    }
}
