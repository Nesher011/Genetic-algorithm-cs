namespace genetic_algorithm
{
    internal class Generation
    {
        public List<Individual> Population { get; }

        public Generation(int numberOfIndividuals)
        {
            Population = GenerateFirstPopulation(numberOfIndividuals);
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
    }
}
