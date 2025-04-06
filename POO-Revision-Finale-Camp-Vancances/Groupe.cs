using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Revision_Finale_Camp_Vancances
{
    public class Groupe
    {
        public string Nom { get; set; }
        public string TrancheAge { get; set; }
        public ObservableCollection<Campeur> Campeurs { get; set; } = new ObservableCollection<Campeur>();
        public Moniteur MoniteurAttitre { get; set; }
    }
}
