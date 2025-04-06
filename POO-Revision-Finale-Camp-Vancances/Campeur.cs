using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace POO_Revision_Finale_Camp_Vancances
{
    public class Campeur : Personne
    {
        public string Allergies { get; set; }
        public Groupe GroupeAssigné { get; set; }
        public ObservableCollection<Activite> Activites { get; set; } = new ObservableCollection<Activite>();
        public string VoirActivites
        {
            get
            {
                if (Activites.Count == 0)
                    return "Aucune activité inscrite";
                else
                    return string.Join(", ", Activites.Select(a => a.Nom));
            }
        }
    }
}
