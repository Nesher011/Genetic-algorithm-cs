namespace genetic_algorithm
{
    internal class Algorithm
    {
        public double RateOfMutation { get; set; }
        private int TournamentSize { get; }
        public Algorithm()
        {
            TournamentSize = 3;
        }
        public static void Crossover(List<Individual> population)
        {
            Crossover crossover = new();
            crossover.SinglePoint(population);
            
        }
        public List<Individual> TournamentSelection(List<Individual> population)
        {
            Random random = new();
            List<Individual> selectedPopulation = new();
            for (int i = 0; i < population.Count; i++)
            {
                Individual selectedIndividual = population[random.Next(population.Count())];
                for (int j = 0; j < TournamentSize; j++)
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

        public static void Mutation(List<Individual> population)
        {
            Mutation mutation = new();
            mutation.SinglePoint(population);
        }
    }
}
