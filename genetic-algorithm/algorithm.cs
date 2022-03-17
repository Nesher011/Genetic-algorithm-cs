namespace genetic_algorithm
{
    internal class Algorithm
    {
        public Algorithm()
        {
            TournamentSize = 3;
            RateOfCrossover = 0.9;
            RateOfMutation = 1 / 96;
        }
        public double RateOfCrossover { get; set; }
        public double RateOfMutation { get; set; }
        public Generation Generation { get; set; }
        private int TournamentSize { get; set; }
        public Individual TournamentSelection(Generation generation)
        {
            Random random = new();
            /* TO DO: create a better function to get 3 random individuals that cannot be the same*/
            Individual selectedIndividual = generation.Population[random.Next(generation.Population.Count())];
            for (int i = 0; i < TournamentSize; i++)
            {
                Individual randomlyChosenIndividual = generation.Population[random.Next(generation.Population.Count())];
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
            for (int i = 0; i < generation.Population.Count(); i++)
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
