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
        public void Crossover(Generation generation)
        {
            Crossover typeOfCrossover = new();
            for (int i = 0; i < Convert.ToInt32(generation.Population.Count / 2); i++)
            {
                Individual childOne = generation.Population[i];
                Individual childTwo = generation.Population[2 * i];
                typeOfCrossover.SinglePoint(childOne, childTwo, RateOfCrossover);
            }
        }
        public void TournamentSelection(Generation generation)
        {
            Random random = new();
            List<Individual> selectedPopulation = new();
            for(int i = 0; i < generation.Population.Count; i++)
            {
                Individual selectedIndividual=generation.Population[random.Next(generation.Population.Count())];
                for(int j=0; j < TournamentSize; j++)
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

        public void Mutation(Generation generation)
        {

            
            Random random = new();
            foreach(Individual individual in generation.Population)
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
