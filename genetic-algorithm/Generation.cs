namespace genetic_algorithm
{
    internal class Generation
    {
        public List<Individual> Population { get; }

        public Generation(int numberOfIndividuals)
        {
            Population = new List<Individual>();
            for (int i = 0; i < numberOfIndividuals; i++)
            {
                Individual individual = new Individual(96);
                Population.Add(individual);
            }
        }
    }
}
