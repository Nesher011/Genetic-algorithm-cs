using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genetic_algorithm
{
    public class Individual
    {
        public Individual(int numOfGenes)
        {
            genesList = new List<bool>();
            numberOfGenes = numOfGenes;
        }

        public List<bool> genesList { get; set; }

        public int numberOfGenes { get; set; }
    }
}
