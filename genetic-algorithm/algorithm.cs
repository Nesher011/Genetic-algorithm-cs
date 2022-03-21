namespace genetic_algorithm
{
    internal class Algorithm
    {
        private double RateOfCrossover { get; set; }
        private double RateOfMutation { get; set; }
        private int TournamentSize { get; }
        public Algorithm()
        {
            TournamentSize = 3;
            RateOfCrossover = 0.9;
            RateOfMutation = 1 / 96;
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
        public void TournamentSelection(Generation generation)
        {
            Random random = new();
            List<Individual> selectedPopulation = new();
            for(int i = 0; i < generation.Population.Count; i++)
            {
                Individual selectedIndividual=generation.Population[random.Next(generation.Population.Count())];
                for(int j=0; i < TournamentSize; i++)
                {
                    Individual randomIndividual=generation.Population[random.Next(generation.Population.Count())];
                    if (randomIndividual.FitnessValue > selectedIndividual.FitnessValue)
                    {
                        selectedIndividual=randomIndividual;
                    }
                }
                selectedPopulation.Add(selectedIndividual);
            }
            generation.Population = selectedPopulation;
        }

        //public List<Individual> ListOfParents(Generation generation)
        //{
        //    List<Individual> listOfParents = new List<Individual>();
        //    for (int i = 0; i < generation.Population.Count(); i++)
        //    {
        //        Individual selectedIndividual = TournamentSelection(generation);
        //        listOfParents.Add(selectedIndividual);
        //    }
        //    return listOfParents;
        //}
    }
}
