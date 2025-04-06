using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Revision_Finale_Camp_Vancances
{
    public interface IEncadrant
    {
        string AnimerActivite(Activite activite);
        string SurveillerCampeurs();
    }
}
