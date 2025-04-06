using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Revision_Finale_Camp_Vancances
{
    public class Sejour
    {
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public ObservableCollection<Campeur> Campeurs { get; set; } = new ObservableCollection<Campeur>();
        public ObservableCollection<Activite> ProgrammeActivites { get; set; } = new ObservableCollection<Activite>();
    }
}
