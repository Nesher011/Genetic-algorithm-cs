using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genetic_algorithm
{
    internal class Generation
    {
        public int numberOfIndividuals { get; set; }
        public List<Individual> population { get; set; }

        public Generation()
        {
            population=new List<Individual>();
            numberOfIndividuals = 40;
            for (int i = 0; i < numberOfIndividuals; i++)
            {
                Individual individual = new Individual(96);
                population.Add(individual);
            }
        }
    }
}
