using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Revision_Finale_Camp_Vancances
{
    public abstract class Personne
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int Age { get; set; }
        public string NomComplet => $"{Nom}, {Prenom}";
        public override string ToString()
        {
            return NomComplet + $" Âge: {Age}ans";
        }
    }
}
