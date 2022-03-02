using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genetic_algorithm
{
    internal class Generation
    { 
        public List<Individual> population { get; }

        public Generation(int numberOfIndividuals)
        {
            population=new List<Individual>();
            for (int i = 0; i < numberOfIndividuals; i++)
            {
                Individual individual = new Individual(96);
                population.Add(individual);
            }
        }
    }
}
