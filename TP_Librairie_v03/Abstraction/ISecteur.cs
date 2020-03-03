using System;
using System.Collections.Generic;
using System.Text;
using TPLibrairiev03;

namespace TPLibrairiev03.Abstraction
{
    public interface ISecteur
    {
        void Insert(Secteur secteur);
        void Update(Secteur secteur);
        void Remove(Secteur secteur);
        List<Secteur> GetAllSecteur();
        Secteur FindById(int id);
        decimal GetPrixMoyenParSecteur(Secteur secteur);
        decimal GetQteArticlesParSecteur(Secteur secteur);
        decimal GetNombreEtageresParSecteur(Secteur secteur);
        decimal GetTauxRemplissageParSecteur(Secteur secteur);
    }
}