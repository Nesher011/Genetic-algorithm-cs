namespace genetic_algorithm
{
    internal class Generation
    {
        public List<Individual> Population { get; set; }

        public Generation(Generation previousGeneration)
        {
            Population = Algorithm.Selection(previousGeneration.Population);
            Algorithm.PerformCrossover(Population);
            Algorithm.Mutation(Population);
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

        private static List<Individual> GenerateFirstPopulation(int numberOfIndividuals)
        {
            List<Individual> population = new();
            for (int i = 0; i < numberOfIndividuals; i++)
            {
                Individual individual = new(96);
                population.Add(individual);
            }
            return population;
        }

        private static List<Individual> GenerateNextPopulation()
        {
            List<Individual> population = new();
            return population;
        }

        public Individual GetBestIndividual()
        {
            List<Individual> sortedList = Population.OrderByDescending(ind => ind.FitnessValue).ToList();
            return sortedList[0];
        }
    }
}