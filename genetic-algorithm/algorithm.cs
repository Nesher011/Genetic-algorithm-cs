namespace genetic_algorithm
{
    internal class Algorithm
    {
        public Algorithm()
        {

        }
        public static void Crossover(List<Individual> population)
        {
            Crossover crossover = new();
            crossover.SinglePoint(population);
            
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
