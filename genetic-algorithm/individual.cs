using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genetic_algorithm
{
    internal class Individual
    {
        public Individual(int numOfGenes)
        {
            genesList = new List<bool>();
            numberOfGenes = numOfGenes;
        }

        public List<bool> genesList { get; set; }

        public int numberOfGenes { get; set; }

        public List<float> waterLevelList()
        {
            List<bool> pump1=new List<bool>();
            //pump1.InsertRange(2, genesList);//***TO DO***
            Console.WriteLine(pump1);
            return null;
        }
        public double FitnessFunction()
        {
            //Console.WriteLine(numberOfGenes);
            return numberOfGenes;
        }
    }

}
