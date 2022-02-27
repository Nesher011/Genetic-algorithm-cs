using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genetic_algorithm
{
    internal class Algorithm
    {
        public Algorithm()
        {
            rateOfCrossover = 0.9;
            rateOfMutation = 1 / 96;
        }
        public double rateOfCrossover { get; set; }
        public double rateOfMutation { get; set; }        
    }
}
