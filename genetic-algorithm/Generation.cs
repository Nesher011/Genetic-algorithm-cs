﻿namespace genetic_algorithm
{
    class Generation
    {
        public List<Individual> Population { get; set; }

        public Generation(Generation previousGeneration)
        {

            Algorithm algorithm = new();
            this.Population = previousGeneration.Population;


            Population=algorithm.TournamentSelection(Population);

            algorithm.Crossover(Population);
            List<bool> test1 = new(Population[0].GenesList);
            algorithm.Mutation(Population);
            List<bool> test2 = new(Population[0].GenesList);
            foreach (Individual ind in Population)
            {
                ind.CalculateIndividual();
            }
        }

        public Generation(int numberOfIndividuals, int generationNumber)
        {
            if (generationNumber == 1)
            {
                Population = GenerateFirstPopulation(numberOfIndividuals);
            }
            else
            {
                Population = GenerateNextPopulation();
            }
        }

        private List<Individual> GenerateFirstPopulation(int numberOfIndividuals)
        {
            List<Individual> population = new();
            for (int i = 0; i < numberOfIndividuals; i++)
            {
                Individual individual = new(96);
                population.Add(individual);
            }
            return population;
        }
        private List<Individual> GenerateNextPopulation()
        {
            List<Individual> population = new();
            return population;
        }

        public Individual GetBestIndividual()
        {
            List < Individual > sortedList= Population.OrderByDescending(ind=>ind.FitnessValue).ToList();
            return sortedList[0];
        }
    }
}
