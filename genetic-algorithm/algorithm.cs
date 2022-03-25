namespace genetic_algorithm
{
    internal class Algorithm
    {
        public double RateOfMutation { get; set; }
        private int TournamentSize { get; }
        public Algorithm()
        {
            TournamentSize = 3;
            RateOfMutation = 1 / 96F;
        }
        public void Crossover(List<Individual> population)
        {
            Crossover typeOfCrossover = new();
            for (int i = 0; i < Convert.ToInt32(population.Count / 2); i++)
            {
                Individual childOne = population[i];
                Individual childTwo = population[i + population.Count / 2];
                typeOfCrossover.SinglePoint(childOne, childTwo);
            }
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

        public void Mutation(List<Individual> population)
        {
            Random random = new();
            foreach (Individual individual in population)
            {
                for (int i = 0; i < individual.GenesList.Count; i++)
                {
                    if (random.NextDouble() <= RateOfMutation)
                    {                       
                        individual.GenesList[i] = !individual.GenesList[i];
                    }
                }

            }

        }
    }
}
