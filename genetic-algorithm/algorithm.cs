using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genetic_algorithm
{
    internal class Algorithm
    {
        public Algorithm()
        {
            random= new Random();
            tournamentSize = 3;
            rateOfCrossover = 0.9;
            rateOfMutation = 1 / 96;
        }
        public double rateOfCrossover { get; set; }
        public double rateOfMutation { get; set; }
        public Generation generation { get; set; }
        private Random random;
        private int tournamentSize { get; set; }
        public Individual tournamentSelection(Generation generation, int tournamentSize)
        {
            /* TO DO: create a better function to get 3 random individuals that cannot be the same*/
            Individual selectedIndividual = generation.population[random.Next(generation.population.Count())];
            for(int i = 0; i < tournamentSize; i++)
            {
                Individual randomlyChosenIndividual = generation.population[random.Next(generation.population.Count())];
                if (randomlyChosenIndividual.fitnessValue > selectedIndividual.fitnessValue)
                {
                    selectedIndividual = randomlyChosenIndividual;
                }
            }
            return selectedIndividual;
        }
    }
}
