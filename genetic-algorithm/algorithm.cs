namespace genetic_algorithm
{
    internal class Algorithm
    {
        private double RateOfCrossover { get; set; }
        private double RateOfMutation { get; set; }
        private int TournamentSize { get; }
        public Algorithm()
        {

        }
        public (Individual,Individual) Crossover(Individual parentOne, Individual parentTwo, Crossover typeOfCrossover)
        {
            Individual childOne = new();
            Individual childTwo = new();
            childOne.GenesList = parentOne.GenesList;
            childTwo.GenesList = parentTwo.GenesList;
            typeOfCrossover.SinglePoint(childOne, childTwo, RateOfCrossover);
            return (childOne,childTwo);
        }
        public Generation Generation { get; set; }
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
    }
}
