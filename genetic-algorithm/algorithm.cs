namespace genetic_algorithm
{
    internal class Algorithm
    {
        public Algorithm()
        {
            random = new Random();
            tournamentSize = 3;
            rateOfCrossover = 0.9;
            rateOfMutation = 1 / 96;
        }
        public double rateOfCrossover { get; set; }
        public double rateOfMutation { get; set; }
        public Generation generation { get; set; }
        private Random random { get; set; }
        private int tournamentSize { get; set; }
        public Individual TournamentSelection(Generation generation)
        {
            /* TO DO: create a better function to get 3 random individuals that cannot be the same*/
            Individual selectedIndividual = generation.population[random.Next(generation.population.Count())];
            for (int i = 0; i < tournamentSize; i++)
            {
                Individual randomlyChosenIndividual = generation.population[random.Next(generation.population.Count())];
                if (randomlyChosenIndividual.FitnessValue > selectedIndividual.FitnessValue)
                {
                    selectedIndividual = randomlyChosenIndividual;
                }
            }
            return selectedIndividual;
        }

        public List<Individual> ListOfParents(Generation generation)
        {
            List<Individual> listOfParents = new List<Individual>();
            for (int i = 0; i < generation.population.Count(); i++)
            {
                Individual selectedIndividual = TournamentSelection(generation);
                listOfParents.Add(selectedIndividual);
            }
            return listOfParents;
        }

        public (Individual, Individual) Crossover(Individual parentOne, Individual parentTwo)
        {
            Individual childOne = parentOne;
            Individual childTwo = parentTwo;
            for (int i = 0; i < parentOne.GenesList.Count(); i++)
            {


            }
            return (childOne, childTwo);
        }

    }
}
