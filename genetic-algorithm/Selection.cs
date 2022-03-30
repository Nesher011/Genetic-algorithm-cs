using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genetic_algorithm
{
    internal class Selection
    {
        public Selection()
        {
        }
        public List<Individual> Tournament(List<Individual> population)
        {
            int tournamentSize = 3;
            Random random = new();
            List<Individual> selectedPopulation = new();
            for (int i = 0; i < population.Count; i++)
            {
                Individual selectedIndividual = population[random.Next(population.Count())];
                for (int j = 0; j < tournamentSize; j++)
                {
                    Individual randomIndividual = population[random.Next(population.Count())];
                    if (randomIndividual.FitnessValue > selectedIndividual.FitnessValue)
                    {
                        selectedIndividual = randomIndividual;
                    }
                }
                selectedPopulation.Add(selectedIndividual);
            }
            population = selectedPopulation;
            return population;
        }
    }
}
