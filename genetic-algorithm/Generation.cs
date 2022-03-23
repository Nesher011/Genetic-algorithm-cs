namespace genetic_algorithm
{
    internal class Generation
    {
        public List<Individual> Population { get; set; }

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
            List < Individual > sortedList= Population.OrderBy(individual=>individual.FitnessValue).ToList();
            

            return sortedList[0];
        }
    }
}
