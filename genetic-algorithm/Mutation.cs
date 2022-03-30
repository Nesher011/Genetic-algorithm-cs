using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genetic_algorithm
{
    internal class Mutation
    {
        private double RateOfMutation { get; set; }
        public Mutation()
        {
            RateOfMutation = 1 / 96F;
        }
        public void SinglePoint(List<Individual> population)
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
