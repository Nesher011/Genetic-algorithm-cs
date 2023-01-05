namespace genetic_algorithm
{
    internal class Algorithm
    {
        private static readonly double _rateOfCrossover = 0.9;

        public Algorithm()
        {
        }

        public static void PerformCrossover(List<Individual> population)
        {
            Crossover.SinglePoint(population, _rateOfCrossover);
        }

        public static List<Individual> Selection(List<Individual> population)
        {
            Selection selection = new();
            population = selection.Tournament(population);
            return population;
        }

        public static void Mutation(List<Individual> population)
        {
            Mutation mutation = new();
            mutation.SinglePoint(population);
        }
    }
}